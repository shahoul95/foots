$(document).ready(function () {
$(".btn").click(function () {


    var a = $("#email").val();
    var b = { "Login": a };
    $.ajax({
        url: "/Password/password",
        method: "post",
        data: JSON.stringify(b),
        dataType: "JSON",
        contentType: "application/json",
    }).done(function (data) {
        console.log(data);
        if (data == 0) {
            $(location).attr("href", "/passchange");
        }
        else if (data == false) {
            $("#message").html("Adresse non trouver dans la base");
            setTimeout(function () { $(location).attr("href", "/password"); }, 2000);
        }

    });

});
});