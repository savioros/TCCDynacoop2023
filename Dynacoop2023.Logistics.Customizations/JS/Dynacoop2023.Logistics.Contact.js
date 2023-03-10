if (typeof (TccDynacoop) == "undefined") { TccDynacoop = {} }
if (typeof (TccDynacoop.Contact) == "undefined") { TccDynacoop.Contact = {} }

TccDynacoop.Contact = {
	CpfOnChange: function (executionContext) {

		var formContext = executionContext.getFormContext();

		var cpfValue = formContext.getAttribute("cr252_cpf").getValue();

		if (cpfValue == null) {
			DynamicsAlert("Fill in the CPF", "CPF EMPTY");
		}
		else {
			if (validarCPF(cpfValue) == true) {
				DynamicsAlert("Filled CPF is valid", "VALID CPF");
			}
			else {
				DynamicsAlert("Filled CPF is invalid", "INVALID CPF");
			}

			function validarCPF(cpf) {
				cpf = cpf.replace(/[^\d]+/g, '');
				if (cpf == '') return false;

				if (cpf.length != 11 ||
					cpf == "00000000000" ||
					cpf == "11111111111" ||
					cpf == "22222222222" ||
					cpf == "33333333333" ||
					cpf == "44444444444" ||
					cpf == "55555555555" ||
					cpf == "66666666666" ||
					cpf == "77777777777" ||
					cpf == "88888888888" ||
					cpf == "99999999999")
					return false;

				add = 0;
				for (i = 0; i < 9; i++)
					add += parseInt(cpf.charAt(i)) * (10 - i);
				rev = 11 - (add % 11);
				if (rev == 10 || rev == 11)
					rev = 0;
				if (rev != parseInt(cpf.charAt(9)))
					return false;

				add = 0;
				for (i = 0; i < 10; i++)
					add += parseInt(cpf.charAt(i)) * (11 - i);
				rev = 11 - (add % 11);
				if (rev == 10 || rev == 11)
					rev = 0;
				if (rev != parseInt(cpf.charAt(10)))
					return false;
				return true;
			}
		}

		function DynamicsAlert(alertText, alertTitle) {
			var alertStrings = {
				confirmButtonLabel: "OK",
				text: alertText,
				title: alertTitle
				};

			var alertOptions = {
				heigth: 120,
				width: 200
				};

				Xrm.Navigation.openAlertDialog(alertStrings, alertOptions);
				}

		

	}

}