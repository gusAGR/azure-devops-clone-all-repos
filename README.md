![ADOSCloneAllRepos CI](https://github.com/realrubberduckdev/azure-devops-clone-all-repos/workflows/.NET%20Core/badge.svg?branch=master)

# ADOSCloneAllRepos
Dotnet tool to clone all repositories from provided Azure DevOps organization.

# Usage

## Installation
Install tool from [nuget.org](https://www.nuget.org/packages/ADOSCloneAllRepos/).

## Running
If installed with `--global` or `-g` parameter, run using
```
ADOSCloneAllRepos.exe
```

If installed with `--local` parameter, run using
```
dotnet ADOSCloneAllRepos
```

## Command line reference
Get help using the command:

```
.\ADOSCloneAllRepos.exe --help
ADOSCloneAllRepos 1.0.0
Copyright (C) 2020 ADOSCloneAllRepos

  -c, --collection-uri    Required. Azure collection e.g. https://dev.azure.com/sample-organization-name/

  -u, --user-name         Required. Git username e.g. username@microsoft.com

  -p, --pat               Required. Personal Access Token (PAT) for the Git repositories

  -o, --output-path       Required. Folder to clone repositories into e.g. C:\ClonedRepos

  --help                  Display this help screen.

  --version               Display version information.
```

## PAT
PAT needs at least read all organization and projects and git clone permissions.
Refer [Authenticate access with personal access tokens](https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/use-personal-access-tokens-to-authenticate?view=azure-devops&tabs=preview-page) on how to generate a PAT.

# Getting latest artifact
Download artifact from latest Github action CI from master branch available at [.NET Core workflow](https://github.com/realrubberduckdev/azure-devops-clone-all-repos/actions?query=workflow%3A%22.NET+Core%22+branch%3Amaster+is%3Asuccess).

![workflow-artifact](./imgs/workflow-artifact.png)