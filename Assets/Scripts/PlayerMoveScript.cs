using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public Camera PlayerCamera;
    public CharacterController Controller;
    private Vector3 _velocity;
    private Vector3 _rotation;
    private Vector3 _cameraRotation;
    private float _speed = 10f;
    private float _jumpPower = 0.1f;
    private float _gravity = -9.8f;
    private float _gravityScale = 0.007f;
    private float _rotationSpeed = 270f;
 
    private void Start()
    {
        transform.Rotate(0, 0, 0);
        PlayerCamera.transform.Rotate(0, 0, 0);

        Controller = gameObject.AddComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        float velocity = _speed;
        float velocityY = _gravity * _gravityScale * Time.deltaTime;
        if (Controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            _velocity.y = 0;
            velocityY = Mathf.Sqrt(_jumpPower * -3.0f * _gravity * _gravityScale);

        } else if (!Controller.isGrounded) {
            velocity = _speed / 2;
        }

        _velocity.x = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        _velocity.y += velocityY;
        _velocity.z = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        _velocity = this.transform.TransformDirection(_velocity);
        Controller.Move(_velocity);

        this._rotation = new Vector3(0, Input.GetAxisRaw("Mouse X") * _rotationSpeed * Time.deltaTime, 0);
        this._cameraRotation = new Vector3(Input.GetAxisRaw("Mouse Y") * _rotationSpeed * Time.deltaTime * -1, 0, 0);
        this.transform.Rotate(this._rotation);
        PlayerCamera.transform.Rotate(this._cameraRotation);
    }
}
