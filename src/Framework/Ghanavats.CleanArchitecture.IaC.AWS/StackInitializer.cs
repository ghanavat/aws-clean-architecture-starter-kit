using Amazon.CDK;
using Ghanavats.CleanArchitecture.IaC.Aws.ApiGatewayStack;
using Ghanavats.CleanArchitecture.IaC.Aws.DynamoDbStack;
using Ghanavats.CleanArchitecture.IaC.Aws.LambdaStack;

namespace Ghanavats.CleanArchitecture.IaC.Aws;

public static class StackInitializer
{
    public static void Apply(App app)
    {
        _ = new LambdaDeploymentStack(app, "LambdaDeploymentStack", new StackProps
        {
            Env = AwsEnvironmentCreator.SetEnvironment()
        });
        _ = new DynamoDbDeploymentStack(app, "DynamoDbStack", new StackProps
        {
            Env = AwsEnvironmentCreator.SetEnvironment()
        });
        _ = new ApiGatewayDeploymentStack(app, "ApiGatewayDeploymentStack", new StackProps
        {
            Env = AwsEnvironmentCreator.SetEnvironment()
        });
    }
}
