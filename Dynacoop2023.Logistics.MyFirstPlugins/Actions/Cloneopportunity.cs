using Dynacoop2023.Logistics.MyFirstPlugins.DynacoopISV;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Actions
{
    public class Cloneopportunity : ActionCore
    {
        [Input("OpportunityId")]
        public InArgument<string> OpportunityId { get; set; }

        [Output("NewOpportunityId")]
        public OutArgument<string> NewOpportunityId { get; set; }

        public override void ExecuteAction(CodeActivityContext context)
        {
            try
            {
                Entity opportunity = GetOpportunity(context);
                string newOpportunityId = CreateOpportunityClone(opportunity).ToString();

                this.NewOpportunityId.Set(context, newOpportunityId);
            }
            catch (Exception e)
            {
                throw new Exception("Error Action Clone Opportunity: " + e.Message);
            }
        }

        private Guid CreateOpportunityClone(Entity opportunity)
        {
            Entity newOpportunity = new Entity("opportunity");
            newOpportunity["name"] = opportunity["name"];
            newOpportunity["parentcontactid"] = opportunity["parentcontactid"];
            newOpportunity["parentaccountid"] = opportunity["parentaccountid"];
            newOpportunity["purchasetimeframe"] = opportunity["purchasetimeframe"];
            newOpportunity["transactioncurrencyid"] = opportunity["transactioncurrencyid"];
            newOpportunity["budgetamount"] = opportunity["budgetamount"];
            newOpportunity["purchaseprocess"] = opportunity["purchaseprocess"];
            newOpportunity["msdyn_forecastcategory"] = opportunity["msdyn_forecastcategory"];
            newOpportunity["description"] = opportunity["description"];

            return this.Service.Create(newOpportunity);
        }

        private Entity GetOpportunity(CodeActivityContext context)
        {
            return this.Service.Retrieve("opportunity", Guid.Parse(OpportunityId.Get(context)), new ColumnSet(true));
        }
    }
}
