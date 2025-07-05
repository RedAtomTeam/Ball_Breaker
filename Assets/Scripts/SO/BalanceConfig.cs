using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BalanceConfig", menuName = "Scriptable Objects/Balance Config")]
public class BalanceConfig : ScriptableObject
{
    public int balance;
    public event Action onChange;

    public void PerformChange()
    {
        onChange?.Invoke();
    }

    public void Add(int value)
    {
        balance += value;
        onChange?.Invoke();
    }

    public void Remove(int value)
    {
        balance -= value;
        onChange?.Invoke();
    }

}
