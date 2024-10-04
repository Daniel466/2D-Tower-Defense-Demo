using UnityEngine;
using System.Collections.Generic;

public abstract class NavigationNode : MonoBehaviour
{ 
    [SerializeField] protected List<NavigationNode> linkedNodes;

    public abstract NavigationNode GetNextNode();
}