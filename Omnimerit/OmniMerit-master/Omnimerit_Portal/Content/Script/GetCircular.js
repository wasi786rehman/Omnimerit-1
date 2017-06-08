


$(document).ready(function () {
    
 CircularInit(); 
});
var Circular;
function Error()
{

}
function CircularInit()
{
  
    post("GetCircular", CircularSuccess, CircularSuccess)
}


function CircularSuccess(data) {
    alert(data);
    var data = JSON.parse(data);
    Circular = data;
    var iconrender = function (data, type, row) {
      
        return '<span class="glyphicon glyphicon-edit" id="editbtn" onclick="EditCircular(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" onclick="DeleteCircular(' + row.Id + ')"></span>';

    }

    $('#tabular').DataTable({
        
        "data": data,
        "aoColumns": [  
         
              
              { "mData": "Subject", "sTitle": "Subject" },
              { "mData": "Reference_Number", "sTitle": "Reference No" },
              { "mData": "Content", "sTitle": "Content" },
              {"mData":"Date", "sTitle": "Circular Date"},
                  
            {
            "render": iconrender
            }
        
]  
    });
}
function EditCircular(rowData) {
    debugger;

    $.each(Circular, function (index, value) {
        if (value.Id== rowData) {
           
            alert('yes, the click actually happened');

          // $('.nav-tabs bar_tabs a[href="#Circular"]').tab('show');
              
         
               //$('[href="#Circular"]').tab('show');

               $('#subject').val(value.Subject);
               $('#reference_no').val(value.Reference_Number);
               $('#editor-one').html(value.Content);
               $('#datte').val(value.Date);
            activaTab('Circular');
              
        } 
    });
}



function activaTab(tab){
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};

