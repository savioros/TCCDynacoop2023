using Dynacoop2023.Logistics.MyFirstPlugins.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Dynacoop2023.Logistics.MyFirstPlugins.Controller
{
    internal class ProductController
    {
        public IOrganizationService ServiceClient { get; set; }

        public Product Product { get; set; }

        public ProductController(IOrganizationService serviceClient)
        {
            ServiceClient = serviceClient;
            this.Product = new Product(ServiceClient);
        }

        public ProductController(CrmServiceClient serviceClient)
        {
            ServiceClient = serviceClient;
            this.Product = new Product(ServiceClient);
        }

        public Guid CreateInDynacoop2(string productName, string productNumber, string productId, string description)
        {
            return Product.CreateInDynacoop2(productName, productNumber, productId, description);
        }

    }
}
