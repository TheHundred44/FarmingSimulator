using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionZone : MonoBehaviour
{
    private InputMaster _inputActions;

    [SerializeField]
    private GameObject _canvaZone;
    [SerializeField]
    private GameObject TextToInteract;

    public bool IsIn = false;

    private void Awake()
    {
        _inputActions = new InputMaster();
    }
    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            IsIn = true;
            TextToInteract.SetActive(true);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsIn = false;
            TextToInteract.SetActive(false);
            _canvaZone.SetActive(false);
        }
    }

    public virtual void Interact()
    {
        if (TextToInteract.activeSelf)
        {
            TextToInteract.SetActive(false);
            _canvaZone.SetActive(true);
        }
        else
        {
            TextToInteract.SetActive(true);
            _canvaZone.SetActive(false);
        }
    }
}
