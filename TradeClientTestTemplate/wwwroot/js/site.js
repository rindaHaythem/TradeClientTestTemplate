// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
    'use strict'

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation')

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                }

                form.classList.add('was-validated')
            }, false)
        })
})()

$(function () {
    $("#OrderType").change(function () {
        if ($(this).val() == 2) {
            $("#limitPrice").removeAttr("disabled");
            $("#limitPrice").focus();
            $("#stopPrice").attr("disabled", "disabled");
        } else if ($(this).val() == 3) {
            $("#stopPrice").removeAttr("disabled");
            $("#stopPrice").focus();
            $("#limitPrice").attr("disabled", "disabled");
        } else if ($(this).val() == 4) {
            $("#limitPrice").removeAttr("disabled");
            $("#stopPrice").removeAttr("disabled");
            $("#stopPrice").focus();
        } else {
            $("#limitPrice").attr("disabled", "disabled");
            $("#stopPrice").attr("disabled", "disabled");
        }
    });
});
    


$(function () {
    $('#tableTESTOR').bootstrapTable()
})

/*Stop & Limit price validation*/
$(function () {

    $('.number-only').keyup(function (e) {
        if (this.value != '-')
            while (isNaN(this.value))
                this.value = this.value.split('').reverse().join('').replace(/[\D]/i, '')
                    .split('').reverse().join('');
    })
        .on("cut copy paste", function (e) {
            e.preventDefault();
        });

});

$(function () {
    $("#TimeInForce").change(function () {
        if ($(this).val() == 6) {
            $("#dateGTD").removeAttr("disabled");
            $("#dateGTD").focus();
        } else {
            $("#dateGTD").attr("disabled", "disabled");
        }
    });
});

var today = new Date().toISOString().split('T')[0];
document.getElementsByName("dateGTD")[0].setAttribute('min', today);

