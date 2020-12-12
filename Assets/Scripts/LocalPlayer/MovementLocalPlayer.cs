using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLocalPlayer : MonoBehaviour
{
    private Rigidbody localRigid;

    private Vector3 JumpDirection = new Vector3(0, 1, 0);
    private Vector3 RightDirection = new Vector3(1, 0, 0);
    private Vector3 LeftDirection = new Vector3(-1, 0, 0);

    private bool canJump = true;

    [Tooltip("Force of the jump")]
    public float jumpForce;

    [Tooltip("Force of movement left and right")]
    public float MovementForce;

    void Start()
    {
        localRigid = gameObject.GetComponent<Rigidbody>();
    }

    public void Jump(){
        if (!canJump) return;

        localRigid.AddForce(JumpDirection*jumpForce, ForceMode.VelocityChange);
        Debug.Log("Jumping");
    }

    public void CanJump(bool __canJump){
        this.canJump = __canJump;
    }

    public void MoveRight(){
        localRigid.AddForce(RightDirection*MovementForce, ForceMode.VelocityChange);
    }

    public void MoveLeft(){
        localRigid.AddForce(LeftDirection*MovementForce, ForceMode.VelocityChange);
    }
}
