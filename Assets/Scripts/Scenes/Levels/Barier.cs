using System;
using UnityEngine;

public class Barier : MonoBehaviour
{
    public event Action ballCollisionBarierEvent;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ballCollisionBarierEvent?.Invoke();
        }
    }
}
