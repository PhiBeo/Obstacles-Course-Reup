using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform orientation;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject killzone;

    private float horizontalSpeed;
    private float verticalSpeed;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    [SerializeField] private float airDrag;

    private bool isJumping; 
    private float defaultAirMultiplier;

    [Header("Ground Check")]
    [SerializeField] private float groundDrag;

    private bool isGrounded = true;

    private Vector3 respawnPoint;

    private void Start()
    {
        respawnPoint = this.transform.position;
        defaultAirMultiplier = airMultiplier;
    }


    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");

        //isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else if (!isGrounded)
        {
            rb.drag = airDrag;
        }

        if (Input.GetKey(KeyCode.Space) && !isJumping && isGrounded)
        {
            isJumping = true;

            Jump();

            Invoke(nameof(JumpReset), jumpCooldown);
        }

        killzone.transform.position = new Vector3(transform.position.x, killzone.transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        Vector3 movingDirection = orientation.forward * verticalSpeed + orientation.right * horizontalSpeed;

        if(isGrounded)
            rb.AddForce(movingDirection.normalized * speed * 10f, ForceMode.Force);

        if (!isGrounded)
        {
            rb.AddForce(movingDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
        } 
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x,0f ,rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void JumpReset()
    {
        isJumping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Killzone")
        {
            rb.velocity = Vector3.zero;
            transform.position = respawnPoint;
        }
        if (collision.gameObject.tag == "Platform")
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }

    public void setRespawnPoint(Vector3 respawn)
    {
        respawnPoint = respawn;
    }
}
