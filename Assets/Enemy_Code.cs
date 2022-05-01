using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCOde : MonoBehaviour
{
    public float speed = 0.5f;
    public float radius = 5;
    int direction = 1;
    int mode = 0;
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    public Transform feet;
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Collider2D[] closeColliders = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);
        if (closeColliders.Length > 0)
        {
            mode = 1;
        }
        else
        {
            mode = 0;
        }
        if (mode == 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, 2, groundLayer);
            if (hit.collider == null)
            {
                direction *= -1;
                transform.localScale *= new Vector2(-1, 1);
            }
            _rigidbody2D.velocity = new Vector2(speed * direction, _rigidbody2D.velocity.y);
        }
        else if (mode == 1)
        {
            Vector2 playerPos = closeColliders[0].transform.position;
            if (transform.position.x - playerPos.x > 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, 2, groundLayer);
            if (hit.collider != null)
            {
                _rigidbody2D.velocity = new Vector2(speed * direction, _rigidbody2D.velocity.y);

            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
            if ((transform.position.x > playerPos.x && transform.localScale.x > 0) || (transform.position.x < playerPos.x && transform.localScale.x < 0))
            {
                transform.localScale *= new Vector2(-1, 1);
            }
        }
    }
}


    
