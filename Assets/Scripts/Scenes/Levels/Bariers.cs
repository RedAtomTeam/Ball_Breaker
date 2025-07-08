using System;
using System.Collections.Generic;
using UnityEngine;

public class Bariers : MonoBehaviour
{
    [SerializeField] private List<Barier> _bariers;

    public event Action ballCollisionBarierEvent;


    private void Awake()
    {
        foreach (var barier in _bariers) {
            barier.ballCollisionBarierEvent += PerformEvent;
        }
    }

    private void PerformEvent()
    {
        ballCollisionBarierEvent?.Invoke();
    }
}
