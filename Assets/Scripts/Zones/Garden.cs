using UnityEngine;

public class Garden : ActionZone
{
    public bool IsPlant;

    [SerializeField]
    private GameObject _plantMenu;
    [SerializeField]
    private GameObject _observationMenu;
    [SerializeField]
    private GameObject _harvestMenu;

    private SeedMain _seedMain;

    /// <summary>
    /// Selects which menu to display according to seed status.
    /// </summary>
    public void ActiveMenu()
    {
       
        if (!IsPlant)
        {
            _harvestMenu.SetActive(false);
            _plantMenu.SetActive(true);
        }

        if (IsPlant && !_seedMain.IsGrown)
        {
            _plantMenu.SetActive(false);
            _observationMenu.SetActive(true);
        }

        if (_seedMain != null)
        {
            if (_seedMain.IsGrown && IsPlant)
            {
                _observationMenu.SetActive(false);
                _harvestMenu.SetActive(true);
            }
        }        
    }

    /// <summary>
    /// Closes all menus when leaving the zone.
    /// </summary>
    /// <param name="other"> collider coming out.</param>
    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        _observationMenu.SetActive(false);
        _plantMenu.SetActive(false);
        _harvestMenu.SetActive(false);
    }

    /// <summary>
    /// Opens the right garden menu.
    /// </summary>
    public override void Interact()
    {
        base.Interact();
        ActiveMenu();
    }

    /// <summary>
    /// Search for the SeedMain reference once the seed has been planted.
    /// </summary>
    public void SearchSeedMain()
    {
        _seedMain = FindObjectOfType<SeedMain>().GetComponent<SeedMain>();

    }
}
