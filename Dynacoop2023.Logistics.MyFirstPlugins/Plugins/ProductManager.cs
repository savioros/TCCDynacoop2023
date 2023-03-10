using Dynacoop2023.Logistics.MyFirstPlugins.Controller;
using Dynacoop2023.Logistics.MyFirstPlugins.DynacoopISV;
using Dynacoop2023.Logistics.MyFirstPlugins.Model;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Plugins
{
    public class ProductManager : PluginCore
    {
        protected override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            if (this.Context.MessageName == "Create") throw new InvalidPluginExecutionException("\r\nThe product cannot be registered in this environment");
        }
    }
}
