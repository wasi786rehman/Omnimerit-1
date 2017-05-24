$(document).ready(function () {
    debugger;
    post("GetCircular", callback, callback)
});
function callback(data) {
    alert(data);

    $('#tabular').DataTable({

        "data": data,
        "aoColumns": [

             { "mData": "Subject", "sTitle": "Subject" },
             { "mData": "Reference_Number", "sTitle": "Reference No" },
              { "mData": "Content", "sTitle": "Content" },
              { "mData": "Date", "sTitle": "Circular Date" }

        ]
    });
}