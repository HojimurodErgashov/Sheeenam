﻿//===============================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//===============================================

using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

var githubPipeline = new GithubPipeline
{
    Name = "Sheeenam Build Pipeline",
    OnEvents = new Events
    {
        PullRequest = new PullRequestEvent
        {
            Branches = new string[]{"main"}
        },

        Push = new PushEvent
        {
          Branches = new string[] { "main" }
        }
    },

    Jobs = new Jobs
    {
        Build = new BuildJob
        {
            RunsOn = BuildMachines.Windows2022,

            Steps = new List<GithubTask>
            {

                new CheckoutTaskV2
                {
                    Name = "Checking out code"
                },

                new SetupDotNetTaskV1
                {
                    Name = "Setting up .NET",
                    TargetDotNetVersion = new TargetDotNetVersion
                    {
                       DotNetVersion =  "6.0.300"
                    }
                },

                new RestoreTask
                {
                    Name = "Restoring NUGET Packages"
                },

                new DotNetBuildTask
                {
                    Name = "Building Project"
                },

                new TestTask
                {
                    Name = "Running Tests"
                }
            }
        }
    }

};

var client = new ADotNetClient();

client.SerializeAndWriteToFile(adoPipeline: githubPipeline,
    path: "../../../../.github/workflows/dotnet.yml");