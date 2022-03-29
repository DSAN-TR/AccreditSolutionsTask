function EmptyStringValidation(elem, displayname) {

    var val = $(elem).val();
    if (val === undefined || val.trim().length == 0) {
        alert(displayname + " is required!");
    }
}

function StringIsNullOrEmpty(str) {
    return str === null || str.trim().length == 0
}

function RenderLoading() {
    return '<div><img src="/Content/images/loading.gif" width="24px"> Loading...</div>'
}

function ContentClear(elem) {
    $(elem).html('');
}