using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 500.0f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded, facingRight = true;
    private float groundCheckRadius = 0.2f;
    
    // Variables for depth switching
    public float depthChangeAmount = 4.0f; // The amount to move in Z-depth
    private float[] depthLevels; // To store the depth levels

    private int currentDepthIndex = 1; // To keep track of the current depth level (0, 1, 2)

    public int levelsCount = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // Depth function
        depthLevels = new float[levelsCount];
        for (int i = 0; i < depthLevels.Length; i++)
        {
            depthLevels[i] = i * depthChangeAmount;
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float move = Input.GetAxis("Horizontal");
        if (animator != null)
        {
            animator.SetFloat("Speed", Mathf.Abs(move));
        }
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
            animator.SetTrigger("Jump");
        }
        
        // Depth functionality input 
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentDepthIndex < depthLevels.Length - 1)
        {
            // Move the character back in depth by 4 units
            currentDepthIndex++;
            ChangeDepth();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentDepthIndex > 0)
        {
            // Move the character forward in depth by 4 units
            currentDepthIndex--;
            ChangeDepth();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    // depth method
    private void ChangeDepth()
    {
        // Set the new Z position based on the current depth level
        Vector3 position = transform.position;
        position.z = depthLevels[currentDepthIndex];
        transform.position = position;
    }

}