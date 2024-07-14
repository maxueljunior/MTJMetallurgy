let datatables;
let userHaveAccessInDelete;
let userHaveAccessInUpdate;

document.addEventListener("DOMContentLoaded", async (ev) => {
    LoadMessages();
    userHaveAccessInDelete = await VerifiyUserHaveAccess("CRV", "Delete");
    userHaveAccessInUpdate = await VerifiyUserHaveAccess("CRV", "Update");
    await InitializeDataTables();
});

//#region Init. Data tables
async function InitializeDataTables() {
    datatables = new DataTable("#tableCrv", {
        async: true,
        responsive: true,
        paging: true,
        pagingType: 'simple_numbers',
        ajax: {
            url: GetBaseURL() + '/CoordenadorRegional/GetTableCRV',
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
                        return `<a href="${GetBaseURL()}/CoordenadorRegional/Edit/${row.id}" class="btn btn-info"><i class="fa fa-pen"/></a>`;
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {

                    var nomeCrvCompleto = `${row.nome} ${row.sobrenome}`

                    if (data)
                        return `<a class="btn btn-danger" onclick="LoadingSwalfire(${row.id}, '${nomeCrvCompleto}')"><i class="fa fa-trash"/></a>`;
                },
                orderable: false,
            },
            {
                data: null,
                render: function (data, type, row, meta) {
                    var nomeCrvCompleto = `${row.nome} ${row.sobrenome}`

                    return nomeCrvCompleto;
                }
            },
            { "data": "endereco.localidade" },
            { "data": "nomeOrcamentista" },
            { "data": "quantidadeClientes" },
        ],
        order: [
            [2, 'asc', '5%']
        ],
        scrollX: true,
        columnDefs: [
            { className: "text-center", width: "5%", targets: 0, visible: userHaveAccessInUpdate },
            { className: "text-center", width: "5%", targets: 1, visible: userHaveAccessInDelete },
            { className: "text-center", targets: 5},
        ]
    });
}
//#endregion