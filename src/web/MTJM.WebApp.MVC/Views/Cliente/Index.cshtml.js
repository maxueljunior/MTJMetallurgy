let datatables;

document.addEventListener("DOMContentLoaded", async (ev) => {
    LoadMessages();
    await InitializeDataTables();
})

//#region Initialize Data Tables
async function InitializeDataTables() {
    datatables = new DataTable("#tableCliente", {
        async: true,
        responsive: true,
        paging: true,
        pagingType: 'simple_numbers',
        ajax: {
            url: GetBaseURL() + "/Cliente/GetTableClientes",
            dataSrc: ""
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data)
                        return `<a href="${GetBaseURL()}/Cliente/Edit/${row.id}" class="btn btn-info"><i class="fa fa-pen"/></a>`;
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {

                    var nomeClienteCompleto = `${row.nome} - ${row.cnpj}`

                    if (data)
                        return `<a class="btn btn-danger" onclick="LoadingSwalfire(${row.id}, '${nomeClienteCompleto}')"><i class="fa fa-trash"/></a>`;
                },
                orderable: false,
            },
            { "data": "nome" },
            { "data": "cnpj" },
            { "data": "endereco.localidade" },
            { "data": "coordenadorRegional" },
        ],
        order: [
            [2, 'asc', '5%']
        ],
        scrollX: true,
        columnDefs: [
            { className: "text-center", width: "5%", targets: [0,1] }
        ]
    });
}
//#end region

//#region Load Messages
function LoadMessages() {
    let successMessage = document.querySelector("#successMessage");
    let errorMessage = document.querySelector("#errorMessage");

    if (successMessage) {
        toastr.success(successMessage.value, "Success");
    }

    if (errorMessage) {
        toastr.error(errorMessage.value, "Error");
    }
}
//#end region

//#region
async function LoadingSwalfire(id, nomeCompleto) {

    var swalfire = await Swal.fire({
        title: "Are you sure?",
        text: "The Cliente that will be deleted " + nomeCompleto,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    });

    let responseJSON;

    if (swalfire.isConfirmed) {

        const response = await fetch(GetBaseURL() + '/Cliente/Delete/' + id, {
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
            text: "Your Cliente has been deleted.",
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