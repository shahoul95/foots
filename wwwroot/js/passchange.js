change();
function change() {
    $.ajax({
        url: "/Passchange/change",
        method: "get",
        dataType: "JSON",


    }).done(function (data) {
        $("#email").val(data);
        if (data == false) {
            $(location).attr("href", "/password");
        }

    });
}
$(document).ready(function () {
    $(".btn").click(function () {
        var a = $("#email").val();

        var c = $("#nouveau ").val();
        var b = { "Login": a, "MotPasses": c };
        $.ajax({
            url: "/Passchange/update",
            method: "post",
            data: JSON.stringify(b),
            dataType: "JSON",
            contentType: "application/json",

        }).done(function (data) {

          
            if (data == 0) {
                $("#nouveau").val("");
                $("#message").html("Mot de passe changé");
                setTimeout(function () { $(location).attr("href", "/password"); }, 2000);
            }

        });
    });
});