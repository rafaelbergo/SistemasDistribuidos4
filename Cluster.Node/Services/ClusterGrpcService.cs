using Cluster.Contracts;
using Cluster.Node.Models;
using Grpc.Core;

namespace Cluster.Node.Services;

public class ClusterGrpcService : ClusterService.ClusterServiceBase
{
    private readonly NodeState _nodeState;

    public ClusterGrpcService(NodeState nodeState)
    {
        _nodeState = nodeState;
    }

    public override Task<StatusResponse> GetStatus(StatusRequest request, ServerCallContext context)
    {
        var response = new StatusResponse
        {
            NodeId = _nodeState.NodeId,
            Role = _nodeState.Role.ToString().ToUpperInvariant(),
            Term = _nodeState.CurrentTerm,
            CommitIndex = _nodeState.CommitIndex,
            LeaderId = _nodeState.LeaderId ?? -1
        };

        return Task.FromResult(response);
    }
}