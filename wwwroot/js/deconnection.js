deco();
function deco() {
    $.ajax({
        url: "/Deconnection/deco",
        method: "get",
        dataType: "JSON",


    }).done(function (data) {
   
        var verif = data.deco;

        if (verif == 1) {

            $(location).attr("href", "/connexion");
        }
    });

}