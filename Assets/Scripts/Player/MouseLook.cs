using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private InputMaster _inputActions;
    private float _mouseSensitivity = 120f;
    private Vector2 _mouseLook;
    private float _xRotation;
    [SerializeField]
    private Transform _playerBody;

    private void Awake()
    {
        _playerBody = transform.parent;

        _inputActions = new InputMaster();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        _mouseLook = _inputActions.Player.Look.ReadValue<Vector2>();

        float mouseX = _mouseLook.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = _mouseLook.y * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _playerBody.Rotate(Vector3.up * mouseX);
    }

    public void OnEnable()
    {
        _inputActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnDisable()
    {
        _inputActions.Disable();
        Cursor.lockState = CursorLockMode.None;
    }
}
