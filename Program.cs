using Prometheus;
using Prometheus.DotNetRuntime;

DotNetRuntimeStatsBuilder.Default();
DotNetRuntimeStatsBuilder.Customize()
    .WithContentionStats(CaptureLevel.Informational)
    .WithGcStats(CaptureLevel.Verbose)
    .WithThreadPoolStats(CaptureLevel.Informational)
    .WithExceptionStats(CaptureLevel.Errors)
    .WithJitStats()
    .RecycleCollectorsEvery(TimeSpan.FromMinutes(20))
    .StartCollecting();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpMetrics();
app.UseMetricServer();

app.MapGet("/", () => "Hello World!");

app.Run();


