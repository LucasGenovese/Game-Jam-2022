using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] IngredientScriptable _ingredient;
    [SerializeField] private GameObject _ingredientPrefab;

    public IngredientScriptable CurrentIngredient
    {
        get { return _ingredient; }
        set { _ingredient = value; }
    }

    public void CreateIngredient()
    {
        var ingredient = GameObject.Instantiate(_ingredientPrefab, transform);
        ingredient.GetComponent<Ingredient>().Generate(_ingredient);
    }
    public IngredientScriptable SelectIngredient()
    {
        return _ingredient;
    }
}
