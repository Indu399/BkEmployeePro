/* BEGIN EXTERNAL SOURCE */

    $(document).ready(function () {
        $("#sub").click(function () {

            $("#popupmodel").modal('show')
            {

            }
        });
    });

/* END EXTERNAL SOURCE */
/* BEGIN EXTERNAL SOURCE */

    $("#sub").click(function (e) {
        debugger;
        // if ($('#formstudents').validate().form()) {

        var form = $("#Editform");
        debugger;
        $.ajax({
            url: '/*****************************/',
            type: "POST",
            data: form.serialize(),
            success: function (data) {
                debugger;
                if (data.status == 0) {
                    
                    ShowToasterMessage('success', 'Employee Updated Successfully!', 'Success');
                    return false;
                }

                if (data.status == 1) {
                    ShowToasterMessage('error', data.Message, 'Error');
                    return false;
                }
            }
        });
        // }
        e.preventDefault();
    });

/* END EXTERNAL SOURCE */
