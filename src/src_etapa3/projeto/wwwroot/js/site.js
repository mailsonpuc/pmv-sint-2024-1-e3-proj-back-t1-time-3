// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const asc_escuro = document.getElementById("esc_escuro");
const nav = document.querySelector("nav");



asc_escuro.addEventListener("click", myFunction);
function myFunction() {

    if(nav.className.includes("bg-white")) {
     
      document.querySelector("nav").className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-info bg-gradient border-bottom box-shadow mb-3";
    }
    
    
    asc_escuro.innerHTML='visibility_on';
    document.body.style.backgroundColor = "#696969";

   
    
}