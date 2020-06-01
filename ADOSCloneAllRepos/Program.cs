using Microsoft.VisualStudio.Services.Common;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using Microsoft.TeamFoundation.Core.WebApi;
using LibGit2Sharp;
using System.IO;
using CommandLine;

namespace ADOSCloneAllRepos
{
    class Program
    {
        static void Main(string[] args) =>
            Parser.Default.ParseArguments<Options>(args).WithParsed(options => CloneRepositories(options));

        static void CloneRepositories(Options options)
        {
            VssCredentials creds = new VssBasicCredential(string.Empty, options.AccessToken);

            // Connect to Azure DevOps Services
            VssConnection connection = new VssConnection(options.CollectionUri, creds);

            ProjectHttpClient projClient = connection.GetClientAsync<ProjectHttpClient>().Result;
            var projects = projClient.GetProjects().Result;

            var cloneOptions = new CloneOptions()
            {
                CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials
                {
                    Username = options.UserName,
                    Password = options.AccessToken,
                }
            };

            GitHttpClient gitClient = connection.GetClient<GitHttpClient>();
            foreach (var project in projects)
            {
                var repositories = gitClient.GetRepositoriesAsync(project.Name).Result;
                if (repositories != null)
                {
                    foreach (var repo in repositories)
                    {
                        string cloneDir = Path.Combine(options.OutputPath, project.Name, repo.Name);
                        Console.WriteLine($"Cloning: {repo.RemoteUrl} to {cloneDir}");
                        Repository.Clone(repo.RemoteUrl, cloneDir, cloneOptions);
                    }
                }
            }
        }
    }
}