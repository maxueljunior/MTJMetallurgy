document.addEventListener("DOMContentLoaded", async (ev) => {
    await InitializeDataTables();
})

async function InitializeDataTables() {
    new DataTable("#tableCliente", {
        "async": true,
        "responsive": true,
        "ajax": {
            url: "Cliente/GetTableClientes",
            dataSrc: ""
        },
        "columns": [
            { "data": "nome" },
            { "data": "cnpj" },
            { "data": "endereco.localidade" },
            { "data": "coordenadorRegionalId" },
        ]
    });
}