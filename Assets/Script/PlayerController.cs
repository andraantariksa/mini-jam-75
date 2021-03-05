using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public bool isFacingRight;

    public bool isAbleToUseFireball = false;

    [Space]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //This line of code will control the jump power or DO the jump!!
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            var ability = GetComponent<IAbility>();
            if (ability != null)
            {
                ability.Cast(this);
            }
        }

        if (Input.GetKey(KeyCode.R) && isAbleToUseFireball)
        {
            // Spawn fireball
            Debug.Log("Fireball");
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);


        Move();
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Move()
    {
        moveInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        if (isFacingRight && moveInput > 0)
        {
            Flip();
        }
        else if (!isFacingRight && moveInput < 0)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

}
