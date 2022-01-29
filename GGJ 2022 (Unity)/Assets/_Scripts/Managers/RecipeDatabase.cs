using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour
{
    [SerializeField] public RecipeScriptable[] Recipes { get; private set; }
    private void Awake()
    {
        Recipes = Resources.LoadAll<RecipeScriptable>("Recipes/");
    }
}
