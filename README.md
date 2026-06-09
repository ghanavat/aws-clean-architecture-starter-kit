# aws-clean-architecture-starter-kit
An AWS powered Clean Architecture template that helps to build a fully working Clean Architecture codebase and publish it to AWS in seconds.

# ⚠️ Early Work In Progress
This project is currently under active development.

## Current status
* [x] Clean Architecture Template
* [x] Microsoft Template Engine
* [x] IaC project created and a draft stack created
* [x] AWS CDK for Lambda and API Gateway implemented

## Planned
1. [ ] AWS CDK 
2. [ ] Lambda
3. [ ] API Gateway
4. [ ] DynamoDB
5. [ ] CloudWatch

**Feedback and suggestions are welcome.**

# Multi stacks scenario
When your CDK app has more than one stack, use '--all' option.
```shell
cdk deploy --all
```
The same applies when you want to destroy your resources.
```shell
cdk destroy --all
```
# Lambda handler in Minimal API
In Minimal API solutions the API project in the solution is the entry point.

Traditionally, for APIs, we used to create a class to act as a Lambda entry point and utilised _IWebHostBuilder.UseStartup<>_ to specify the application _Startup.cs_ file.
This approach is useful when you are deploying an API with traditional Controllers.

# Lambda assets
CDK uploads deployment assets and the actual source code onto S3 if it is chosen as an Asset Option.
These are managed by CDK bootstrap resources, not by the application stack.
When the bucket is created by CDK,
a Lifecycle rule is created to permanently delete objects after 30 days.

# DynamoDb
I figured that EF Core does not have support for DynamoDb. Also figured that AWS has its own DbContext for DynamoDb.
So I decided to use it in this template. 
I would personally like to extend my Ghanavats.Repository package with DynamoDb support, but it's an overkill at this time.
