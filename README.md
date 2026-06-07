# aws-clean-architecture-starter-kit
An AWS powered Clean Architecture template that helps to build a fully working Clean Architecture codebase and publish it to AWS in seconds.

# ⚠️ Early Work In Progress
This project is currently under active development.

## Current status
* [x] Clean Architecture Template
* [x] Microsoft Template Engine
* [x] IaC project created and a draft stack created

## Planned
1. [ ] AWS CDK 
2. [ ] Lambda
3. [ ] API Gateway
4. [ ] DynamoDB
5. [ ] CloudWatch

**Feedback and suggestions are welcome.**

> CDK uploads deployment assets to the CDK bootstrap S3 bucket. 
These are managed by CDK bootstrap resources, not by the application stack. 
When the bucket is created by CDK, 
a Lifecycle rule is created to permanently delete objects after 30 days.

# Multi stacks scenario
When your CDK app has more than one stack, use '--all' option.
```shell
cdk deploy --all
```
The same applies when you want to destroy your resources.
```shell
cdk destroy --all
```
# Lambda entry point in Minimal API
The API project in your solution is the entry point.

Traditionally, you used to create a class to act as an entry point for your Lambda 
and utilise _IWebHostBuilder.UseStartup<>_ to specify the application _Startup.cs_ file.
This approach is useful when you are deploying an API with traditional Controllers.
