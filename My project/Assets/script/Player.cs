using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;


    //jump adributes
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;
    private float crouchSpeed = 0.3f;



    //hardset jump as space
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    //ground and height vars
    [Header("Ground Check")]
    public float playerHeight;
    public float crouchHeight;
    public LayerMask whatIsGround;
    bool grounded;
    bool cantStand;
    bool _crouching;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    CapsuleCollider cc;
    public TMP_Text hpAmmount;
    float healt = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CapsuleCollider>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        cantStand = Physics.Raycast(transform.position, Vector3.up, playerHeight * 1f + 0.3f, whatIsGround);
        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        //crouch check
        if (!cantStand) _crouching = (Input.GetKey(KeyCode.C));


    }

    private void FixedUpdate()
    {
        var desiredHeught = _crouching ? crouchHeight : playerHeight;
        if (cc.height != desiredHeught)
        {
            adjustHeight(desiredHeught);
        }

        MovePlayer();
    }

    private void adjustHeight(float desiredHeught)
    {
        float center = desiredHeught / 2;
        cc.height = Mathf.Lerp(cc.height, desiredHeught, crouchSpeed);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, center, 1), crouchSpeed);

    }

    private void MyInput()
    {
        // get imput types from settings
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        float speed;

        if (_crouching) speed = moveSpeed / 2;
        else if (Input.GetKey(KeyCode.LeftShift)) speed = moveSpeed * 2;
        else speed = moveSpeed;
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);

        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }

    public void damaged()
    {
        healt--;
        hpAmmount.text = healt + "";
        if (healt == 0)
        {
            transform.gameObject.SetActive(false);
            endScreen.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<playerCamera>().freeMouse();

        }
    }
    public void levelCompleted()
    {
        //&& FindObjectOfType<Slot>().item
        if (rb.position.z < 125)
        {
            FindObjectOfType<Timer>().LevelCompleted();
            Debug.Log("It works!");
        }
    }

}