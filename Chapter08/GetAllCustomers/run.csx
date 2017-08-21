#r "Microsoft.Azure.WebJobs.Extensions.DurableTask"
public static int[] Run(DurableActivityContext getAllCustomersContext)
{
   
    int[] customers = new int[]{1,2,3,4,5};
    return customers;
}
