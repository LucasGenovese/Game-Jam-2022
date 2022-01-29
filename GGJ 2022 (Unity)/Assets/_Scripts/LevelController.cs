using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] private IngredientDatabase _ingredientDatabase;
    [SerializeField] private ScoreManager _scoreManager;

    public IngredientDatabase IngredientDatabase => _ingredientDatabase;
    public ScoreManager ScoreManager => _scoreManager;

}
