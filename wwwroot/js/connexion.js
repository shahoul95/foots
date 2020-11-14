$(document).ready(function () {
    $(".btn").click(function () {
        var id = $("#mails").val();
        var pass = $("#motpasse").val();
 

        $.ajax({
            url: "/Connexion/connexions",
            method: "get",
            data: { "id": id, "pass": pass },
            dataType: "JSON",


        }).done(function (data) {
        
            $(".connection").html(data[0]);
            if (data[1] == 1) {
                $(location).attr("href", "/profile");
            }
        });

    });

});