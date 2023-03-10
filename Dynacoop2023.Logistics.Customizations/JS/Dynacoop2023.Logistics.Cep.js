if (typeof (AlfaPeople) == "undefined") { AlfaPeople = {} }
if (typeof (AlfaPeople.Account) == "undefined") { AlfaPeople.Account = {} }


AlfaPeople.Account = {
    OnLoad: function (executionContext) {
        var formContext = executionContext.getFormContext();

    },
    function cleanCep() {
    //Limpa valores do formulário de cep.
    formContext.getAttribute('Address1_Line1').setValue("");
    formContext.getAttribute('Address1_Line2').setValue("");
    formContext.getAttribute('Address1_City').setValue("");
    formContext.getAttribute('Address1_StateOrProvince').setValue("");
},

function callBack(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        formContext.getAttribute('Address1_Line1').setValue(conteudo.logradouro);
        formContext.getAttribute('Address1_Line2').setValue(conteudo.Address1_Line2);
        formContext.getAttribute('Address1_City').setValue(conteudo.localidade);
        formContext.getAttribute('Address1_StateOrProvince').setValue(conteudo.Address1_StateOrProvince);
    } //end if.
    else {
        //CEP não Encontrado.
        cleanCep();
        alert("CEP não encontrado.");
    }
},

GetSet: function searchCep() {
    var cepReceived = formContext.getAttribute("Address1_PostalCode").getValue();

    //Nova variável "cep" somente com dígitos.
    var cep = cepReceived.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep != "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            formContext.getAttribute('Address1_Line1').setValue("...");
            formContext.getAttribute('Address1_Line2').setValue("...");
            formContext.getAttribute('Address1_City').setValue("...");
            formContext.getAttribute('Address1_StateOrProvince').setValue("...");

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
