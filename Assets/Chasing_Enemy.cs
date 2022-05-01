using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing_Enemy : MonoBehaviour
{
    public float speed = .05f;
    public float radius = 5;
    public LayerMask playerLayer;

    void FixedUpdate()
    {
        Collider2D[] closeColliders = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        if (closeColliders.Length > 0)
        {
            Vector2 playerPos = closeColliders[0].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, speed);

            if ((transform.position.x < playerPos.x && transform.localScale.x > 0) || (transform.position.x > playerPos.x && transform.localScale.x < 0))
            {
                transform.localScale *= new Vector2(-1, 1);
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}