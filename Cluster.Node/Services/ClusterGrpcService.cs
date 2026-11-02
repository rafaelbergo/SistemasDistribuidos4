using Cluster.Contracts;
using Grpc.Core;

namespace Cluster.Node.Services;

public class ClusterGrpcService : ClusterService.ClusterServiceBase
{
    public override Task<StatusResponse> GetStatus(StatusRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StatusResponse
        {
            NodeId = 1,
            Role = "FOLLOWER",
            Term = 0,
            CommitIndex = 0,
            LeaderId = -1
        });
    }
}