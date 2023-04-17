using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Running;
using BenchmarkTechTest;

Console.WriteLine("Hello, World!");
var config = ManualConfig.CreateMinimumViable();
config.AddExporter(CsvMeasurementsExporter.Default);
config.AddExporter(RPlotExporter.Default);

BenchmarkRunner.Run<TeamScoresBenchmark>(config);
