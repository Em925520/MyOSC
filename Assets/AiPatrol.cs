using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    public float walkSpeed = 10;
    private bool mustTurn;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(mustPatrol)
        {
            Patrol();
       
            mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
        }
    }

        
    
    void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }
}
