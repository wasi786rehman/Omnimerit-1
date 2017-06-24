

$(document).ready(function () {
    //debugger;
    AccountGroupInit();
});
var AccountGrp;
function Error() {

}
function AccountGroupInit() {
    debugger;
    post("GetAccountGroup", AccountGroupSuccess, AccountGroupSuccess)
}


function AccountGroupSuccess(data) {
    //alert(data);
    AccountGrp = data;
    var iconrender = function (data, type, row) {
        debugger;
        return '<span class="glyphicon glyphicon-edit" id="editbtn" onclick="EditAccountGroup(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" id="deletebtn" onclick="DeleteAccountGroup(' + row.Id + ')"></span>';
    }
    $('#result').DataTable({
        "scrollX": true,
        "data": data,
        "aoColumns": [
            { "mData": "Id", "visible": false, "searchable": false },
              { "mData": "AccountName", "sTitle": "Account Name" },
                     { "mData": "GroupUnder", "sTitle": "Group Under" },
                      { "mData": "Status", "sTitle": "Status" },
                      {
                          "render": iconrender
                      }

        ]
    });
}

function EditAccountGroup(rowData) {
    debugger;

    $.each(AccountGrp, function (index, value) {
        if (value.Id == rowData) {

            $('#AccName').val(value.AccountName);
            $('#grpunder').val(value.GroupUnder);
            $('#idlabel').val(value.Id);
                //var sth = $('#idlabel').text();
                //$.post("~/Employee/AddAccountGroup", { x: sth });

            }

        
    });
}


//function DeleteAccountGroup(rowData) {
//    debugger;
    
//    var x = confirm("Are you sure you want to delete " + rowData + "?");
//    if (x) {


//        var dataa = { Id: rowData };
//        //function post(Employee/DeleteAccountGrp', dataa, Deletesuccess, Deleteerror) {
//        //    debugger;
//        //    $.ajax({
//        //        url: url,
//        //        //contentType: "json",
//        //        //data:dataa,
//        //        //dataType: "json",
//        //        success: Deletesuccess,
//        //        error: Deleteerror
//        //    });
//        $.ajax({
              
//                method: "post",
//                url: "Employee/DeleteAccountGrp",
//               // contentType: "json",
//                //data: dataa,
//                dataType: "json",
//                success: Deletesuccess,
//                error: Deleteerror

//            });

        
//    }
//    else {
//        return false;
//    }
//}

function DeleteAccountGroup(rowData) {
    debugger;
    if (confirm("Are You Sure Delete Selected Account Group? " + rowData)) {
        var data = { 'Id': rowData }
        $.post('/Employee/DeleteAccountGrp', data,
        function (data) {
            if (data == true) {
               // location = location.href;
               
            }
            
        });
        alert(" successfully deleted!");
        var table = $('#result').DataTable();
        table.destroy();
        $('#result').empty();
        AccountGroupInit();
    }
   
else {
        alert("Not delete something Wrong");
}
}
        //function Deletesuccess() {
           
        //}
        //function Deleteerror() {
        //    alert("error deleted");
        //}
    
    //else {
    //    return false;

    //}


    
    


       
