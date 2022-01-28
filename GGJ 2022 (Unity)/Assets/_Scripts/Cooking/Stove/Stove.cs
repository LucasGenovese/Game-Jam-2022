using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [SerializeField] private RecipeScriptable _currentRecipe;
    [SerializeField] private IngredientScriptable _ingredient;

    public void AddIngredient(PlayerController.Player player, IngredientScriptable ingredient)
    {
        if (_currentRecipe.ingredientList.Contains(ingredient))
        {
            _ingredient = ingredient;
            GameManager.Instance.ScoreManager.PlayerScore(player, 50);
            Debug.Log("Todo Correcto!");
        }

        else
        {
            Debug.Log("Somos Pollo!");
        }
    }
}
