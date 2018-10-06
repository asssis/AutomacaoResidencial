function close_msn() {
    document.getElementById('msn').innerHTML = "";
    document.getElementById('msn').setAttribute("class", "invisible");
}
function exibir_msn(tipo, msn) {
    if (tipo == 's') {
        divMsn.setAttribute("class", "msn-sucesso");
        h3Msn.innerText = "Sucesso!";
        pMsn.innerText = msn;
    }
    if (tipo == 'a') {
        divMsn.setAttribute("class", "msn-atencao");
        h3Msn.innerText = "Atenção!";
        pMsn.innerText = msn;
    }
    if (tipo == 'e') {
        divMsn.setAttribute("class", "msn-erro");
        h3Msn.innerText = "Erro!";
        pMsn.innerText = msn;
    }

    window.scrollTo(0, 0);
}
function MascaraHora(campo) {

    if (campo.value.length == 2) { campo.value += ':'; }
}