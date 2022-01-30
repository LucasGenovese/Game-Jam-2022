using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public float Speed;

    private float Vertical;
    private float Horizontal;
    private bool Ladder;
    [SerializeField] private bool Grounded;

    private PlayerController playerController;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Animator _animator;
    [SerializeField] private Container currentContainer;
    [SerializeField] private IngredientScriptable currentIngredient;
    [SerializeField] private Stove stove;
    [SerializeField] private GameObject trash;

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
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.0f, groundLayers))
        {
            Debug.Log("Toca el piso");
            Grounded = true;
        } else
        {
            Debug.Log("No Toca el piso");
            Grounded = false;
        }

        if (!Ladder == false)
        {
            _animator.SetBool("isClimbing", false);
        } 

        // MOVEMENT
        if (Input.GetKey(upKey) && Ladder == true)
        {
            _animator.SetBool("isClimbing", true);
            Rb.velocity = new Vector2(0, Speed);
        }

        if (Input.GetKey(upKey) && Grounded)
        {
            Rb.velocity = Vector2.up * Speed;
        }

        if (Input.GetKey(downKey) && Ladder == true)
        {
            _animator.SetBool("isClimbing", true);
            Rb.velocity = new Vector2(Rb.velocity.x, -Speed);
        }
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

        // ACTIONS 
        if (currentContainer != null && currentIngredient == null)
        {
            if (Input.GetKey(interactKey))
            {
                currentIngredient = currentContainer.SelectIngredient();
                _animator.SetTrigger("Action");
            }
        }

        if (stove != null && currentIngredient != null && stove.IsCooking == false)
        {
            if (Input.GetKey(interactKey))
            {
                stove.AddIngredient(playerController.PlayerType, currentIngredient);
                currentIngredient = null;
                _animator.SetTrigger("Action");
            }
        }

        if (trash != null)
        {
            if (Input.GetKey(interactKey))
            {
                currentIngredient = null;
                _animator.SetTrigger("Action");
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
            stove.ShowIngredients();
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
            stove.HideIngredients();
            stove = null;
        }
    }

}
