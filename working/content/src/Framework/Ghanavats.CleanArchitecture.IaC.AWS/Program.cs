using Amazon.CDK;

namespace Ghanavats.CleanArchitecture.IaC.Aws;

sealed class Program
{
    public static void Main(string[] args)
    {
        var app = new App();
        StackInitializer.Apply(app);
        app.Synth();
    }
}
