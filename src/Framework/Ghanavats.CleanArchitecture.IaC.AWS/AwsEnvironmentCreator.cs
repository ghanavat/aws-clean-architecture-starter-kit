using Amazon.CDK;

namespace Ghanavats.CleanArchitecture.IaC.Aws;

public static class AwsEnvironmentCreator
{
    public static Environment SetEnvironment()
    {
        /*
            Env = new Amazon.CDK.Environment
            {
                Account = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_ACCOUNT"),
                Region = System.Environment.GetEnvironmentVariable("CDK_DEFAULT_REGION"),
            }
        */
        
        return new Environment
        {
            Account = "764401945112",
            Region = "eu-west-1"
        };
    }
}
