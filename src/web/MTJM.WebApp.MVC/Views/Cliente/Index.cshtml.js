document.addEventListener("DOMContentLoaded", async (ev) => {
    LoadMessages();
    await InitializeDataTables();
})

//#region Initialize Data Tables
async function InitializeDataTables() {
    new DataTable("#tableCliente", {
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
                    if (data)
                        return '<a class="btn btn-danger"><i class="fa fa-trash"/></a>';
                },
                orderable: false,
            },
            { "data": "nome" },
            { "data": "cnpj" },
            { "data": "endereco.localidade" },
            { "data": "coordenadorRegionalId" },
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