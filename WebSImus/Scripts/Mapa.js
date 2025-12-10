function ActualizarActividad() {
    var attribute = Xrm.Page.getAttribute("new_latitud");
    var attributeLong = Xrm.Page.getAttribute("new_longitud");

    try {

        navigator.geolocation.getCurrentPosition(function (position) {
            var lat = position.coords.latitude;
            var lon = position.coords.longitude;



            if (attribute != null) {
                attribute.setValue(lat);
                attribute.setSubmitMode("always");
                Xrm.Page.data.entity.save();

            }
            else { alert("No se encuentra el atributo."); }
            if (attributeLong != null) {
                attributeLong.setValue(lon);
                attributeLong.setSubmitMode("always");
                Xrm.Page.data.entity.save();

            }
            else { alert("No se encuentra el atributo de longitud."); }


        });

    }
    catch (ex) {
        alert("Error " + ex);
    }

}


function CreateActivity() {
    var new_actividadventa = {};
    new_actividadventaSet.Subject = "Test Account Name";
    new_actividadventaSet.Description = "This account was created by the JavaScriptRESTDataOperations sample.";
   

    

    //Create the Account
    SDK.REST.createRecord(
        new_actividadventa,
        "new_actividadventa",
        function (new_actividadventa) {
            writeMessage("The account named \"" + new_actividadventa.Subject + "\" was created with the AccountId : \"" + new_actividadventa.AccountId + "\".");
            writeMessage("Retrieving account with the AccountId: \"" + new_actividadventa.AccountId + "\".");
            retrieveAccount(account.AccountId)
        },
        errorHandler
      );
    this.setAttribute("disabled", "disabled");
}

function retrieveAccount(AccountId) {
    SDK.REST.retrieveRecord(
        AccountId,
        "Account",
        null, null,
        function (account) {
            writeMessage("Retrieved the account named \"" + account.Name + "\". This account was created on : \"" + account.CreatedOn + "\".");
            updateAccount(AccountId);
        },
        errorHandler
      );
}

function AgregarActividad () {

    var serverUrl = window.parent.Xrm.Page.context.getServerUrl().toString();
    var ODATA_ENDPOINT = "/XRMServices/2011/OrganizationData.svc";
    var objAnnotation = new Object();
    var ODATA_EntityCollection = "/new_actividadventaSet";
    objAnnotation.Subject = "Prueba Grey Milena";
    objAnnotation.Description = "Esta prueba se realiza para crear";
    alert("Prueba para agrgar");
    

    // Parse the entity object into JSON 
    var jsonEntity = window.JSON.stringify(objAnnotation);

    // Asynchronous AJAX function to Create a CRM record using OData 
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        url: serverUrl + ODATA_ENDPOINT + ODATA_EntityCollection,
        data: jsonEntity,
        beforeSend: function (XMLHttpRequest) {
            XMLHttpRequest.setRequestHeader("Accept", "application/json");
        },
        error: function (xmlHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus + "; ErrorThrown: " + errorThrown);
        }
    });
}