

$(document).ready(function () {
    //debugger;
  FeeCategoryInit();
});
var FeeCategory;
function Error() {

}
function FeeCategoryInit() {
    debugger;
    post("GetFeeCategory", FeeCategorySuccess, FeeCategorySuccess)
}


function FeeCategorySuccess(data) {
    //alert(data);
    FeeCategory = data;
    var iconrender = function (data, type, row) {
        debugger;
        return '<span class="glyphicon glyphicon-edit" id="editbtn" onclick="EditFeeCategory(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" id="deletebtn" onclick="DeleteFeeCategory(' + row.Id + ')"></span>';
    }
    $('#result').DataTable({
        "scrollX": true,
        "data": data,
        "aoColumns": [
              { "mData": "FeeCategory1", "sTitle": "Fee Category" },
                     { "mData": "ReceiptPrefix", "sTitle": "Receipt No" },
                      { "mData": "Description", "sTitle": "Des" },
                      {
                          "render": iconrender
                      }

        ]
    });
}

function EditFeeCategory(rowData) {
    debugger;

    $.each(FeeCategory, function (index, value) {
        if (value.Id == rowData) {

            $('#feecatgry').val(value.FeeCategory1);
            $('#Receiptno').val(value.ReceiptPrefix);
            $('#descrptn').val(value.Description);
            $('#idlabel').val(value.Id);

        }


    });
}


function DeleteFeeCategory(rowData) {
    debugger;
    if (confirm("Are You Sure Delete Selected Fee Category? " + rowData)) {
        var data = { 'Id': rowData }
        $.post('/Employee/DeleteFeeCategory', data,
        function (data) {
            if (data == true) {
                // location = location.href;

            }

        });
        alert(" successfully deleted!");
        var table = $('#result').DataTable();
        table.destroy();
        $('#result').empty();
        FeeCategoryInit();
    }

    else {
        alert("Not delete something Wrong");
    }
}







