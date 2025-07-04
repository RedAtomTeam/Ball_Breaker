using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllToolsConfig", menuName = "Scriptable Objects/All Tools Config")]
public class AllToolsConfig : ScriptableObject
{
    public List<ToolConfig> toolConfigs;
}
