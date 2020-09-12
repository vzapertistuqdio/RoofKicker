using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    private float inputX;
    private float sensity = 4f;

    private Rigidbody playerRgb;
    private Animator playerAnim;
    private GroundChecker groundChecker;

    private float speed=6f;
    private float jumpForce = 6f;

    private IState playerState;

    private bool isFirstTime = true;

    private PhotonView photonView;

   

    private void Start()
    {
        playerRgb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        groundChecker = GetComponent<GroundChecker>();
        photonView = GetComponent<PhotonView>();
    }

    
    private void Update()
    {
        if (photonView.IsMine)
        {
        

        if (Input.GetMouseButton(0))
        {
            inputX = Input.GetAxis("Mouse X");
            playerRgb.velocity = new Vector3(transform.forward.x * speed, playerRgb.velocity.y, transform.forward.z * speed);
            Rotate();          
        }
            if (groundChecker.IsGrounded)
            {
                playerAnim.SetBool("isRun", true);
                isFirstTime = true;
                if (Input.GetMouseButtonDown(0))
                {
                    playerAnim.SetBool("isJump", true);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    playerAnim.SetBool("isJump", false);
                    Jump();
                }
                //playerRgb.velocity = new Vector3(transform.forward.x * speed, playerRgb.velocity.y, transform.forward.z * speed);
            }
            else
            {
                playerAnim.SetBool("isRun", false);
                if (isFirstTime)
                {
                    playerAnim.SetTrigger("isFalling");
                    isFirstTime = false;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    playerAnim.SetBool("isJump", true);
                }
            }
        }

       

    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles+Vector3.up*inputX*sensity);
    }
    private void Jump()
    {
        playerRgb.AddForce(Vector3.up*jumpForce*1.5f,ForceMode.Impulse);
        speed = jumpForce;
    }

    public void SetState(IState state)
    {
        playerState = state;
        speed = state.Speed;
    }

   
}
