document.addEventListener("DOMContentLoaded", async (ev) => {
    LoadMessageIfCreate();
    await InitializeDataTables();
})

async function InitializeDataTables() {
    new DataTable("#tableCliente", {
        async: true,
        responsive: true,
        paging: true,
        pagingType: 'simple_numbers',
        ajax: {
            url: "Cliente/GetTableClientes",
            dataSrc: ""
        },
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data)
                        return '<button class="btn btn-info"><i class="fa fa-pen"/></button>';
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    if (data)
                        return '<button class="btn btn-danger"><i class="fa fa-trash"/></button>';
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

function LoadMessageIfCreate() {
    let messageCreate = document.querySelector("#messageSuccess");

    if (messageCreate) {
        toastr.success(messageCreate.value, "Success");
    }
}