$(function () {


    function PostPublish(postId) {

        var options = { "backdrop": "static", keyboard: true };

        $.ajax({
            type: "GET",
            url: '/ClientProfile/PublishPostCargo?postId=' + postId,
            contentType: "application/json; charset=utf-8",
            //data: { "postId": id },
            //datatype: "json",
            success: function(data) {
                $('#myContentPublish').html(data);
                $('#myModalPublish').modal(options);
                $('#myModalPublish').modal('show');
            },
            error: function() {
                alert("Dynamic content load failed.");
            }
        });

        $("#closbtn").click(function() {
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
            success: function(data) {
                $('#myContentPublish').html(data);
                $('#myModalPublish').modal(options);
                $('#myModalPublish').modal('show');
            },
            error: function() {
                alert("Dynamic content load failed.");
            }
        });

        $("#closbtn").click(function() {
            $('#myModal').modal('hide');
        });
    };

});