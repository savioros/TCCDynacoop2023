if (typeof (AlfaPeople) == "undefined") { AlfaPeople = {} }
if (typeof (AlfaPeople.Account) == "undefined") { AlfaPeople.Account = {} }


AlfaPeople.Account = {
    OnLoad: function (executionContext) {
        var formContext = executionContext.getFormContext();

    },
    function cleanCep() {
    //Limpa valores do formulário de cep.
    formContext.getAttribute('rua').setValue("");
    formContext.getAttribute('bairro').setValue("");
    formContext.getAttribute('cidade').setValue("");
    formContext.getAttribute('uf').setValue("");
    formContext.getAttribute('ibge').setValue("");
},

function callBack(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        formContext.getAttribute('rua').setValue(conteudo.logradouro);
        formContext.getAttribute('bairro').setValue(conteudo.bairro);
        formContext.getAttribute('cidade').setValue(conteudo.localidade);
        formContext.getAttribute('uf').setValue(conteudo.uf);
        formContext.getAttribute('ibge').setValue(conteudo.ibge);
    } //end if.
    else {
        //CEP não Encontrado.
        cleanCep();
        alert("CEP não encontrado.");
    }
},

GetSet: function searchCep() {
    var cepReceived = formContext.getAttribute("cep").getValue();

    //Nova variável "cep" somente com dígitos.
    var cep = cepReceived.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            formContext.getAttribute('rua').setValue("...");
            formContext.getAttribute('bairro').setValue("...");
            formContext.getAttribute('cidade').setValue("...");
            formContext.getAttribute('uf').setValue("...");
            formContext.getAttribute('ibge').setValue("...");

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            cleanCep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        cleanCep();
    }
}
}
