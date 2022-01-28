using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [SerializeField] private RecipeScriptable _currentRecipe;
    [SerializeField] private Ingredient _ingredient;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AddIngredient(_ingredient);
        }
    }

    public void AddIngredient(Ingredient ingredient)
    {
        if (_currentRecipe.ingredientList.Contains(ingredient.IngredientType))
        {
            Debug.Log("Todo Correcto!");
        }

        else
        {
            Debug.Log("Somos Pollo!");
        }
    }
}
