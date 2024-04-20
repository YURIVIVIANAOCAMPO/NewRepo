/ Please see documentation at https:/ / docs.microsoft.com / aspnet / core / client - side / bundling - and - minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.tableData').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json'
        },
        "order": [[0, "desc"]]
        // "scrollX": true
    });

    jQuery.extend(jQuery.fn.dataTableExt.oSort, {
        "date-uk-pre": function (a) {
            var ukFullDate = a.split(' ');
            var ukDatea = ukFullDate[0].split('/');
            var ukTime = ukFullDate[1].split(':');
            return (ukDatea[2] + ukDatea[1] + ukDatea[0]) + ukTime[0] + ukTime[1] + ukTime[2] * 1;
        },

        "date-uk-asc": function (a, b) {
            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
        },

        "date-uk-desc": function (a, b) {
            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
        }
    });
});

$(function () {
    $("#loaderbody").addClass('hide');
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

function humanizeNumber(n) {
    n = n.toString()
    while (true) {
        var n2 = n.replace(/(\d)(\d{3})($|,|\.)/g, '$1.$2$3')
        if (n == n2) break
        n = n2
    }
    return n
}

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res.html);
            $("#form-modal .modal-title").html(res.title);
            $("#form-modal").modal('show');
        }
    })
}

showInPopupParametro = (url, title, parametro) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res.html);
            $("#form-modal .modal-title").html(res.title);
            $("#idParametro").val(parametro);
            $("#form-modal").modal('show');
        }
    })
}

showInPopupParametro2 = (url, title, parametro, parametro2) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal .modal-body").html(res.html);
            $("#form-modal .modal-title").html(res.title);
            $("#idParametro").val(parametro);
            $("#idParametro2").val(parametro2);
            $("#form-modal").modal('show');
        }
    })
}

showInLargePopup = (url, title) => {
    alert("Hola");
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#form-modal-full .modal-body").html(res.html);
            $("#form-modal-full .modal-title").html(res.title);
            $("#form-modal-full").modal('show');
        }
    })
}
