using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float speed;
    public float distanceBtwPlayer;

    public bool isMovingRight;

    public Transform player;
    Animator anim;

    public bool isPlayerInRange;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if(player == null)
        {
            player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            LookTowardsPlayer();
            MoveTowardsThePlayer();
        }
    }

    //A method to look towards the target!
    private void LookTowardsPlayer()
    {
        if (transform.position.x > player.transform.position.x && isMovingRight)
        {
            isMovingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (transform.position.x < player.transform.position.x && !isMovingRight)
        {
            isMovingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    //Move towards the player [Simple as that] ^^
    private void MoveTowardsThePlayer()
    {
        //Move towards the player if the distance is less
        if (Vector2.Distance(transform.position, player.transform.position) > distanceBtwPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            anim.SetBool("Run", true);
        }
        //STOPP!!!! WITH SOME FIRE RATE!!!!
        else if (Vector2.Distance(transform.position, player.transform.position) <= distanceBtwPlayer)
        {
            anim.SetBool("Run", false);
        }
    }

    /* private void Patrol()
     {
         transform.Translate(Vector2.right * speed * Time.deltaTime);

         RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
         if (groundInfo.collider == false)
         {
             if (isMovingRight)
             {
                 transform.eulerAngles = new Vector3(0, -180f, 0);
                 isMovingRight = false;
             }
             else
             {
                 transform.eulerAngles = new Vector3(0, 0, 0);
                 isMovingRight = true;
             }
         }
     } */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Awake and do the things
            isPlayerInRange = true;
        }
    }


}
