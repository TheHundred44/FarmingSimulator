using UnityEngine;
using System;

public class SeedPlant : MonoBehaviour
{
    [SerializeField]private SeedInventory _inventory;

    public event Action OnTextNbOfSeed;

    [SerializeField]private BoxCollider _boxCollider;

    public Garden Garden;

    private SeedGrown _grown;

    private GameObject _plantPrefab;

    /// <summary>
    /// Instantiates the seed, removes it from inventory and activates its growth.
    /// </summary>
    public void Plant()
    {
        if (!Garden.IsPlant)
        {
            _inventory.NbOfSeed -= 1;
            OnTextNbOfSeed?.Invoke();

            Vector3 center = _boxCollider.bounds.center;
            _plantPrefab = Instantiate(_inventory.SeedScriptableObject.Prefab, center, Quaternion.identity);

            Garden.IsPlant = true;
            Garden.SearchSeedMain();
            Garden.ActiveMenu();
            _grown = FindAnyObjectByType<SeedGrown>().GetComponent<SeedGrown>();
            _grown.Grown();
        }
        else
        {
            Debug.Log("Vous avez déjà planté une graine");
        }        
    }

    /// <summary>
    /// Removes the gameobject of the seed.
    /// </summary>
    public void DestroyPlant()
    {
        // Yes I tried several methods to remove it but even by doing Destroy(_plantPrefabs)
        // or searching for its name it stayed on the scene so this is the only method I found quickly that works.
        Destroy(GameObject.FindGameObjectWithTag("Tomate"));
        
    }
}
