let datatables;
let userHaveAccessInDelete;
let userHaveAccessInUpdate;

document.addEventListener("DOMContentLoaded", async (ev) => {
    LoadMessages();
    userHaveAccessInDelete = await VerifiyUserHaveAccess("Servico", "Delete");
    userHaveAccessInUpdate = await VerifiyUserHaveAccess("Servico", "Update");
    await InitializeDataTables();
});

//#region Init. Data tables
async function InitializeDataTables() {
    datatables = new DataTable("#tableServicos", {
        async: true,
        responsive: true,
        paging: true,
        pagingType: 'simple_numbers',
        ajax: {
            url: GetBaseURL() + '/Servicos/GetAll',
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
                        return `<a href="${GetBaseURL()}/Servicos/Edit/${row.id}" class="btn btn-info"><i class="fa fa-pen"/></a>`;
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data)
                        return `<a class="btn btn-danger" onclick="LoadingSwalfire(${row.id}, '${row.descricao}')"><i class="fa fa-trash"/></a>`;
                },
                orderable: false,
            },
            { "data": "id" },
            { "data": "unidade" },
            { "data": "descricao" },
            { "data": "horas" },
            { "data": "precoPorHora" },
            {
                data: null,
                render: function (data, type, row, meta) {
                    let total = row.horas * row.precoPorHora;

                    return total.toFixed(2);
                }
            },
        ],
        order: [
            [4, 'asc', '5%']
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
async function LoadingSwalfire(id, descricao) {

    var swalfire = await Swal.fire({
        title: "Are you sure?",
        text: "The Service that will be deleted " + descricao,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    });

    let responseJSON;

    if (swalfire.isConfirmed) {

        const response = await fetch(GetBaseURL() + '/Servicos/Delete/' + id, {
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
            text: "Your Service has been deleted.",
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