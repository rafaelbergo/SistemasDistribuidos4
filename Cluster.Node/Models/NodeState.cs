namespace Cluster.Node.Models;

public class NodeState
{
    public int NodeId { get; set; }
    public NodeRole Role { get; set; } = NodeRole.Follower;
    public int CurrentTerm { get; set; } = 0;
    public int CommitIndex { get; set; } = 0;
    public int LastApplied { get; set; } = 0;
    public int? LeaderId { get; set; }
}