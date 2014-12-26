$(document).ready(function () {
  $("#btnAddAddress").on("click", function () {
    //http://stackoverflow.com/questions/4051504/asp-net-mvc-add-child-records-dynamically

    //var addressId = $("#AddressId").val();
    var ownerId = $("#StudentId").val();

    //ajax call goes here
    $.ajax({
      type: "GET",
      dataType: "html",
      url: "/Address/GetAddressEditor",
      data: { "addressId": null, "ownerId" : ownerId },
      success: function (response) {
        //put the editor on the page
        $("#AddressEdit").html(response);
      },
      error: function (response) {
        //throw up an alert
        alert("Error loading address editor!");
      },
    });

    //this stops form submission
    return false;
  });

  //using document on click instead of the button, because the button doesn't exist when the page loads
  
  $(document).on("click", "#btnSaveAddress", function () {
    var addressJson = {
      OwnerId: $("#AddressEdit").find("#OwnerId").val(),
      AddressId: $("#AddressEdit").find("#AddressId").val(),
      IsPrimary: $("#AddressEdit").find("#IsPrimary").prop("checked"),
      Address1: $("#AddressEdit").find("#Address1").val(),
      Address2: $("#AddressEdit").find("#Address2").val(),
      City: $("#AddressEdit").find("#City").val(),
      State: $("#AddressEdit").find("#State").val(),
      ZipCode: $("#AddressEdit").find("#ZipCode").val()
    };

    $.ajax({
      type: "POST",
      contentType: "application/json; charset=utf-8",
      dataType: "html",
      url: "/Student/EditAddress",
      data: JSON.stringify({ addressModel: addressJson }),
      success: function (response) {
        //put the display on the page
        $("#AddressDisplay").append(response);
        //remove the editor contents
        $("#AddressEdit").html("");
      },
      error: function (response) {
        //throw up an alert
        alert("Error saving address!");
      },
    });

    //this stops form submission
    return false;
  });
});
