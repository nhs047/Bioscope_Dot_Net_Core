/// <reference path="../../g_assets/js/plugins/notifications/sweet_alert.min.js" />

swal.setDefaults({
    buttonsStyling: false,
    confirmButtonClass: 'btn btn-primary',
    cancelButtonClass: 'btn btn-light'
});

// alert types warning, error, success, info, and question
function alertWarning(title, text) {
    swal({
        type: "warning",
        title: `${title}`,
        html: `${text}`,
        showConfirmButton: false
    });
}
function alertError(title, text) {
    swal({
        type: "error",
        title: `${title}`,
        html: `${text}`,
        showConfirmButton: false
    });
}

function alertSuccess(title, text) {
    swal({
        type: "success",
        title: `${title}`,
        html: `${text}`,
        showConfirmButton: false
    });
}

function alertInfo(title, text) {
    swal({
        type: "info",
        title: `${title}`,
        html: `${text}`,
        showConfirmButton: false
    });
}

function alertQuestion(title, text, callback) {
    swal({
        reverseButtons: true,
        title: "Please Confirm !",
        html: `<h5> ${text} </h5>`,
        type: 'question',
        showCancelButton: true,
        confirmButtonText: 'OK',
        cancelButtonText: "Cancel",
    }).then((result) => {
        if (result.value) {
            callback();
        }
        return;
    });
}