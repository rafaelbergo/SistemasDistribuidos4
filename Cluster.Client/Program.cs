
using Cluster.Contracts;
using Grpc.Net.Client;

// Node address
var address = "https://localhost:7196";

// Create gRPC channel
using var channel = GrpcChannel.ForAddress(address);

// Create gRPC client
var client = new ClusterService.ClusterServiceClient(channel);

try
{
    var response = await client.GetStatusAsync(new StatusRequest());

    Console.WriteLine("Node Status:");
    Console.WriteLine($"Node ID: {response.NodeId}");
    Console.WriteLine($"Role: {response.Role}");
    Console.WriteLine($"Term: {response.Term}");
    Console.WriteLine($"Commit Index: {response.CommitIndex}");
    Console.WriteLine($"Leader ID: {response.LeaderId}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error to communicate with node: {ex.Message}");
}
