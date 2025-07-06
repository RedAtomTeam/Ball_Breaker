using System;
using UnityEngine;

public class Arc : MonoBehaviour
{
    public event Action scoreGoalEvent;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreGoalEvent?.Invoke();
    }
}
