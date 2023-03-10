using Dynacoop2023.Logistics.MyFirstPlugins.Controller;
using Dynacoop2023.Logistics.MyFirstPlugins.DynacoopISV;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Plugins
{
    public class AccountManager : PluginCore
    {
        protected override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            AccountController accountController = new AccountController(this.Service);

            Entity account = new Entity();

            if (this.Context.MessageName == "Create" || this.Context.MessageName == "Update")
            {
                account = (Entity)this.Context.InputParameters["Target"];
                string cnpj = (string)account["cr252_cnpj2"];
                bool accountWithCnpj = accountController.GetAccountByCnpj(cnpj);

                if (accountWithCnpj)
                {
                    throw new InvalidPluginExecutionException("An account already exists with this CNPJ");
                }
            }
        }
    }
}
