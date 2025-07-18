using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolConfig", menuName = "Scriptable Objects/Tool Config")]
public class ToolConfig : ScriptableObject
{
    public int level = 1;
    public List<ToolLevel> toolLevels;
    public AudioClip clip;
    public int Power
    {
        get => toolLevels.First(e => e.level == level).power;
    }
    event Action onChange;

    public void PerformChange()
    {
        onChange?.Invoke();
    }
}

[Serializable]
public class ToolLevel
{
    public int level;
    public int power;
    public int cost;
}