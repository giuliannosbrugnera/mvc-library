$(document).ready(function () {
    var pathname = window.location.pathname; // Returns path only
    console.log("pathname: " + pathname);

    // Call the DataTables plugin.
    $("table").dataTable();
});
