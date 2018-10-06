function exibir_msn(tipo, msn) {
    if (tipo == 's') {
        divMsn.setAttribute("class", "msn-sucesso msn-dim");
        h3Msn.innerText = "Sucesso!";
        pMsn.innerText = msn;
    }
    if (tipo == 'a') {
        divMsn.setAttribute("class", "msn-atencao msn-dim");
        h3Msn.innerText = "Atenção!";
        pMsn.innerText = msn;
    }
    if (tipo == 'e') {
        divMsn.setAttribute("class", "msn-erro msn-dim");
        h3Msn.innerText = "Erro!";
        pMsn.innerText = msn;
    }
    window.scrollTo(0, 0);
}
function menu(bloco) {
    if (document.getElementById(bloco).getAttribute("class") == "minimizar_menu") {
        document.getElementById(bloco).setAttribute("class", "maximinizar_menu");
    }
    else {
        document.getElementById(bloco).setAttribute("class", "minimizar_menu");
    }
}
function close_msn() {
    document.getElementById('msn').innerHTML = "";
    document.getElementById('msn').setAttribute("class", "invisible");
}

function MascaraCpf(campo) {
    if (campo.value.length == 3) { campo.value += '.'; }
    if (campo.value.length == 7) { campo.value += '.'; }
    if (campo.value.length == 11) { campo.value += '-'; }
}
function MascaraData(campo) {

    if (campo.value.length == 2) { campo.value += '/'; }
    if (campo.value.length == 5) { campo.value += '/'; }
}
function MascaraTelefone(campo) {

    if (campo.value.length == 0) { campo.value += '('; }
    if (campo.value.length == 3) { campo.value += ')'; }
    if (campo.value.length == 4) { campo.value += ' '; }
    if (campo.value.length == 9) { campo.value += '-'; }
}
function MascaraCep(campo) {
    if (campo.value.length == 5) { campo.value += '-'; }
}
function menu(bloco) {
    if (document.getElementById(bloco).getAttribute("class") == "minimizar_menu") {
        document.getElementById(bloco).setAttribute("class", "maximinizar_menu");
    }
    else {
        document.getElementById(bloco).setAttribute("class", "minimizar_menu");
    }
}
function close_msn() {
    document.getElementById('msn').innerHTML = "";
    document.getElementById('msn').setAttribute("class", "invisible");
}
