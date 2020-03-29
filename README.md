# AWS Lambda PoC

## Requirements

A role with `AWSLambdaBasicExecutionRole` policy (named `lambdaRole` in this example)

## Instructions

Install or update Amazon.Lambda.Tools

```bash
    dotnet tool install -g Amazon.Lambda.Tools
    dotnet tool update -g Amazon.Lambda.Tools
```

Create the package to be deployed (run command in Linux or WSL, or remove `/p:PublishReadyToRun=true` from `aws-lambda-tools-defaults.json`)

```bash
    dotnet lambda package --output-package bin/TestLambdaPackage.zip
```

Deploy the lambda function

```bash
    dotnet lambda deploy-function --package bin/TestLambdaPackage.zip
```

Test the lambda function

```bash
    dotnet lambda invoke-function -p "Hey!"
```

Cleanup

```bash
    dotnet lambda delete-function TestLambda
```
