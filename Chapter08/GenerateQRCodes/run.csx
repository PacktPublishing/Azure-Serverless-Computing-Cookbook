#r "Microsoft.Azure.WebJobs.Extensions.DurableTask"

public static async Task<int> Run(DurableOrchestrationContext qrCodeContext)
{
int[] customers = await qrCodeContext.CallFunctionAsync<int[]>("GetAllCustomers");

var tasks = new Task<long>[customers.Length];
for (int nCustomerIndex = 0; nCustomerIndex < customers.Length; nCustomerIndex++)
{
tasks[nCustomerIndex] = qrCodeContext.CallFunctionAsync<int>("CreateQRCodeImagesPerCustomer", customers[nCustomerIndex]);
}
await Task.WhenAll(tasks);
int nTotalItems = tasks.Sum(item => item.Result);
return nTotalItems; 
}