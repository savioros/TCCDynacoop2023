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
    public class ContactManager : PluginCore
    {
        protected override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            ContactController contactController = new ContactController(this.Service);

            Entity account = new Entity();

            if (this.Context.MessageName == "Create" || this.Context.MessageName == "Update")
            {
                account = (Entity)this.Context.InputParameters["Target"];
                string cpf = (string)account["cr252_cpf"];
                bool contactWithCpf = contactController.GetContactByCpf(cpf);

                if (contactWithCpf)
                {
                    throw new InvalidPluginExecutionException("An contact already exists with this CPF");
                }
            }
        }
    }
}
