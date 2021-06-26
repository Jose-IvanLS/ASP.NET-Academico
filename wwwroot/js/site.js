// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function testando() {
    let valor = "2014-02-09"
    let $teste = document.querySelector("#teste")
    $teste.innerHTML = valor;
}

function alterarData(ano, mes, dia) {
    let $dAniversario = document.getElementById("dataAniversario")
    $dAniversario.value = ano + "-" + mes + "-" + dia
    alert(ano + "-" + mes + "-" + dia)
}