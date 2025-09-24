using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    public float horizontal;
    public float speed = 1f;
    public float jumpForce = 3f;
    private bool isGrounded;
    public Animator animator;
    [Header("Ground Check")]
    public Transform groundCheck;     // Un empty object bajo los pies del personaje
    public float groundRadius = 0.2f; // Radio de detección
    public LayerMask groundLayer;     // Capa del suelo
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

        // Mover la lógica de salto aquí para mejor detección de input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        animator.SetFloat("Movement", horizontal * speed);
        _Rigidbody2D.linearVelocity = new Vector2(horizontal * speed, _Rigidbody2D.linearVelocity.y);

        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Actualizar el estado de salto en el animator
        if (isGrounded && _Rigidbody2D.linearVelocity.y <= 0)
        {
            animator.SetBool("isJumping", false);
        }
    }
}