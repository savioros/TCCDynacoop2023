using Dynacoop2023.Logistics.MyFirstPlugins.Model;
using Microsoft.Xrm.Sdk;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Controller
{
    public class OpportunityController
    {
        public IOrganizationService ServiceClient { get; set; }
        public Opportunity Opportunity { get; set; }

        public OpportunityController(IOrganizationService crmServiceCliente)
        {
            ServiceClient = crmServiceCliente;
            this.Opportunity = new Opportunity(ServiceClient);
        }
        public EntityCollection Validateidentifier(string identifier)
        {
            return Opportunity.Validateidentifier(identifier);
        }
    }
}
