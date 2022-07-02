// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function Search() {
    var value = document.getElementById("SearchText").value;
    window.location.href = "https://"+window.location.host+"?title=" + value;
}
