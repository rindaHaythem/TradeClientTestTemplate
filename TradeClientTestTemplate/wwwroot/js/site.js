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

// hidden input text
/*
var ddl = document.getElementById("OrderType");
ddl.onchange = newOrderType;
function newOrderType() {
    var ddl = document.getElementById("OrderType");
    var selectedValue = ddl.options[ddl.selectedIndex].value;


    if (selectedValue == "3") {
        document.getElementById("stopPrice").style.display = "block";
    }
    else {
        document.getElementById("stopPrice").style.display = "none";
    }
}
*/

// DROPDOWN SEARCH SYMBOL

/*$('.dropdown').each(function (index, dropdown) {

    //Find the input search box
    let search = $(dropdown).find('.search');

    //Find every item inside the dropdown
    let items = $(dropdown).find('.dropdown-item');

    //Capture the event when user types into the search box
    $(search).on('input', function () {
        filter($(search).val().trim().toLowerCase())
    });

    //For every word entered by the user, check if the symbol starts with that word
    //If it does show the symbol, else hide it
    function filter(word) {
        let length = items.length
        let collection = []
        let hidden = 0
        for (let i = 0; i < length; i++) {
            if (items[i].value.toString().toLowerCase().includes(word)) {
                $(items[i]).show()
            } else {
                $(items[i]).hide()
                hidden++
            }
        }

        //If all items are hidden, show the empty view
        if (hidden === length) {
            $(dropdown).find('.dropdown_empty').show();
        } else {
            $(dropdown).find('.dropdown_empty').hide();
        }
    }

    //If the user clicks on any item, set the title of the button as the text of the item
    $(dropdown).find('.dropdown-menu').find('.menuItems').on('click', '.dropdown-item', function () {
        $(dropdown).find('.dropdown-toggle').text($(this)[0].value);
        $(dropdown).find('.dropdown-toggle').dropdown('toggle');
    })
});


*/



/*$('[data-toggle="tooltip"]').tooltip();*/