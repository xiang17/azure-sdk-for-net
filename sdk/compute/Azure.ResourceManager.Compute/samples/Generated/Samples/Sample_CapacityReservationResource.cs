// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Samples
{
    public partial class Sample_CapacityReservationResource
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Get_GetACapacityReservation()
        {
            // Generated from example definition: specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/examples/capacityReservationExamples/CapacityReservation_Get.json
            // this example is just showing the usage of "CapacityReservations_Get" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CapacityReservationResource created on azure
            // for more information of creating CapacityReservationResource, please refer to the document of CapacityReservationResource
            string subscriptionId = "{subscriptionId}";
            string resourceGroupName = "myResourceGroup";
            string capacityReservationGroupName = "myCapacityReservationGroup";
            string capacityReservationName = "myCapacityReservation";
            ResourceIdentifier capacityReservationResourceId = CapacityReservationResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, capacityReservationGroupName, capacityReservationName);
            CapacityReservationResource capacityReservation = client.GetCapacityReservationResource(capacityReservationResourceId);

            // invoke the operation
            CapacityReservationInstanceViewType? expand = CapacityReservationInstanceViewType.InstanceView;
            CapacityReservationResource result = await capacityReservation.GetAsync(expand: expand);

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CapacityReservationData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_CapacityReservationDeleteMaximumSetGen()
        {
            // Generated from example definition: specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/examples/capacityReservationExamples/CapacityReservation_Delete_MaximumSet_Gen.json
            // this example is just showing the usage of "CapacityReservations_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CapacityReservationResource created on azure
            // for more information of creating CapacityReservationResource, please refer to the document of CapacityReservationResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "rgcompute";
            string capacityReservationGroupName = "aaaaaaaaaaa";
            string capacityReservationName = "aaaaaaaaaaaaaaaaaaaaaaaaaaa";
            ResourceIdentifier capacityReservationResourceId = CapacityReservationResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, capacityReservationGroupName, capacityReservationName);
            CapacityReservationResource capacityReservation = client.GetCapacityReservationResource(capacityReservationResourceId);

            // invoke the operation
            await capacityReservation.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Delete_CapacityReservationDeleteMinimumSetGen()
        {
            // Generated from example definition: specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/examples/capacityReservationExamples/CapacityReservation_Delete_MinimumSet_Gen.json
            // this example is just showing the usage of "CapacityReservations_Delete" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CapacityReservationResource created on azure
            // for more information of creating CapacityReservationResource, please refer to the document of CapacityReservationResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "rgcompute";
            string capacityReservationGroupName = "aaa";
            string capacityReservationName = "aaaaaa";
            ResourceIdentifier capacityReservationResourceId = CapacityReservationResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, capacityReservationGroupName, capacityReservationName);
            CapacityReservationResource capacityReservation = client.GetCapacityReservationResource(capacityReservationResourceId);

            // invoke the operation
            await capacityReservation.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine("Succeeded");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CapacityReservationUpdateMaximumSetGen()
        {
            // Generated from example definition: specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/examples/capacityReservationExamples/CapacityReservation_Update_MaximumSet_Gen.json
            // this example is just showing the usage of "CapacityReservations_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CapacityReservationResource created on azure
            // for more information of creating CapacityReservationResource, please refer to the document of CapacityReservationResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "rgcompute";
            string capacityReservationGroupName = "aaaaaaaaaa";
            string capacityReservationName = "aaaaaaaaaaaaaaaaaaa";
            ResourceIdentifier capacityReservationResourceId = CapacityReservationResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, capacityReservationGroupName, capacityReservationName);
            CapacityReservationResource capacityReservation = client.GetCapacityReservationResource(capacityReservationResourceId);

            // invoke the operation
            CapacityReservationPatch patch = new CapacityReservationPatch
            {
                Sku = new ComputeSku
                {
                    Name = "Standard_DS1_v2",
                    Tier = "aaa",
                    Capacity = 7L,
                },
                Tags =
{
["key4974"] = "aaaaaaaaaaaaaaaa"
},
            };
            ArmOperation<CapacityReservationResource> lro = await capacityReservation.UpdateAsync(WaitUntil.Completed, patch);
            CapacityReservationResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CapacityReservationData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Update_CapacityReservationUpdateMinimumSetGen()
        {
            // Generated from example definition: specification/compute/resource-manager/Microsoft.Compute/ComputeRP/stable/2024-11-01/examples/capacityReservationExamples/CapacityReservation_Update_MinimumSet_Gen.json
            // this example is just showing the usage of "CapacityReservations_Update" operation, for the dependent resources, they will have to be created separately.

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred);

            // this example assumes you already have this CapacityReservationResource created on azure
            // for more information of creating CapacityReservationResource, please refer to the document of CapacityReservationResource
            string subscriptionId = "{subscription-id}";
            string resourceGroupName = "rgcompute";
            string capacityReservationGroupName = "aaaaaaaaaaaaaaaaaaaaaaaaaa";
            string capacityReservationName = "aaa";
            ResourceIdentifier capacityReservationResourceId = CapacityReservationResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, capacityReservationGroupName, capacityReservationName);
            CapacityReservationResource capacityReservation = client.GetCapacityReservationResource(capacityReservationResourceId);

            // invoke the operation
            CapacityReservationPatch patch = new CapacityReservationPatch();
            ArmOperation<CapacityReservationResource> lro = await capacityReservation.UpdateAsync(WaitUntil.Completed, patch);
            CapacityReservationResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            CapacityReservationData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
