using Microsoft.VisualStudio.Services.Common;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.WebApi;
using System;
using Microsoft.TeamFoundation.Core.WebApi;
using System.Collections.Generic;
using LibGit2Sharp;
using System.IO;

namespace ADOSCloneAllRepos
{
    class Program
    {
        const string c_collectionUri = "https://dev.azure.com/sample-organization-name/";
        const string c_userName = "username@microsoft.com";

        // PAT needs at least read all organization and projects and git clone permissions.
        const string c_pat = "use-a-valid-pat-here";

        const string c_outputLocation = @"C:\Temp";

        static void Main(string[] args)
        {
            VssCredentials creds = new VssBasicCredential(string.Empty, c_pat);

            // Connect to Azure DevOps Services
            VssConnection connection = new VssConnection(new Uri(c_collectionUri), creds);

            ProjectHttpClient projClient = connection.GetClientAsync<ProjectHttpClient>().Result;
            var projects = projClient.GetProjects().Result;

            var cloneOptions = new CloneOptions()
            {
                CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials
                {
                    Username = c_userName,
                    Password = c_pat,
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
                        Console.WriteLine("Cloning: " + repo.RemoteUrl);
                        string cloneDir = Path.Combine(c_outputLocation, repo.Name);
                        Repository.Clone(repo.RemoteUrl, cloneDir, cloneOptions);
                    }
                }
            }
        }
    }
}