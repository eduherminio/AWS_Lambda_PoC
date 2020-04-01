# AWS Lambda PoC

## Requirements

A role with `AWSLambdaBasicExecutionRole` policy (named `lambdaRole` in this example)

## Instructions

Install or update Amazon.Lambda.Tools

```bash
    dotnet tool install -g Amazon.Lambda.Tools
    dotnet tool update -g Amazon.Lambda.Tools
```

Deploy the lambda function

```bash
    dotnet lambda deploy-function
```

Test the lambda function

```bash
    dotnet lambda invoke-function -p "Hey!"
```

Cleanup

```bash
    dotnet lambda delete-function TestLambda
```
