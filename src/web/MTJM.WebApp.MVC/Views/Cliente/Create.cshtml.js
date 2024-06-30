document.addEventListener("DOMContentLoaded", (ev) => {
    ShowErrorMessage();
})

function ShowErrorMessage() {
    let errorMessage = document.querySelector('#errorMessage');

    if (errorMessage) {
        toastr.error(errorMessage.value, "Error");
    }
}