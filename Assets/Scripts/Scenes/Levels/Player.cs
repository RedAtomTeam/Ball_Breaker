using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bl_Joystick _joystick;
    [SerializeField] private float _kickPower;

    private void Update()
    {
        Vector3 newDeltaPosition = new Vector3(
            Time.deltaTime * _joystick.Horizontal * _speed,
            Time.deltaTime * _joystick.Vertical * _speed, 
            0);
        transform.localPosition += newDeltaPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.rigidbody.velocity = new Vector3(
                Time.deltaTime * _joystick.Horizontal * _kickPower,
                Time.deltaTime * _joystick.Vertical * _kickPower,
                0);
        }
    }
}
