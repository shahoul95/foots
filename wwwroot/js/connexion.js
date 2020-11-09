$(document).ready(function () {
    $(".btn").click(function () {
        var id = $("#mails").val();
        var pass = $("#motpasse").val();
        alert(id);

        $.ajax({
            url: "/Connexion/connexions",
            method: "get",
            data: { "id": id, "pass": pass },
            dataType: "JSON",


        }).done(function (data) {
            console.log(data);
            $(".connection").html(data[0]);
            if (data[1] == 1) {
                $(location).attr("href", "/profile");
            }
        });

    });

});