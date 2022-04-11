using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayerCode : MonoBehaviour
{
    // 第一节 platformer intro recording ：
    // spritesheet & character
    // player movement left and right flipping
    // walking shooting and jumping animation
    // moving platforms

    public int speed = 5;
    public int jumpForce = 300;
    //int jumps = 1;     double jump (2)
    Rigidbody2D _rigidbody;
    Animator _animator;
    public Transform feet; //assigned with empty game object and tag on the player's feet
    public LayerMask groundLayer;
    public bool isGrounded = false;//bool checks if a statement is true or false
                                   //// public GameObject FallingPlatform;

    //public HealthManager healthmanager;


    /* jump on the wal
    public float wallJumpTime = 0.2f;//walk jump time allows you : when you let go of the wall you are still able to jump forward
    public float wallSlideSpeed = 0.3f;
    public float wallDistance = 0.5f;
    bool isWallSliding = false;
    RaycastHit2D WallCheckHit;*/

    //audio effect/music
    AudioSource _audioSource;
    public AudioClip catAttackSound;


    //making your character flipp when they are walking in whichever direction,
    //* have negative scale when its moving backwards and positive scale when its moving forward
    Vector2 left;
    Vector2 right;



    // Start is called before the first frame update
    void Start()
    {
        right = transform.localScale;
        left = new Vector2(-transform.localScale.x, transform.localScale.y);
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();//add more codes onto "fire" if your player will fire



    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        //rb.velocity = new Vector2(xSpeed, 0);//move character left and right but now there is a bug that the player won't drop on the platform because the y is "0" there every frame it will reset velocity
        _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);// character drop onto the platform and slide left and right
                                                                         //remember to go to contraints in the rigid body inspector and lock z : the player can stop at the edge 

        if (xSpeed < 0 && transform.localScale.x > 0)
        {
            transform.localScale = left;
        }
        else if (xSpeed > 0 && transform.localScale.x < 0)
        {
            transform.localScale = right;
        }

        _animator.SetFloat("Speed", Mathf.Abs(xSpeed));//you want an abosolute value of the x  speed or else now it is only walking on the right not the lef

        isGrounded = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);
        _animator.SetBool("Grounded", isGrounded);// my jumping function does not work for some reason*
        // if overlapp it is checking true or false
        /* if (Input.GetButtonDown("Jump"))//jump function (flappying bird where you can jump with space if jump a lot you kinda fly

         {
             rb.AddForce(new Vector2(0,jumpForce));
         }*/

        /* this function allows player to double jump 
         * 
         * if(isGrounded){
         * jumps = 2;
         * }
         * 
         * if ( Input.GetButtonDown("Jump") && jumps > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x,0);
         jumps --; //everytime it minus one and jumps recharge as soon it touches the ground
           
        }
         * 
         * 
     
         */


        if (Input.GetButtonDown("Jump") && isGrounded)//force jump while grounded on the ground floor
        {//remember to tag ground in ground layer that are created then drag ground to "ground" in player inspecter
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0); //set velocity to 0 before addforce there the player won't jump extra or launch themselves after pressing on jump mutiple time
            _rigidbody.AddForce(new Vector2(0, jumpForce));

        }
        //wall jumpy
        /* if (right)
         {
             WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, groundLayer);
         }*/
    }
}
//two thingg might happen when you make a platformer: when you press on the side of the platformer zhang ai wu it will stick to it on the side if you take friction off it will stick on the top
//in a lot of games you can jump in front of something and land on top of it  with default, you can't jump through the thing instead jumping on top
// the solution of preventing these two from happenning is platformer effector 2d then click on used by effector in inspector

//creatinig a bullet shooting function

/* select any bullet sprite or cube + box collider 2d + rigid body 2d in the inspector

coding <<<<<< on public

public GameObject bulletPrefab;
public int bulletForce = 200; //bullet speed
public Transform spawnPoint;

down in update 

if(Input.GetButtonDown("Fire1")){
GameObeject newBullet = Instantiate(bulletPrefab, spawnPoint.position,Quaternion.identity);
newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2 (transform.localScale.x, 0));
_animator.SetTrigger("Shoot");
// add force of the direction where the bullet is shooting at 

}

remember to drag the bulletprefab into the inspector from asset or heiarchy

set gravity of bullet in rigidbody 2d to 0 

remember to drag spawnPoint empty object to the inspector box


animation ---> create new clip ----> shoot 
create a transition from any state to shoot
add perameter ----> trigger ---> called "shoot"
set all of the things in the transition from "any state" to "shoot" to 0
add shooting condition

then create an transition back from "shoot" to "idol state"
this one we will leave the exit time on

a trigger fires once

Add cinemachine from packaged manager

 
 */





