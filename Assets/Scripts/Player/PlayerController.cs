using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputMaster _inputActions;
    private float _moveSpeed = 6f;
    private Vector2 _move;
    private CharacterController _characterController;

    private List<ActionZone> _actionZone;

    [SerializeField] private GameObject _canvaInventory;
    [SerializeField] private GameObject _canvaOptions;

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

    /// <summary>
    /// Finds all zones with which the player can interact.
    /// </summary>
    /// <param name="obj"></param>
    private void Interaction_performed(InputAction.CallbackContext obj)
    {
        foreach (ActionZone zone in _actionZone)
        {
            if (zone.IsIn)
            {
                zone.SendMessage("Interact");
            }
        }      
    }

    /// <summary>
    /// Moves the player.
    /// </summary>
    private void Update()
    {
        Vector3 movement = (_move.y * transform.forward) + (_move.x * transform.right);
        _characterController.Move(movement * _moveSpeed * Time.deltaTime);
    }

    /// <summary>
    /// Activates the inputs.
    /// </summary>
    private void OnEnable()
    {
        _inputActions.Enable();
    }

    /// <summary>
    /// Disables the inputs.
    /// </summary>
    private void OnDisable()
    {
        _inputActions.Disable();
    }

    /// <summary>
    /// Retrieves inputs information for player movement.
    /// </summary>
    private void OnMovement()
    {
        _move = _inputActions.Player.Movement.ReadValue<Vector2>();
    }

    /// <summary>
    /// Retrieves all zones with which the player can interact.
    /// </summary>
    private void AddActionZone()
    {
        _actionZone = new List<ActionZone>();
        ActionZone[] foundActionZones = FindObjectsOfType<ActionZone>();

        foreach (ActionZone zone in foundActionZones)
        {
            _actionZone.Add(zone);
        }
    }

    /// <summary>
    /// Retrieves input to open inventory.
    /// </summary>
    private void OnInventory()
    {
        UseCanva(_canvaInventory);
    }

    /// <summary>
    /// Retrieves input to open options.
    /// </summary>
    private void OnOptions()
    {
        UseCanva(_canvaOptions);
    }

    /// <summary>
    /// Opens or closes a canva according to its current state.
    /// </summary>
    /// <param name="gameObject"></param>
    private void UseCanva(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
