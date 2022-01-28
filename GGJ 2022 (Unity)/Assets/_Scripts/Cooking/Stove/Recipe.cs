using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    [SerializeField] private RecipeScriptable _recipeType;
    [SerializeField] private Image _recipeImage;

    public RecipeScriptable RecipeType
    {
        get { return _recipeType; }
        set { _recipeType = value; }
    }

    public List<IngredientScriptable> IngredientList
    {
        get { return _recipeType.ingredientList; }
    }


}

