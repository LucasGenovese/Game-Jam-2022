using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    public float Speed;

    private float Vertical;
    private float Horizontal;
    private bool Ladder;

    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] Rigidbody2D Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(upKey) && Ladder == true)
        {
            Rb.velocity = new Vector2(0, Speed);
        }

        if (Input.GetKey(downKey) && Ladder == true)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, -Speed);
        }

        if (Input.GetKey(rightKey))
        {
            Rb.velocity = new Vector2(Speed, Rb.velocity.y);
        }

        if (Input.GetKey(leftKey))
        {
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            Ladder = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            
            Ladder = false;
        }
            
    }

}