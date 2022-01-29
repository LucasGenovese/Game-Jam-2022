using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeIngredientsUI : MonoBehaviour
{
    [SerializeField] private List<Image> _ingredients;
    [SerializeField] private Stove _stove;

    public void UpdateIngridientList()
    {
        for (int i = 0; i < _ingredients.Count; i++)
        {
            _ingredients[i].sprite = _stove.Recipe.ingredientList[i].artwork;
        }
    }
}
