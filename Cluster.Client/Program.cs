
using Cluster.Contracts;
using Grpc.Net.Client;

var nodes = new Dictionary<int, string>
{
    { 1, "https://localhost:5001" },
    { 2, "https://localhost:5002" },
    { 3, "https://localhost:5003" },
    { 4, "https://localhost:5004" }
};

foreach (var node in nodes)
{
    Console.WriteLine($"\nCheck Node {node.Key}");

    try
    {
        using var channel = GrpcChannel.ForAddress(node.Value);

        var client = new ClusterService.ClusterServiceClient(channel);

        var response = await client.GetStatusAsync(
            new StatusRequest()
        );

        Console.WriteLine($"Node ID: {response.NodeId}");
        Console.WriteLine($"Role: {response.Role}");
        Console.WriteLine($"Term: {response.Term}");
        Console.WriteLine($"Commit Index: {response.CommitIndex}");
        Console.WriteLine($"Leader ID: {response.LeaderId}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
