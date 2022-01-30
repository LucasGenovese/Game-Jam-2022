using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public float Speed;

    private float Vertical;
    private float Horizontal;
    private bool Ladder;
    [Header("Steps")]
    [SerializeField] private float _stepTime;
    [SerializeField] private float _originalStepTime;
    [SerializeField] private ParticleSystem _particles;

    [Header("Extras")]

    [SerializeField] private bool Grounded;

    private PlayerController playerController;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Animator _animator;
    [SerializeField] private Container currentContainer;
    [SerializeField] private IngredientScriptable currentIngredient;
    [SerializeField] private Stove stove;
    [SerializeField] private GameObject trash;
    [SerializeField] private PlayerSounds playerSounds;

    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] private bool isOnline = false;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        isOnline = GetComponent<PlayerController>().isOnline;
        _originalStepTime = _stepTime;
        _stepTime = 0;
    }

    private void Update()
    {
        if (!isOnline)
        {
            ReadInput();
        }
    }


    public void ReadInput()
    {
        // GROUNDED
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.75f, groundLayers))
        {
            Grounded = true;
        }         
        else
        {
            Grounded = false;
        }

        // CLIMBING
        if (!Ladder == false)
        {
            _animator.SetBool("isClimbing", false);
        } 

        // CLIMB
        if (Input.GetKey(upKey) && Ladder == true)
        {
            _animator.SetBool("isClimbing", true);
            Rb.velocity = new Vector2(0, Speed);
        }

        // JUMP
        if (Input.GetKeyDown(upKey) && Grounded)
        {
            Rb.velocity = Vector2.up * Speed;
            playerSounds.AudioJump();
        }

        // FALL
        if (Input.GetKey(downKey) && Ladder == true)
        {
            _animator.SetBool("isClimbing", true);
            Rb.velocity = new Vector2(Rb.velocity.x, -Speed);
        }

        // LEFT & RIGHT
        if (Input.GetKey(rightKey))
        {
            _animator.SetBool("isWalking", true);
            Rb.velocity = new Vector2(Speed, Rb.velocity.y);
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        } else
        {
            _animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(leftKey))
        {
            _animator.SetBool("isWalking", true);
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y);
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        // INGREDIENT
        if (currentContainer != null && currentIngredient == null)
        {
            if (Input.GetKey(interactKey))
            {
                currentIngredient = currentContainer.SelectIngredient();
                playerSounds.AudioInteractIngredient();
                _particles.Play();
                _animator.SetTrigger("Action");
            }
        }

        // STOVE
        if (stove != null && currentIngredient != null && stove.IsCooking == false)
        {
            if (Input.GetKey(interactKey))
            {
                stove.AddIngredient(playerController.PlayerType, currentIngredient);
                currentIngredient = null;
                playerSounds.AudioInteractStove();
                _particles.Stop();
                _animator.SetTrigger("Action");
            }
        }

        // TRASH
        if (trash != null &&  currentIngredient != null) // TRASH
        {
            if (Input.GetKey(interactKey))
            {
                currentIngredient = null;
                playerSounds.AudioInteractThrash();
                _particles.Stop();
                _animator.SetTrigger("Action");
            }
        }


        if (_animator.GetBool("isWalking") == true || _animator.GetBool("isClimbing") == true)
        {
            if (_stepTime > 0)
            {
                _stepTime -= Time.deltaTime;
            }

            else
            {
                playerSounds.AudioStep();
                _stepTime = _originalStepTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            Ladder = true;
        }

        if (other.gameObject.tag == "Trash")
        {
            trash = other.gameObject;
        }

        if (other.gameObject.tag == "Container")
        {
            currentContainer = other.GetComponent<Container>();
        }

        if (other.gameObject.CompareTag("Stove"))
        {
            stove = other.GetComponent<Stove>();
            //stove.ShowIngredients();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            Ladder = false;
            _animator.SetBool("isClimbing", false);
        }

        if (collision.gameObject.tag == "Trash")
        {
            trash = null;
        }

        if (collision.gameObject.tag == "Container")
        {
            currentContainer = null;
        }

        if (collision.gameObject.tag == "Stove")
        {
            //stove.HideIngredients();
            stove = null;
        }
    }

}
