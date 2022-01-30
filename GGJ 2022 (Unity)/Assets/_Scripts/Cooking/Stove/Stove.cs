using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    [SerializeField] private RecipeScriptable _currentRecipe;

    [SerializeField] private PlayerController.Player _owner;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _uiAnimator;
    [SerializeField] private float _cookingTime = 5f;
    [SerializeField] private float _originalCookingTime;
    [SerializeField] private bool _isCooking = false;

    [SerializeField] private RecipeScriptable _nextRecipe;
    [SerializeField] private List<IngredientScriptable> _neededIngredients;
    [SerializeField] private RecipeIngredientsUI _uiComponent;
    [SerializeField] private int _ingredientsUsed = 0;

    [SerializeField] private int ingredientOwner = 0;
    [SerializeField] private int ingredientEnemy = 0;
    [SerializeField] private AudioClip cookingClip;
    [SerializeField] private AudioClip finishedClip;
    [SerializeField] private AudioSource _audioSource;

    public RecipeScriptable Recipe => _currentRecipe;

    public bool IsCooking
    {
        get { return _isCooking; }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _uiComponent = GetComponentInChildren<RecipeIngredientsUI>();
    }

    private void Start()
    {
        _originalCookingTime = _cookingTime;
        _cookingTime = 0;
    }

    private void Update()
    {
        _isCooking = _cookingTime > 0 ? _isCooking = true : _isCooking = false;

        if (_cookingTime > 0 )
        {
            _cookingTime -= Time.deltaTime;

            if (_cookingTime <= 0)
            {
                _animator.SetTrigger("Stop Cooking");
                CheckRecipeStatus();
            }
        }
    }

    private void CheckRecipeStatus()
    {
        Debug.Log("[Stove] Checking Recipe Status...");
        _audioSource.Stop();

        if (_ingredientsUsed >= _currentRecipe.ingredientList.Count) // Ya se termino el plato.
        {
            Debug.Log("[Stove] Finished Recipe!");
            LevelController.Instance.ScoreManager.ProportionalScore(ingredientOwner, ingredientEnemy, 210);
            FinishedRecipe();
        }

        else
        {
            Debug.Log("[Stove] Incomplete Recipe!");
        }
    }

    public void ChangeRecipe(RecipeScriptable recipe)
    {
        ingredientEnemy = 0;
        ingredientOwner = 0;
        _ingredientsUsed = 0;
        _currentRecipe = recipe;
        _neededIngredients = new List<IngredientScriptable>(_currentRecipe.ingredientList);
        _uiComponent.UpdateIngridientList();
    }

    public void FinishedRecipe()
    {
        _currentRecipe = null;
        _currentRecipe = LevelController.Instance.RecipeManager.SelectRandomRecipe();
        _audioSource.PlayOneShot(finishedClip);
        ChangeRecipe(_currentRecipe);
    }

    public void AddIngredient(PlayerController.Player player, IngredientScriptable ingredient)
    {
        if (_isCooking == false )
        {
            _cookingTime = _originalCookingTime;
            _animator.SetTrigger("Start Cooking");
            _audioSource.PlayOneShot(cookingClip);
            _ingredientsUsed++;

            if (player == _owner) // Olla del jugador.
            {
                ingredientOwner++;
                Debug.Log($"[{player}]: Agrego {ingredient.name} a su olla.");

                if (_neededIngredients.Contains(ingredient))
                {
                    _neededIngredients.Remove(ingredient);
                    // Tachar ingrediente


                    LevelController.Instance.ScoreManager.PlayerScore(player, 50);
                    Debug.Log($"[{player}]: Ingrediente Correcto. || +50");
                }

                else
                {


                    LevelController.Instance.ScoreManager.PlayerScore(player, -20);
                    Debug.Log($"[{player}]: Ingrediente Incorrecto. || -20");
                }
            }

            else // Olla del rival.
            {
                ingredientEnemy++;
                Debug.Log($"[{player}]: Agrego {ingredient.name} a la olla enemiga.");

                if (_neededIngredients.Contains(ingredient)) // Ingrediente Correcto
                {
                    _neededIngredients.Remove(ingredient);

                    LevelController.Instance.ScoreManager.EveryoneScore(30);
                    Debug.Log($"[{player}]: Ingrediente Correcto. || +30"); // Nos suma puntos a ambos.
                }

                else
                {
                    LevelController.Instance.ScoreManager.PlayerScore(player, 15);
                    Debug.Log($"[{player}]: Ingrediente Incorrecto. || +15"); // Nos suma puntos, no al enemigo.
                }
            }
        }

        else
        {
            Debug.Log("Not Ready!");
        }
    }

    public void ShowIngredients()
    {
        _uiAnimator.SetBool("Show", true);
    }

    public void HideIngredients()
    {
        _uiAnimator.SetBool("Show", false);
    }
}
