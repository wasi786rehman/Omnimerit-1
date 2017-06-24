

$(document).ready(function () {
    //debugger;
    TransportAllocationInit();
});
var Transallocation;
function Error() {

}
function TransportAllocationInit() {
    debugger;
    post("GetTransportAllocation", TransportAllocationSuccess, TransportAllocationSuccess)
}


function TransportAllocationSuccess(data) {
   // alert(data);
    var data = JSON.parse(data);
    Transallocation = data;
    var iconrender = function (data, type, row) {
        debugger;
        return '<span class="glyphicon glyphicon-edit" id="editbtn" onclick="EditTransportAllocation(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" id="deletebtn" onclick="DeleteTransportAllocation(' + row.Id + ')"></span>';
    }
    $('#result').DataTable({
        "scrollX": true,
        "data": data,
        "aoColumns": [
           
              { "mData": "RouteCode", "sTitle": "Route Code" },
                     { "mData": "Source", "sTitle": "Source" },
                      { "mData": "Destination", "sTitle": "Destination" },
                        { "mData": "UserName", "sTitle": "Name" },
                       { "mData": "StartDate", "sTitle": "Start Date" },
                         { "mData": "EndDate", "sTitle": "End Date" },
                      {
                          "render": iconrender
                      }
        ]
    });
}

function EditTransportAllocation(rowData) {
    debugger;

    $.each(Transallocation, function (index, value) {
        if (value.Id == rowData) {
            $('#routecode').val(value.RouteCode);
            $('#source').val(value.Source);
            $('#destination').val(value.Destination);
            $('#user').val(value.UserType);
            $('#username').val(value.UserName);
            $('#startdate').val(value.StartDate);
            $('#enddate').val(value.EndDate);
            $('#idlabel').val(value.Id);
        }
    });
}

function DeleteTransportAllocation(rowData) {
    debugger;
    if (confirm("Are You Sure to Delete? " + rowData)) {
        var data = { 'Id': rowData }
        $.post('/Employee/DeleteTransportAllocation', data,
        function (data) {
            if (data == true) {
                // location = location.href;
            }

        });
        alert(" successfully deleted!");
        var table = $('#result').DataTable();
        table.destroy();
        $('#result').empty();
        TransportAllocationInit();
    }

    else {
        alert("Not delete something Wrong");
    }
}