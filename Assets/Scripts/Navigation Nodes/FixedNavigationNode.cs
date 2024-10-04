public class FixedNavigationNode : NavigationNode
{
    public override NavigationNode GetNextNode()
    {
        return linkedNodes.Count > 0 ? linkedNodes[0] : null;
    }
}