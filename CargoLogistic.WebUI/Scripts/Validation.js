$(document).ready(function () {

$(function () {

    $.validator.addMethod(
        "positivenumber", function(value, element) {
            try
            {
                if ($(element).is('disabled')) {
                    return true;
                }
                if ($(element).is('[data-val-positivenumber]')) {
                    if (isNaN($(element).val()))
                        return false;
                    var elementValue = parseInt($(element).val(), 10);
                    return elementValue > 0;
                }
            }
            catch (e)
            {
                return false;
            }
        },
        "Please serii ...");
    $.validator.unobtrusive.adapters.addBool("positivenumber");

    });

});