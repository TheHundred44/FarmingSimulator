using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private InputMaster _inputActions;
    private float _moveSpeed = 6f;
    private Vector2 _move;
    private CharacterController _characterController;

    private List<ActionZone> _actionZone;

    private void Awake()
    {
        _inputActions = new InputMaster();
        _characterController = GetComponent<CharacterController>();
        _inputActions.Player.Interaction.performed += Interaction_performed;
    }

    private void Start()
    {
        AddActionZone();
    }

    private void Interaction_performed(InputAction.CallbackContext obj)
    {
        foreach(ActionZone zone in _actionZone)
        {
            if (zone.IsIn)
            {
                zone.SendMessage("Interact");
            }
        }      
    }

    private void Update()
    {
        Vector3 movement = (_move.y * transform.forward) + (_move.x * transform.right);
        _characterController.Move(movement * _moveSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void OnMovement()
    {
        _move = _inputActions.Player.Movement.ReadValue<Vector2>();
    }

    public void AddActionZone()
    {
        _actionZone = new List<ActionZone>();
        ActionZone[] foundActionZones = FindObjectsOfType<ActionZone>();

        foreach (ActionZone zone in foundActionZones)
        {
            _actionZone.Add(zone);
        }
    }
}
