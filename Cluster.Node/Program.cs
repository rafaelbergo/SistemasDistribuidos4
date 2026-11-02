using Cluster.Node.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ClusterGrpcService>();

app.MapGet("/", () => "Cluster Node is running. Use a gRPC client to communicate.");

app.Run();
