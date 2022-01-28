using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public sealed class RecipeScriptable : ScriptableObject
{
    public string name;
    public Sprite artwork;
    public List<IngredientScriptable> ingredientList;
}
