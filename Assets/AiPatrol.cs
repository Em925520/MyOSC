using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    public float walkSpeed,range;
    private float disToPlayer;
    private bool mustTurn;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public Transform player;
    Animator enemy_attack;


    public GameObject Enemy;
    public Dragon_localControl dragonblowing_fire; //directly referencing the dragon local control script
    public GameObject OSCDragon;
    ///bool dragonblowing_fire = false;
    // Start is called before the first frame update
    private void Awake()//call before start
    {
        dragonblowing_fire = OSCDragon.GetComponent<Dragon_localControl>();
    }
    void Start()
    {
        mustPatrol = true;
        enemy_attack  = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       if(mustPatrol)
        {
            Patrol();
       
            mustTurn = !Physics2D.OverlapCircle(groundCheckPosition.position, 1f, groundLayer);
        }
    
       //this code makes the gameobject stick to the dragon as the dragon reach the range
   
        /*disToPlayer = Vector2.Distance(transform.position, player.position);//it automatically calculated the player distance in 2d
        if(disToPlayer <= range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed);
        }
        */


       // Debug.Log(disToPlayer);

        
          disToPlayer = Vector2.Distance(transform.position, player.position);//it automatically calculated the player distance in 2d
         if(disToPlayer <= range)//check if the player is closer than the range, if it is then attack()
         {
             if(player.position.x > transform.position.x && transform.localScale.x < 0 ||  //if player is on the left, you will want to flip t
                 player.position.x < transform.position.x && transform.localScale.x > 0)
             {
                 Flip();
               

            }
            mustPatrol = false;
            rb.velocity = Vector2.zero; //stops the velocity
              Attack();

        }
        else
        {
            mustPatrol = true;
            enemy_attack.SetBool("isattack", false);
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
       
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);   //before it was -1
        walkSpeed *=  -1;
       // float step = 10f * Time.deltaTime;
      //  transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }
    
      void Attack()
    {
       enemy_attack.SetBool("isattack", true);

        //transform.position = Vector2.MoveTowards(transform.position, player.position, walkSpeed); 
    }

  
    void OnCollisionEnter2D(Collision2D other)
        {// if the player touches the object then disable itself (it will disappear
        
        
         if (other.gameObject.CompareTag("Player") && dragonblowing_fire == true)
            {
               
                Destroy(Enemy); 
                Debug.Log("destoryed enemy ");
                // _audiosource.Play();
                ScoringSystem.theScore += 1; 
            }
           
        }
   

    /*
     * 
void OnTriggerEnter2D(Collider2D other)
    {// if the player touches the object then disable itself (it will disappear
        if (other.CompareTag("Player"))
        {
            if(dragonblowing_fire == true)
            {
                Destroy(gameObject);
            }
        }
    }


    */


}

//https://www.youtube.com/watch?v=Htw2f2eqLFk&t=0s