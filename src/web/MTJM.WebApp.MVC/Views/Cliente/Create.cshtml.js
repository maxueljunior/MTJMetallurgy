let inputUsername = document.querySelector('#inputUsername');
let form = document.querySelector('#formCliente');
let btnSubmitForm = document.querySelector('#btnSubmitForm');
let userAlreadyExists = false;

document.addEventListener("DOMContentLoaded", (ev) => {
    ShowErrorMessage();
})

function ShowErrorMessage() {
    let errorMessage = document.querySelector('#errorMessage');

    if (errorMessage) {
        toastr.error(errorMessage.value, "Error");
    }
}

inputUsername.addEventListener("blur", async (event) => {
    userAlreadyExists = await ExistsUsername(inputUsername.value);
    
    if (userAlreadyExists == undefined) {
        btnSubmitForm.disabled = true;
        return;
    }

    btnSubmitForm.disabled = false;
});

form.addEventListener('submit', (event) => {
    if (userAlreadyExists == undefined)
        event.preventDefault();
})

async function ExistsUsername(username) {
    const response = await fetch(GetBaseURL() + "/Auth/ExistsUsername", {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "RequestVerificationToken": GetRequestVerificationToken()
        },
        body: JSON.stringify(
            username
        )
    });

    const responseJSON = await response.json();

    if (responseJSON.status == 200) {
        return false;
    }

    Array.from(responseJSON.errors.Messages).forEach(e => toastr.error(e, "Error"));
    return;
}
