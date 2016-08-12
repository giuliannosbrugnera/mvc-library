$(document).ready(function () {
    var pathname = window.location.pathname; // Returns path only
    console.log("pathname: " + pathname);

    // Call the DataTables plugin.
    $("table").dataTable({
        // Disable sorting on last column, where the buttons reside
        "columnDefs": [{ orderable: false, targets: -1 }],
        "lengthMenu": [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "All"]]
    });
});
