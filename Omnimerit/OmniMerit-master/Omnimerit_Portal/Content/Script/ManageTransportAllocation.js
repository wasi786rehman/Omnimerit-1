function getNameList() {
    debugger;
    var user = $("#user").val();
    $.ajax({
        url: 'GetUserNameList',
        type: "post",
        //datatype: 'application/json',
        //contentType: 'application/json',
        //    data: JSON.stringify({
        //        UserType: +UserType
        
        //}),

        data:{'UserType':user},
            
        success: function (result) {
            debugger;
            $("#username").html("");

            var items = "";
            items += "<option value='' disabled selected>Please select</option>";
            $.each(result, function (i, rowdata) {
                items += "<option value='" + rowdata.Id + "'>" + (rowdata.UserName) + "</option>";

            //$.each(result, function (i, rowdata) {
          
            //    $("#username").append($('<option></option>').val(rowdata.Id).html(rowdata.UserName))
            })
            $("#username").html(items);
           

            //var optId = $(this).find('option:selected').attr('Id');
            //$('#idlabel').val(optId);

        },
        error: function () {
            alert("Whooaaa! Something went wrong..")
        },
    });
}

function GetId() {
    debugger;
    var id = $("#username").val();
   
    $('#idlabel').val(id);
}
   
    
    //$('#jobSel option:selected').attr("Id");
