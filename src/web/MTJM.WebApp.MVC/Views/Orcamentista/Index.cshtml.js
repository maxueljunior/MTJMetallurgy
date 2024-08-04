let datatables;
let userHaveAccessInDelete;
let userHaveAccessInUpdate;

document.addEventListener("DOMContentLoaded", async (ev) => {
    LoadMessages();
    userHaveAccessInDelete = await VerifiyUserHaveAccess("Orcamentista", "Delete");
    userHaveAccessInUpdate = await VerifiyUserHaveAccess("Orcamentista", "Update");
    await InitializeDataTables();
});

//#region Init. Data tables
async function InitializeDataTables() {
    datatables = new DataTable("#tableOrcamentista", {
        async: true,
        responsive: true,
        paging: true,
        pagingType: 'simple_numbers',
        ajax: {
            url: GetBaseURL() + '/Orcamentista/GetAll',
            dataSrc: function (response) {
                if (response.status === 200)
                    return response.result;

                return;
            }
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data)
                        return `<a href="${GetBaseURL()}/Orcamentista/Edit/${row.id}" class="btn btn-info"><i class="fa fa-pen"/></a>`;
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {

                    var nomeOrcamentistaCompleto = `${row.nome} ${row.sobrenome}` // TODO

                    if (data)
                        return `<a class="btn btn-danger" onclick="LoadingSwalfire(${row.id}, '${nomeOrcamentistaCompleto}')"><i class="fa fa-trash"/></a>`;
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    var nomeOrcamentistaCompleto = `${row.nome} ${row.sobrenome}`

                    return nomeOrcamentistaCompleto;
                }
            },
            { "data": "endereco.localidade" },
            { "data": "coordenadorRegional" },
        ],
        order: [
            [2, 'asc', '5%']
        ],
        scrollX: true,
        columnDefs: [
            { className: "text-center", width: "5%", targets: 0, visible: userHaveAccessInUpdate },
            { className: "text-center", width: "5%", targets: 1, visible: userHaveAccessInDelete },
        ]
    });
}
//#endregion

//#region Loading Swal Fire
async function LoadingSwalfire(id, nomeCompleto) {

    var swalfire = await Swal.fire({
        title: "Are you sure?",
        text: "The Orcamentista that will be deleted " + nomeCompleto,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    });

    let responseJSON;

    if (swalfire.isConfirmed) {

        const response = await fetch(GetBaseURL() + '/Orcamentista/Delete/' + id, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "RequestVerificationToken": GetRequestVerificationToken()
            },
        })

        responseJSON = await response.json();
    }

    if (responseJSON.status === 200) {
        Swal.fire({
            title: "Deleted!",
            text: "Your Orcamentista has been deleted.",
            icon: "success"
        });
        datatables.ajax.reload();
        return;
    }

    Swal.fire({
        title: "Error!",
        text: responseJSON.errors.Messages[0],
        icon: "error"
    })

    return;
}
//#end region