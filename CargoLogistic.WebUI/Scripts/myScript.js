$(document).ready(function () {
    // datepikher
    $(function () {
        $("#DateTo").datepicker({
            autoSize: true,
            currentText: "Now"
        });
        
        $("#DateFrom").datepicker({
            autoSize: true
        });
        
    });

    // admin menu tabs
    $(function () {
        $("#admin-menu").tabs();
    });

    // user menu tabs
    $(function () {
        $("#user-menu").tabs();
    });

    // Autocomplete
    $(function () {
        var availableTags = [
            "Construction",
            "Metal",
            "Products",
            "Gadjets",
            "Electronics",
            "Books",
            "Instruments",
            "Wheels",
            "Car equipment",
            "Doors",
            "Tables",
            "Goods",
            "ADR",
            "Plants",
            "Caw",
            "Animals",
            "Medical",
            "Militar",
            "School equipment",
            "Partial",
            "Monitors",
            "Other"
        ];
        $("#CargoDescription").autocomplete({
            source: availableTags
        });
    });

    //Unobtrusive Validation
    $.validator.addMethod(
            "positivenumber",
            function (value, element) {
                try {
                    if ($(element).is('disabled'))
                        return true;
                    if ($(element).is('[data-val-positivenumber]')) {
                        if (isNaN($(element).val()))
                            return false;
                        var elementValue = parseInt($(element).val(), 10);
                        return elementValue > 0;
                    }
                } catch (e) {
                    return false;
                }
            },
            "");
       $.validator.unobtrusive.adapters.addBool("positivenumber");
    //Unobtrusive Validation
});



function PostPublish(postId) {

    var options = { "backdrop": "static", keyboard: true };

    $.ajax({
        type: "GET",
        url: '/ClientProfile/PublishPostCargo?postId=' + postId,
        contentType: "application/json; charset=utf-8",
        //data: { "postId": id },
        //datatype: "json",
        success: function (data) {
            $('#myContentPublish').html(data);
            $('#myModalPublish').modal(options);
            $('#myModalPublish').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });

    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
};

var PostUnPublish = function (postId) {

    var options = { "backdrop": "static", keyboard: true };

    $.ajax({
        type: "GET",
        url: '/ClientProfile/UnPublishPostCargo?postId=' + postId,
        contentType: "application/json; charset=utf-8",
        //data: { "postId": id },
        //datatype: "json",
        success: function (data) {
            $('#myContentPublish').html(data);
            $('#myModalPublish').modal(options);
            $('#myModalPublish').modal('show');
        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });

    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
};