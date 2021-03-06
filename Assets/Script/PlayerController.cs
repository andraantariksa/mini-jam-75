using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float moveInput;
    [SerializeField] private bool isFacingRight;

    [Space]
    [SerializeField] public bool isGrounded;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] float checkRadius;

    [Header("Shooting Stuff")]
    [SerializeField] public Transform firePoint;

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

        if (Input.GetKey(KeyCode.Space))
        {
            var ability = GetComponent<IAbility>();
            if (ability != null)
            {
                Debug.Log("Cast");
                ability.Cast(this);
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            var ability = GetComponent<IAbility>();
            if (ability != null)
            {
                ability.Drop(this);
            }
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
        
        transform.Rotate(0f, 180f, 0f);
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
