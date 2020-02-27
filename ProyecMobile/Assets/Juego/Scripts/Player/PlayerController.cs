using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    #region Private Variables
    [SerializeField]
    public float speed;
    [SerializeField]
    private float jumpSpeed = 15.0F;
    [SerializeField]
    private float gravity = 35.0F;
    private Vector3 moveDirection = Vector3.zero;
    #endregion

    #region Public Variables
    public Transform groundCheck;
    public LayerMask slope;
    public bool isSlope;
    public bool isJump;
    public float groundDistance;
    public bool pausa = false;

    // public Animator miAnim;
    #endregion

    #region Private Methods
    private void Start()
    {
        speed = 10f;
        controller = GetComponent<CharacterController>();
        isSlope = isJump = false;
    }
    void Update()
    {
        ControlPersonaje();
    }

    public void ControlPersonaje()
    {
        if (pausa == false)
        {
            if (controller.isGrounded)
            {
                moveDirection = transform.TransformDirection(new Vector3(speed, 0, 0));
                if (Input.GetButtonDown("Fire1"))
                {
                    moveDirection.y = jumpSpeed;
                    isJump = true;
                }
                else isJump = false;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);


            isSlope = Physics.CheckSphere(groundCheck.position, groundDistance, slope);
            if (isSlope == true)
            {
                PegarSuelo();
            }
        }
    }
    #endregion

    #region Public Methods
    public void PegarSuelo()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, .8f, Vector3.down, out hit, 1f))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + 0.9f, transform.position.z);
        }
    }
    #endregion
}
