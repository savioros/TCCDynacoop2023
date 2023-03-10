using Microsoft.Xrm.Sdk.Client;
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
    internal class Product
    {
        public CrmServiceClient ServiceClient { get; set; }

        public string Logicalname { get; set; }

        public Product(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.Logicalname = "product";
        }
        public Entity GetProductByName(Guid name, string[] columns)
        {
            return ServiceClient.Retrieve("product", name, new ColumnSet(columns));
        }
        public Guid CreateInDynacoop2(string productName, string productNumber, string productId, string description)
        {

            Entity product = new Entity("product");
            product["Name"] = productName;
            product["ProductNumber"] = productNumber;
            product["ProductId"] = productId;
            product["Description"] = description;

            return this.ServiceClient.Create(product);
        }



    }
}
