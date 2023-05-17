$(document).ready(function () {
    // Generate specified amount of input boxes for adding employees 
    $(document).on('change', "#NumberOfEmployeesInput", function () {
        var employeeCount = document.getElementById('NumberOfEmployeesInput').value;
        var employeesTable = document.getElementById('employeesTable');
        var employeeRows = employeesTable.getElementsByTagName('tr');

        LeaveOneRowOnly(employeeRows);

        for (var i = 0; i < employeeCount - 1; i++) {
            var rowOuterHtml = employeeRows[employeeRows.length - 1].outerHTML;
            var lastRowIndex = document.getElementById('LastIndex').value;

            var nextRowIndex = parseInt(lastRowIndex) + 1;

            document.getElementById('LastIndex').value = nextRowIndex;
            rowOuterHtml = rowOuterHtml.replaceAll('_' + lastRowIndex + '_', '_' + nextRowIndex + '_');
            rowOuterHtml = rowOuterHtml.replaceAll('-' + lastRowIndex + '_', '-' + nextRowIndex + '_');
            rowOuterHtml = rowOuterHtml.replaceAll('[' + lastRowIndex + ']', '[' + nextRowIndex + ']');
            rowOuterHtml = rowOuterHtml.replaceAll('_' + lastRowIndex, '_' + nextRowIndex);

            var newRow = employeesTable.insertRow();
            newRow.innerHTML = rowOuterHtml;
        }
    });
});

function LeaveOneRowOnly(employeeRows) {

    // Start iterating from the third row and remove remaining ones 
    for (var i = employeeRows.length - 1; i >= 2; i--) {
        employeesTable.removeChild(employeeRows[i]);
    }
}

function addDepartment() {
    $.ajax({
        type: "Get",
        url: "/Departments/Create",
        success: function (result) {
            $("#modalContainer").html(result);
            $("#addDepartment").modal('show');
        }
    })
}

