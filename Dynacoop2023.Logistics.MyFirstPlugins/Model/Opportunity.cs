using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System.Linq;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Model
{
    public class Opportunity
    {
        public IOrganizationService ServiceClient { get; set; }

        public string Logicalname { get; set; }

        public Opportunity(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.Logicalname = "opportunity";
        }

        public EntityCollection Validateidentifier(string identifier)
        {
            QueryExpression validateidentifier = new QueryExpression("opportunity");
            validateidentifier.ColumnSet.AddColumn("opportunityid");
            validateidentifier.Criteria.AddCondition("cr252_opportunity_identifier", ConditionOperator.Equal, identifier);
            EntityCollection retornoQuery = this.ServiceClient.RetrieveMultiple(validateidentifier);

            if (retornoQuery.Entities.Count() > 0)
            {
                return null;
            }
            return retornoQuery;
        }

    }
}