/*第二节 老师改了改code 例如anim 和 rb 变成 "_animator" and " _rigidbody"
 // camera
 //a little more animations on shooting and jumping and such
 * 
 * 
 * code :
 * void Update(）{
 * 
 * //moving left and right 
 * 
 * float xSpeed = Input.GetAxisRaw("Horizontal“）*speed;
 * _rigidbody.velocity = new Vector2(xSpeed, _rigidbody.velocity.y);
 * _animator.SetFloat("Speed", Mathf.Abs(xSpeed));
 * 
 *   // inverting the gameobject x scale to turn around
 *   
 *   <<<this code is checking 4 things 
 *   1. if my speed is telling me to go backwards but my scale was frontwards then i know i need to flipp it*
 *    || = or
 *   2. if my scale is forward but my speed is backwards, i also need to flipp it
 *   
 *   <<< this code is better than the week before because the scale of the platform will inherent the scale of the player
 *   as the player enters the platform as a results of the player scale being stretched out. this is more rigid and less flexible
 *   
 *   if((xSpeed < 0 && transform.localScale.x > 0) || (xSpeed > 0 && transform.localScale.x < 0)) {
 *   transform.localScale *= new Vector (-1,1); 
 *   }
 *   
 *   //checking if the player is touching the ground
 *   
 *   grounded = Physics2D.OverlapCircle(feet.position, .5f, groundLayer);
 *   
 *   //jumping
 *   
 *   if(Input.GetButtonDown("Jump") && grounded){
 *   _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
 *   _rigidbody.AddForce(new Vector ( 0, jumpForce));
 *   }
 *   _animator.SetBool("Grounded", grounded);
 *   
 *   //shooting
 *   if(Input.GetButtonDown( "Fire1")){
 *   GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
 *   newBullet.GetComponent<Rigidbody>().AddForce(new Vector2(transform.localScale.x * bulletForce, 0 ));
 *   animator.SetTrigger("Shoot");
 *   
 * 
 * 
 * 
 */



/* 
 * Having the player stick to a moving platform is to make the player a child of the platform
 * 
 * PlatformBackForth
 * 
 * public float speed = .5f;
 * public float distance = 5;
 * private float startPosition;
 * 
 * void Start(){
 * startPosition = transform.position.x;
 * }
 * 
 * void Update(){
 * 
 * Vector2 new Position = transform.position;
 * newPosition.x = Mathf.SmoothStep(startPosition, startPosition + distance, Mathf.PingPong(Time.time * speed, 1);
 * tranform.position = newPosition;
 * 
 * 
 *   //pingpong moves nice back and forth from 0 - 1 for example
 *   //time.time counts whhat the time is like delta time
 *   //smooth step slows it down when you get towards the edge or the end before you burst : ease in and ease out
 *   //smoothstep are also moving in two position
 *   
 *   
 * }
 * 
 *   ///stick to the platform
 * 
 * void OnCollisionEnter2D(Collision2D other){
 * if(othergameObject.CompareTag("Player"))              //if player collides with the platform
 * {
 * other.transform.SetParent(transform);                // then "other" is the player, make the player a child of the platform
 * }
 * }
 * 
 *  void OnCollisionExit2D(Collision2D other){          //when the collision stops, you turn the parenting off
 * if(othergameObject.CompareTag("Player"))
 * {
 * other.transform.SetParent(null);
 * }
 * }
 * 
 */

/*
 * bullets need to be triggers in the inspector* it also has a rigidbody
 * if you have two triggers without rigidbodies they won't work 
 * the enemy don have a trigger but there is a rigidbody it should be fine
 * 
 * 
 * EnemyCode 
 * <<<               this code works on killing an enemy when you shoot an enemy, they get destroyed          >>>>
 * 
 * private void OnTriggerEnter2D (Collider2D other){
 * if(other. CompareTag("Bullet")){
 * Destroy (other.gameObject);
 * Destory (gameObject);
 * }
 * 
 */

}


