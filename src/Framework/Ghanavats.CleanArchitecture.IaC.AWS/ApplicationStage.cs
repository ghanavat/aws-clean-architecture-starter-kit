using Amazon.CDK;
using Constructs;

namespace Ghanavats.CleanArchitecture.IaC.Aws;

public class ApplicationStage : Stage
{
    public ApplicationStage(Construct scope, string id, IStageProps props = null) : base(scope, id, props)
    {
        //arn:aws:iam::aws:policy/AdministratorAccess
    }
}
