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
    public class Account
    {
        public IOrganizationService ServiceClient;
        public Account(CrmServiceClient serviceClient)
        {
            this.ServiceClient = serviceClient;
        }

        public Account(IOrganizationService serviceClient)
        {
            this.ServiceClient = serviceClient;
        }

        public Guid CreateAccount(string accountName, string accountCnpj)
        {
            Entity account = new Entity("account");
            account["name"] = accountName;
            account["cr252_cnpj2"] = accountCnpj;

            return this.ServiceClient.Create(account);
        }

        public bool GetAccountByCnpj(string cnpj)
        {
            QueryExpression queryExpression = new QueryExpression("account");
            queryExpression.ColumnSet.AddColumn("name");
            queryExpression.Criteria.AddCondition("cr252_cnpj2", ConditionOperator.Equal, cnpj);
            EntityCollection account = this.ServiceClient.RetrieveMultiple(queryExpression);

            if (account.Entities.Count > 0)
                return true;
            else
                return false;
        }
    }
}
