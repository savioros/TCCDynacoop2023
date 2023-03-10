if (typeof (TccDynacoop) == "undefined") { TccDynacoop = {} }
if (typeof (TccDynacoop.Account) == "undefined") { TccDynacoop.Account = {} }

TccDynacoop.Account = {
    CnpjOnChange: function (executionContext) {
        var formContext = executionContext.getFormContext();

        var cnpj = formContext.getAttribute("cr252_cnpj2").getValue();

        if (cnpj != null) {
            var onlyCnpjNumbers = cnpj.match(/\d/g).join("")

            if (cnpj.length >= 14) {
                const digits = onlyCnpjNumbers.slice(12)
                const verifyingDigit1 = TccDynacoop.Account.ValidateCnpj(12, onlyCnpjNumbers)
                const verifyingDigit2 = TccDynacoop.Account.ValidateCnpj(13, onlyCnpjNumbers)

                if (verifyingDigit1 == digits[0] && verifyingDigit2 == digits[1]) {
                    var formattedCNPJ = onlyCnpjNumbers.replace(/^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5")
                    var id = Xrm.Page.data.entity.getId();

                    var queryAccountId = "";

                    if (id.length > 0) {
                        queryAccountId += " and accountid ne " + id;
                    }

                    Xrm.WebApi.online.retrieveMultipleRecords("account", "?$select=name&$filter=cr252_cnpj2 eq '" + formattedCNPJ + "'" + queryAccountId).then(
                        function success(results) {
                            if (results.entities.length == 0) {
                                formContext.getAttribute("cr252_cnpj2").setValue(formattedCNPJ);
                            } else {
                                TccDynacoop.Account.DynamicsAlert("The CNPJ already exists in the system", "Duplicate CNPJ!")
                            }
                        },
                        function (error) {
                            TccDynacoop.Account.DynamicsAlert("Please contact the administrator", "System error!")
                        }
                    );
                } else {
                    TccDynacoop.Account.DynamicsAlert("The CNPJ entered is not valid", "Invalid CNPJ!")
                }
            } else {
                TccDynacoop.Account.DynamicsAlert("CNPJ is incomplete", "Incomplete CNPJ!")
            }
        } else {
            TccDynacoop.Account.DynamicsAlert("Enter a value for the CNPJ", "Incorrect CNPJ!")
        }
    },
    DynamicsAlert: function (alertText, alertTitle) {
        var alertStrings = {
            confirmButtonLabel: "OK",
            text: alertText,
            title: alertTitle
        };

        var alertOptions = {
            height: 120,
            width: 200
        };

        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
    },
    ValidateCnpj: function (x, cnpj) {
        const slice = cnpj.slice(0, x)
        let factor = x - 7
        let sum = 0

        for (let i = x; i >= 1; i--) {
            const n = slice[x - i]
            sum += n * factor--
            if (factor < 2) factor = 9
        }

        const result = 11 - (sum % 11)

        return result > 9 ? 0 : result
    }
}