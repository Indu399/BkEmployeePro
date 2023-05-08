
function LoadDropDown(url, controlId) {

    $.ajax({
        url: url,
        cache: false,
        type: "GET",
        async: false,
        traditional: true,
        success: function (data) {

            $('#' + controlId).empty();
            $('#' + controlId).append("<option value=''>Select</option>");
            data = $.map(data, function (item, a) {
                $('#' + controlId).append("<option value=" + item.Value + ">" + item.Text + "</option>");
            });
        }
    });
}


function LoadEditPopUp(url) {
    //var url = $('#myModalContent').data();

    //$.get(url, function (data) {
    //    $('#gameContainer').html(data);

    //    $('#gameModal').modal('show');
    //});

    $('#myModalContent').load(url, function () {
        $('#myModal').modal({
            /*backdrop: 'static',*/
            keyboard: true
        }, 'show');
    });
    return false;
}

function CloseModalPopUp() {
    $('#myModal').modal('hide');
}

function ShowToasterMessage(type, message, heading) {

    if (type == 'success') {
        toastr.success(message, heading);
    }

    if (type == 'error') {
        toastr.error(message, heading);
    }
}

function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32) || (charCode == 188))
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}


function onlyAlphabetsAndNumbers(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123) || (charCode == 32) || (charCode == 188) || (charCode > 48 && charCode < 57))
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
}

function onlyNosAndDot(e, t) {
    var charCode = (e.which) ? e.which : event.keyCode
    if (charCode != 46 && charCode > 31
      && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function onlyNos(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if (charCode < 48 || charCode > 57) {
            return false;
        }
        return true;
    }
    catch (err) {
        alert(err.Description);
    }
}