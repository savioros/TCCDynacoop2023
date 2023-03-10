using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Model
{
    public class Contact
    {
        public IOrganizationService ServiceClient { get; set; }

        public Contact(CrmServiceClient serviceClient)
        {
            this.ServiceClient = serviceClient;
        }

        public Contact(IOrganizationService serviceClient)
        {
            this.ServiceClient = serviceClient;
        }

        public Guid CreateContact(string contactName, string contactCpf)
        {
            Entity contact = new Entity();
            contact["lastname"] = contactName;
            contact["cr252_cpf"] = contactCpf;
            return ServiceClient.Create(contact);
        }

        public bool GetContactByCpf(string cpf)
        {
            QueryExpression queryExpression = new QueryExpression("contact");
            queryExpression.ColumnSet.AddColumn("lastname");
            queryExpression.Criteria.AddCondition("cr252_cpf", ConditionOperator.Equal, cpf);
            EntityCollection contact = this.ServiceClient.RetrieveMultiple(queryExpression);

            if (contact.Entities.Count > 0)
                return true;
            else
                return false;
        }
    }
}
