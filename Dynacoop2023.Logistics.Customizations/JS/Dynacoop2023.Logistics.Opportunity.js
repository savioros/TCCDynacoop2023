if (typeof (TccDynacoop) == "undefined") { TccDynacoop = {} }
if (typeof (TccDynacoop.Opportunity) == "undefined") { TccDynacoop.Opportunity = {} }

TccDynacoop.Opportunity = {
	Ribbon: {
		Clone: function (formContext) {
			var id = Xrm.Page.data.entity.getId();

			var execute_cr252_Cloneopportunity_Request = {
				// Parameters
				entity: { entityType: "opportunity", id: id },
				OpportunityId: id,

				getMetadata: function () {
					return {
						boundParameter: "entity",
						parameterTypes: {
							entity: { typeName: "mscrm.opportunity", structuralProperty: 5 },
							OpportunityId: { typeName: "Edm.String", structuralProperty: 1 }
						},
						operationType: 0, operationName: "cr252_Cloneopportunity"
					};
				}
			};

			Xrm.WebApi.execute(execute_cr252_Cloneopportunity_Request).then(
				function success(response) {
					if (response.ok) { return response.json(); }
				}
			).then(function (responseBody) {
				var result = responseBody;
				// Return Type: mscrm.cr252_CloneopportunityResponse
				// Output Parameters
				var newopportunityid = result["NewOpportunityId"];
				window.open(`https://orge54c24c3.crm2.dynamics.com/main.aspx?appid=8ae4c66a-0db0-ed11-9884-000d3a888d06&forceUCI=1&pagetype=entityrecord&etn=opportunity&id=${newopportunityid}`, '_blank');
			}).catch(function (error) {
				console.log(error.message);
			});
		}
	}
}