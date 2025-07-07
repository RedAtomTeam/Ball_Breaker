using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bl_Joystick _joystick;
    [SerializeField] private float _kickPower;
    [SerializeField] private RectTransform _image;
    [SerializeField] private RectTransform _tools;


    private void Update()
    {
        Vector3 newDeltaPosition = new Vector3(
            _joystick.Horizontal * _speed,
            _joystick.Vertical * _speed, 
            0);

        GetComponent<Rigidbody2D>().velocity = newDeltaPosition;

        if (_joystick.Vertical > 0)
        {
            _image.localScale = new Vector3(_image.localScale.x, 1, _image.localScale.z);
            _tools.localScale = new Vector3(_tools.localScale.x, 1, _tools.localScale.z);
        }
        if (_joystick.Vertical < 0)
        {
            _image.localScale = new Vector3(_image.localScale.x, -1, _image.localScale.z);
            _tools.localScale = new Vector3(_tools.localScale.x, -1, _tools.localScale.z);
        }
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
