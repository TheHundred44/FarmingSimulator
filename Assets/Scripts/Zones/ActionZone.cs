using UnityEngine;

public class ActionZone : MonoBehaviour
{
    private InputMaster _inputActions;

    [SerializeField]
    private GameObject _canvaZone;
    [SerializeField]
    private GameObject TextToInteract;
    [SerializeField]
    private MouseLook _mouseLook;

    public bool IsIn = false;

    private void Awake()
    {
        _inputActions = new InputMaster();
        _mouseLook = FindAnyObjectByType<MouseLook>();
    }

    /// <summary>
    /// Opens the menu and removes displayed text, and vice versa. 
    /// </summary>
    public virtual void Interact()
    {
        if (TextToInteract.activeSelf)
        {
            TextToInteract.SetActive(false);
            _canvaZone.SetActive(true);
            _mouseLook.OnDisable();
        }
        else
        {
            TextToInteract.SetActive(true);
            _canvaZone.SetActive(false);
            _mouseLook.OnEnable();
        }
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
    /// Checks that when a player enters the zone, a text is displayed and opens the associated menu.
    /// </summary>
    /// <param name="other"></param>
    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsIn = true;
            TextToInteract.SetActive(true);
        }
    }

    /// <summary>
    /// Checks if a player leaves the zone and closes the associated menu.
    /// </summary>
    /// <param name="other"></param>
    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsIn = false;
            TextToInteract.SetActive(false);
            _canvaZone.SetActive(false);
            _mouseLook.OnEnable();
        }
    }
}
