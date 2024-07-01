// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//$('#form2 input[type=text]').on('change invalid', function () {
//    var textfield = $(this).get(0);

//    // 'setCustomValidity not only sets the message, but also marks
//    // the field as invalid. In order to see whether the field really is
//    // invalid, we have to remove the message first
//    textfield.setCustomValidity('');

//    if (!textfield.validity.valid) {
//        textfield.setCustomValidity('Lütfen işaretli yerleri doldurunuz');
//    }
//});


function InvalidMsg(textbox) {
    if (textbox.value == '') {
        textbox.setCustomValidity('Lütfen işaretli yerleri doldurunuz');
    }
    else if (textbox.validity.typeMismatch) {
        textbox.setCustomValidity('Lütfen işaretli yere geçerli bir email adresi yazınız.');
    }
    else {
        textbox.setCustomValidity('');
    }
    return true;
}