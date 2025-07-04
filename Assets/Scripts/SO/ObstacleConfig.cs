using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ObstacleConfig", menuName = "Scriptable Objects/Obstacle Config")]
public class ObstacleConfig : ScriptableObject
{
    public ToolConfig targetTool;
    public List<ObstacleLevel> obstacleLevels;
}

[Serializable]
public class ObstacleLevel
{
    public int level;
    public int durability;
}