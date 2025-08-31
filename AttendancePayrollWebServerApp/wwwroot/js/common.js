window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successfull", { timeOut: 6000 });
    }
    if (type === "error") {
        toastr.error(message, "Operation failed", { timeOut: 6000 });
    }
}


