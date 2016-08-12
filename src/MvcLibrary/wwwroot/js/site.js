$(document).ready(function () {
    var pathname = window.location.pathname; // Returns path only
    pathname = pathname.split("/");
    var id = "";

    $.each(pathname, function (key, value) {
        id += value + "-";
    });

    // remove classes from all
    $(".nav.navbar-nav > li").removeClass("active");

    // add class to the one the user clicked
    $("#" + id).addClass("active");

    // Call the DataTables plugin.
    $("table").dataTable({
        // Disable sorting on last column, where the buttons reside
        "columnDefs": [{ orderable: false, targets: -1 }],
        "lengthMenu": [[5, 10, 25, 50, 100, -1], [5, 10, 25, 50, 100, "All"]]
    });
});
