using Cluster.Node.Models;
using Cluster.Node.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var nodeId = builder.Configuration.GetValue<int?>("node-id");

if (nodeId is null || nodeId < 1 || nodeId > 4)
    throw new InvalidOperationException("Invalid Node Id");

var nodeState = new NodeState
{
    NodeId = nodeId.Value
};

builder.Services.AddSingleton(nodeState);
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ClusterGrpcService>();

app.MapGet("/", () => $"Cluster Node {nodeId} is running");

app.Run();
