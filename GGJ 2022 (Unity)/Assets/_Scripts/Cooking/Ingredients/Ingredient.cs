using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private IngredientScriptable _ingredientType;
    [SerializeField] private Sprite _ingredientImage;

    public IngredientScriptable IngredientType
    {
        get { return _ingredientType; }
        set { _ingredientType = value; }
    }

    public void Generate(IngredientScriptable ingredient)
    {
        _ingredientType = ingredient;
        _ingredientImage = ingredient.artwork;
        this.gameObject.name = $"Ingredient: {_ingredientType.name}";
    }

}
