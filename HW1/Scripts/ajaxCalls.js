function ajaxCall(method, api, data, successCB, errorCB) {
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: true,
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB
       
    });
}