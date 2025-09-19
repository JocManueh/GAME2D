using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D _Rigidbody2D;
    public float horizontal;
    public float speed = 1f;
    public float jumpForce = 3f;
    private bool isGrounded;

    public Animator animator; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Movement", horizontal*speed);
        _Rigidbody2D.linearVelocity = new Vector2(horizontal * speed, _Rigidbody2D.linearVelocity.y);

        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
    
