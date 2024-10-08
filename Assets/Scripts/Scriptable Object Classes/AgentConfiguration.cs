﻿using UnityEngine;

[CreateAssetMenu(fileName = "AgentConfiguration.asset", 
                 menuName = "TowerDefense/AgentConfiguration", 
                 order = 1)]
public class AgentConfiguration : ScriptableObject
{
    public string agentName;
    public string description;
    public Agent prefab;
}