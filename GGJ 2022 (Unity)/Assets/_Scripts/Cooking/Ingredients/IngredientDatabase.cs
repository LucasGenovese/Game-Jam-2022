using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDatabase : MonoBehaviour
{
    [SerializeField] public IngredientScriptable[] Ingredients { get; private set; }
    private void Awake()
    {
        Ingredients = Resources.LoadAll<IngredientScriptable>("Ingredients/");
    }
}
