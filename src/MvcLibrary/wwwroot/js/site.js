$(document).ready(function () {
    var pathname = window.location.pathname; // Returns path only
    console.log("pathname: " + pathname);

    // Call the tablesorter plugin.
    $("table").tablesorter({
        theme: "bootstrap"
    });
});
