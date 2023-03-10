using Dynacoop2023.Logistics.MyFirstPlugins.Controller;
using Dynacoop2023.Logistics.MyFirstPlugins.DynacoopISV;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace Dynacoop2023.Logistics.MyFirstPlugins
{
    public class OpportunityManager : PluginCore
    {

        protected override void ExecutePlugin(IServiceProvider serviceProvider)
        {
            this.TracingService.Trace("Inicio");

            Entity opportunity = (Entity)this.Context.InputParameters["Target"];
            string identifier = NumericGenerator();

            OpportunityController opportunityController = new OpportunityController(this.Service);
            EntityCollection validateidentifier = opportunityController.Validateidentifier(identifier);

            if (validateidentifier.Entities.Count() > 0)
            {
                identifier = NumericGenerator();
            }
            opportunity["cr252_opportunity_identifier"] = identifier;
            this.TracingService.Trace("A variavel foi atribuída ao identifier");
            this.TracingService.Trace("Criando identifier");

        }

        public string NumericGenerator()
        {
            string identifier = "OPP-" + RandomNumber(5) + "-" + RandomLetter(1) + RandomNumber(1) + RandomLetter(1) + RandomNumber(1);
            return identifier;
        }

        public string RandomLetter(int size)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, size)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public string RandomNumber(int size)
        {
            var chars = "0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, size)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

    }
}
