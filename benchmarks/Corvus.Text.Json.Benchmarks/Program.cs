// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Perfolizer.Mathematics.OutlierDetection;

namespace Corvus.Text.Json.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var config = ManualConfig.Create(DefaultConfig.Instance);

            config.AddJob(
                Job.Default
                    .AsBaseline()
                    .WithRuntime(CoreRuntime.Core90)
                    .WithOutlierMode(OutlierMode.RemoveAll)
                    .WithStrategy(RunStrategy.Throughput));


            config.AddJob(
                Job.Default
                    .WithRuntime(CoreRuntime.Core10_0)
                    .WithOutlierMode(OutlierMode.RemoveAll)
                    .WithStrategy(RunStrategy.Throughput));

            config.AddJob(
                Job.Default
                    .WithRuntime(ClrRuntime.Net481)
                    .WithOutlierMode(OutlierMode.RemoveAll)
                    .WithStrategy(RunStrategy.Throughput));

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(config: config);
        }
    }
}
