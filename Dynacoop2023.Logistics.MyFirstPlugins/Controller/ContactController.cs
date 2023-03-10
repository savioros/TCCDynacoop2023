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
    public class ContactController
    {
        public IOrganizationService ServiceClient { get; set; }
        public Contact Contact { get; set; }

        public ContactController(CrmServiceClient serviceClient)
        {
            this.ServiceClient = serviceClient;
            this.Contact = new Contact(serviceClient);
        }

        public ContactController(IOrganizationService serviceClient)
        {
            this.ServiceClient = serviceClient;
            this.Contact = new Contact(serviceClient);
        }

        public Guid CreateContact(string contactName, string contactCpf)
        {
            return Contact.CreateContact(contactName, contactCpf);
        }

        public bool GetContactByCpf(string cpf)
        {
            return Contact.GetContactByCpf(cpf);
        }
    }
}
