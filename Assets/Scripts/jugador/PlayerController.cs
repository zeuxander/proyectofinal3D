
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpForce;
    public float gravityScale = 5f;

    public float rotateSpeed = 5f;

    private Vector3 moveDirection;

    public CharacterController charController;
    public Camera playerCamera;
    public GameObject playerModel;

    public Animator animator;

    public bool isKnocking;
    public float knockBackLength = .5f;
    public float knockBackCounter;
    public Vector2 knockbackPower;


    private void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        if(!isKnocking)
        {
            float yStore = moveDirection.y;
            //movimiento
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection.Normalize();
            moveDirection = moveDirection * moveSpeed;
            moveDirection.y = yStore;


            //salto
            if (charController.isGrounded)
            {

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump") && animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "SimpleJump")
                {
                    moveDirection.y = jumpForce;
                    animator.SetTrigger("DoubleJump");
                }
            }


            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
            charController.Move(moveDirection * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            }

        }
        if(isKnocking)
        {
            knockBackCounter -= Time.deltaTime;

            float yStore = moveDirection.y;
            moveDirection = (playerModel.transform.forward * knockbackPower.x);
            moveDirection.y = yStore;

            moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

            charController.Move(moveDirection * Time.deltaTime);

            if (knockBackCounter <=0)
            {
                isKnocking = false;
            }
        }
       

        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        animator.SetBool("Grounded", charController.isGrounded);

    }

    public void Knockback()
    {
        isKnocking = true;
        knockBackCounter = knockBackLength;
        Debug.Log("knoicoked back");
        moveDirection.y = knockbackPower.y;
        charController.Move(moveDirection * Time.deltaTime);
    }
}