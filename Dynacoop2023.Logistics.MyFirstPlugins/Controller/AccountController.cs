using Dynacoop2023.Logistics.MyFirstPlugins.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Controller
{
    public class AccountController
    {
        public IOrganizationService ServiceClient;
        public Account Account { get; set; }

        public AccountController(CrmServiceClient serviceClient)
        {
            this.ServiceClient = serviceClient;
            this.Account = new Account(serviceClient);
        }

        public AccountController(IOrganizationService serviceClient)
        {
            this.ServiceClient = serviceClient;
            this.Account = new Account(serviceClient);
        }

        public Guid CreateAccount(string accountName, string accountCnpj)
        {
            return Account.CreateAccount(accountName, accountCnpj);
        }

        public bool GetAccountByCnpj(string cnpj)
        {
            return Account.GetAccountByCnpj(cnpj);
        }
    }
}
