using CommandLine;
using System;

namespace ADOSCloneAllRepos
{
    public class Options
    {
        [Option('c', "collection-uri", Required = true, HelpText = "Azure collection e.g. https://dev.azure.com/sample-organization-name/")]
        public Uri CollectionUri { get; set; }

        [Option('u', "user-name", Required = true, HelpText = "Git username e.g. username@microsoft.com")]
        public string UserName { get; set; }

        [Option('p', "pat", Required = true, HelpText = "Personal Access Token (PAT) for the Git repositories")]
        public string AccessToken { get; set; }

        [Option('o', "output-path", Required = true, HelpText = "Folder to clone repositories into e.g. C:\\ClonedRepos")]
        public string OutputPath { get; set; }
    }
}