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
    


/*
mobiscroll.settings = {
    theme: 'windows',
    themeVariant: 'light'
};

mobiscroll.select('#demo-mobile', {
    display: 'bubble'
});

mobiscroll.select('#demo-desktop', {
    display: 'bubble',
    touchUi: false
});*/



$(function () {
    $('#tableTESTOR').bootstrapTable()
})

/*$(document).ready(function () {

    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
    });

});*/

$(document).ready(function () {
    $("#sidebar").mCustomScrollbar({
        theme: "minimal"
    });

    $('#dismiss, .overlay').on('click', function () {
        // hide sidebar
        $('#sidebar').removeClass('active');
        // hide overlay
        $('.overlay').removeClass('active');
    });

    $('#sidebarCollapse').on('click', function () {
        // open sidebar
        $('#sidebar').addClass('active');
        // fade in the overlay
        $('.overlay').addClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
});


/*onload = function () {
    var ele = document.querySelectorAll('.number-only')[0];
    ele.onkeypress = function (e) {
        if (isNaN(this.value + "" + String.fromCharCode(e.charCode)))
            return false;
    }
    ele.onpaste = function (e) {
        e.preventDefault();
    }
}*/

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