using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IngredientManager : MonoBehaviour
{
    [Header("Containers")]
    [SerializeField] private List<Container> _ingredientContainers;

    [SerializeField] private GameObject _ingredientPrefab;

    [Header("Ingredients")]
    [SerializeField] private List<IngredientScriptable> _ingredientTypes;
    [SerializeField] private List<RecipeScriptable> _recipeList;

    private void Awake()
    {
        _ingredientTypes = new List<IngredientScriptable>(LevelController.Instance.IngredientDatabase.Ingredients.ToList());
        _recipeList = new List<RecipeScriptable>(LevelController.Instance.RecipeDatabase.Recipes.ToList());
    }

    private void Start()
    {

        RandomizeIngredients();
    }

    private void RandomizeIngredients()
    {
        int _index = 0;

        foreach (var container in _ingredientContainers)
        {
            container.CurrentIngredient = _ingredientTypes[_index];

            container.name = $"Ingredient Container: {container.CurrentIngredient.name}";
            container.CreateIngredient();
            _index++;
        }

    }

    public RecipeScriptable SelectRandomRecipe()
    {
        RecipeScriptable recipe = _recipeList[Random.RandomRange(0, _recipeList.Count)];
        return recipe;
    }
}
