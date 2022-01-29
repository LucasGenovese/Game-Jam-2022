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

    private void Start()
    {
        RandomizeIngredients();
    }

    private void RandomizeIngredients()
    {
        _ingredientTypes = LevelController.Instance.IngredientDatabase.Ingredients.ToList();
        int _index = 0;

        foreach (var container in _ingredientContainers)
        {
            container.CurrentIngredient = _ingredientTypes[_index];

            container.name = $"Ingredient Container: {container.CurrentIngredient.name}";
            container.CreateIngredient();
            _index++;
        }

    }
}
