$(document).ready(function ($) {
    $("#Telefone").mask("(99) 99999-9999");
});

$("#Telefone").on("blur", function() {
    var last = $(this).val().substr( $(this).val().indexOf("-") + 1 );

    if( last.length == 3 ) {
        var move = $(this).val().substr( $(this).val().indexOf("-") - 1, 1 );
        var lastfour = move + last;
        var first = $(this).val().substr( 0, 9 );

        $(this).val( first + '-' + lastfour );
    }
});

$('.btn-salvar-pessoa').on('click', function(e){
    debugger;
    let retorno = validaCampos();

    if(retorno !== ''){
        e.preventDefault();
        alert(retorno);
    }
});

function validaCampos(){
    var retorno = '';

    let nome = $('#Nome').val();
    let email = $('#Email').val();
    let telefone = $('#Telefone').val();

    var re = /^\w+([-+.'][^\s]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
    var emailFormat = re.test(email);

    debugger;

    if(nome === ''|| nome === undefined){
        retorno = 'Nome é obrigatório!';
    }
    else if(email === '' || nome === undefined){
        retorno = 'Email é obrigatório!';
    }
    else if(!emailFormat){
        retorno = 'E-mail inválido!';
    }
    else if(telefone === '' || telefone === undefined){
        retorno = 'Telefone é obrigatório!';
    }

    return retorno;
}
