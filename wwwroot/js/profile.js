var setinterval = setInterval(getmessage, 2000);
var setsinterval = setInterval(getnonvue, 2000);
getmessage();

getprofile();

getamie();
getnonvue();
function getprofile() {
    $.ajax({
        url: "/Profile/GetProfile",
        method: "get",
        dataType: "JSON",


    }).done(function (data) {
    
        $("#nom").html(data.prenom + " " + data.nom);
        $("#equipe").html(data.equipe);
        $("#poste").html(data.poste);

        if (data == 0) {
            $(location).attr("href", "/connexion");
        }
    });
}

function getmessage() {
    $.ajax({
        url: "/Profile/GetMessage",
        method: "get",
        dataType: "JSON",


    }).done(function (data) {
  
        $(".inbox_chat").html(" ");

        for (var i in data) {

            $(".inbox_chat").prepend('<hr> <div class="chat_list "><div class="chat_people"><div class="chat_img"><img src="https://ptetutorials.com/images/user-profile.png"alt="sunil"></div> <div class="chat_ib"> <h5 id="destinataire"> Destinataire: ' + data[i].destinataire + ' </h5> <p id="message">Message: ' + data[i].message + '</p></div></div> </div>');



        }
    });
}

function getamie() {
    $.ajax({
        url: "/Profile/GetAmis",
        method: "get",
        dataType: "JSON",


    }).done(function (data) {

        for (var a in data) {
            $("#amis").append('<option selected="selected">' + data[a].prenom + '</option>');

        }

    });
}
function envoie() {
    var nom = $(".p").val();
    var message = $("#messagese").val();
    var messages = { "Message": message, "ExpediteurNavigation": { "Nom": nom } };

    $.ajax({
        url: "/Profile/message",
        method: "post",
        data: JSON.stringify(messages),
        dataType: "JSON",
        contentType: "application/json",


    }).done(function (data) {
        $(".p").val(" ");
        $("#messagese").val(" ");
    
    });

}

function getnonvue() {
    $.ajax({
        url: "/Profile/Getvue",
        method: "get",
        dataType: "JSON",


    }).done(function (data) {

        $("#vue").html(data);


    });
}
function getvue() {
    $.ajax({
        url: "/Profile/Getnonvue",
        method: "put",
        dataType: "JSON",


    }).done(function (data) {
  

    });
}