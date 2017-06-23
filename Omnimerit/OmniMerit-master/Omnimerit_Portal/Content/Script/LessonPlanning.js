

$(document).ready(function () {
    //debugger;
    LessonPlanningInit();
});
var Lessonplan;
function Error() {

}
function LessonPlanningInit() {
    debugger;
    post("GetLessonPlanning", LessonPlanningSuccess, LessonPlanningSuccess)
}


function LessonPlanningSuccess(data) {
    //alert(data);
    Lessonplan = data;
    var iconrender = function (data, type, row) {
        debugger;
        return '<span class="glyphicon glyphicon-edit" id="editbtn" onclick="EditLessonPlanning(' + row.Id + ')"></span> &nbsp&nbsp<span class="glyphicon glyphicon-remove-sign" id="deletebtn" onclick="DeleteLessonPlanning(' + row.Id + ')"></span>';
    }
    $('#result').DataTable({
        "scrollX": true,
        "data": data,
        "aoColumns": [
            { "mData": "Id", "visible": false, "searchable": false },
              { "mData": "Lect_Code", "sTitle": "Lect_Code" },
                     { "mData": "Course", "sTitle": "Course" },
                      { "mData": "Batch", "sTitle": "Batch" },
                       { "mData": "Subject", "sTitle": "Subject" },
                      {
                          "render": iconrender
                      }

        ]
    });
}

function EditLessonPlanning(rowData) {
    debugger;

    $.each(Lessonplan, function (index, value) {
        if (value.Id == rowData) {

            $('#course').val(value.Course);
            $('#batch').val(value.Batch);
            $('#sub').val(value.Subject);
            $('#lecturecode').val(value.Lect_Code);
            $('#idlabel').val(value.Id);
        }
    });
}


function DeleteLessonPlanning(rowData) {
    debugger;
    if (confirm("Are You Sure to Delete? " + rowData)) {
        var data = { 'Id': rowData }
        $.post('/Employee/DeleteLessonPlanning', data,
        function (data) {
            if (data == true) {
                // location = location.href;

            }

        });
        alert(" successfully deleted!");
        var table = $('#result').DataTable();
        table.destroy();
        $('#result').empty();
        LessonPlanningInit();
    }

    else {
        alert("Not delete something Wrong");
    }
}
function getExceldata() {
    debugger;
    var cour = $("#rcourse").val();
    var batch = $("#rbatch").val();
    var sub = $("#rsub").val();
    if ((cour != "Please Select") && (batch != "Please Select") && (sub != "Please Select")) {
        $.ajax({
            url: 'GetExcelData',
            type: "post",
            data: { 'Cour': cour, 'batch': batch, 'subj': sub },

            success: function (values) {
                debugger;
                $('#result2').DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        {
                            extend: 'copyHtml5',
                            exportOptions: {
                                columns: ':contains("Office")'
                            }
                        },
                        'excelHtml5'

                    ],
                    "scrollX": true,
                    "data": values,
                    "aoColumns": [
                        { "mData": "Id", "visible": false, "searchable": false },
                          { "mData": "Lect_Code", "sTitle": "Lecture Code" },
                                 { "mData": "Course", "sTitle": "Course" },
                                  { "mData": "Batch", "sTitle": "Batch" },
                                   { "mData": "Subject", "sTitle": "Subject" },


                    ]
                });

            },
            error: function () {
                alert("Whooaaa! Something went wrong..")
            },
        });
    }
    else
        alert("Please Select Valid Course,Batch and Subject")
}
