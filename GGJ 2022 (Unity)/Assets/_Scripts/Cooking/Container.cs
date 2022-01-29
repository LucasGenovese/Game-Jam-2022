using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] IngredientScriptable _ingredient;
    [SerializeField] private GameObject _ingredientPrefab;
    [SerializeField] private SpriteRenderer _renderer;

    public IngredientScriptable CurrentIngredient
    {
        get { return _ingredient; }
        set { _ingredient = value; UpdateArtwork(); }
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void UpdateArtwork()
    {
        _renderer.sprite = CurrentIngredient.artwork;
    }

    public void CreateIngredient()
    {
        var ingredient = GameObject.Instantiate(_ingredientPrefab, transform);
        ingredient.GetComponent<Ingredient>().Generate(_ingredient);
    }
    public IngredientScriptable SelectIngredient()
    {
        Debug.Log($"[Container]: Se selecciono {_ingredient.name}");
        return _ingredient;
    }
}
