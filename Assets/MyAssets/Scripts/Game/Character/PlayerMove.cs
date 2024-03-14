using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] float horizontalMove, verticalMove, playerSpeed = 3.5f, rotationSpeed = .25f, jumpValue = 4f, shootOffset = .5f;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] Animator myAnim;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] bool canJump;
    public bool CanJump
    {
        get { return canJump; }
        set { canJump = value; }
    }
    void Awake()
    {
        playerRB = FindObjectOfType<Rigidbody>();
    }
    void Start()
    {
        canJump = false;
        myAnim.SetBool("idle", true);
        myAnim.SetBool("run", false);
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        moveDirection = new(horizontalMove, 0, verticalMove);
        moveDirection.Normalize();
        transform.position = transform.position + moveDirection * playerSpeed * Time.deltaTime;
        if (moveDirection != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed);
        AnimationsSett();
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(new(0, jumpValue, 0), ForceMode.Impulse);
            }
        }
    }
    void AnimationsSett()
    {
        if (horizontalMove != 0f || verticalMove != 0f)
        {
            myAnim.SetBool("idle", false);
            myAnim.SetBool("run", true);
        }
        else
        {
            myAnim.SetBool("idle", true);
            myAnim.SetBool("run", false);
        }
    }
}
/*
-------------------------------------------------------------------------------------------------------------------------------------------
    
    [SerializeField] float jumpForce = 4, fallVelY, horizontalMove, verticalMove, playerSpeed = 8f, gravity = 9.8f;
    [SerializeField] CharacterController player;
    [SerializeField] Vector3 playerInput, camForward, camRight, movePlayer;
    [SerializeField] Camera myCamera;
    [SerializeField] Animator myAnim;
    void Start()
    {
        myAnim.SetBool("idle", true);
        myAnim.SetBool("run", false);
    }
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        CameraPath();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer *= playerSpeed;
        player.transform.LookAt(player.transform.position + movePlayer);
        SetGravity();
        PlayerSkills();
        player.Move(movePlayer * Time.deltaTime);
        if (horizontalMove != 0.0f || verticalMove != 0.0f)
        {
            myAnim.SetBool("idle", false);
            myAnim.SetBool("run", true);
        }
        else
        {
            myAnim.SetBool("idle", true);
            myAnim.SetBool("run", false);
        }
    }
    void PlayerSkills()
    {
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelY = jumpForce;
            movePlayer.y = fallVelY;
        }
    }
    void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelY = -gravity * Time.deltaTime;
            movePlayer.y = fallVelY;
        }
        else
        {
            fallVelY -= gravity * Time.deltaTime;
            movePlayer.y = fallVelY;
        }
    }
    void CameraPath()
    {
        camForward = myCamera.transform.forward;
        camRight = myCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
*/