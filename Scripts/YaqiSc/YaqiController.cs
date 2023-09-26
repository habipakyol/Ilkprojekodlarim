using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaqiController : GenericBehaviour
{
    public float walkSpeed = 0.15f;
    public float runSpeed = 1.0f;
    public float sprintSpeed = 2.0f;
    public float speedDampTime = 0.1f;
    public string jumpButton = "Jump";
    public float jumpHeight = 1.5f;
    public float jumpIntertialForce = 10f;

    private float speed, speedSeeker;
    private int jumpBool;
    private int groundedBool;
    private bool jump;
    private bool isColliding;

    private bool isAttacking;
    private bool isSpinattacking;
    private bool isCasting;
    void Start()
    {
        jumpBool = Animator.StringToHash("Jump");
        groundedBool = Animator.StringToHash("Grounded");
        behaviourManager.GetAnim.SetBool(groundedBool, true);

        behaviourManager.SubscribeBehaviour(this);
        behaviourManager.RegisterDefaultBehaviour(this.behaviourCode);
        speedSeeker = runSpeed;

    }

    void Update()
    {
        if (!jump && Input.GetButtonDown(jumpButton) && behaviourManager.IsCurrentBehaviour(this.behaviourCode) && !behaviourManager.IsOverriding())
        {
            jump = true;
        }

        if (!isAttacking && Input.GetKey(KeyCode.Alpha1))
        {
            isAttacking = true;
            behaviourManager.GetAnim.SetBool("Attack", true);
        }
        if (!isSpinattacking && Input.GetKey(KeyCode.Alpha2))
        {
            isSpinattacking = true;
            behaviourManager.GetAnim.SetBool("SpinAttack", true);
        }
        if (!isCasting && Input.GetKey(KeyCode.Alpha3))
        {
            isCasting = true;
            behaviourManager.GetAnim.SetBool("Casting", true);
        }

    }

    public override void LocalFixedUpdate()
    {
        MovementManagement(behaviourManager.GetH, behaviourManager.GetV);
        JumpManagement();

        if (isAttacking && !Input.GetKey(KeyCode.Alpha1))
        {
            isAttacking = false;
            behaviourManager.GetAnim.SetBool("Attack", false);
        }
        if (isSpinattacking && !Input.GetKey(KeyCode.Alpha2))
        {
            isSpinattacking = false;
            behaviourManager.GetAnim.SetBool("SpinAttack", false);
        }
        if (isCasting && !Input.GetKeyUp(KeyCode.Alpha3))
        {
            isCasting = false;
            behaviourManager.GetAnim.SetBool("Casting", false);
        }
        
    }

    void JumpManagement()
    {
        if (jump && !behaviourManager.GetAnim.GetBool(jumpBool) && behaviourManager.IsGrounded())
        {
            behaviourManager.LockTempBehaviour(this.behaviourCode);
            behaviourManager.GetAnim.SetBool(jumpBool, true);
            if (behaviourManager.GetAnim.GetFloat(speedFloat) > 0.1)
            {
                GetComponent<CapsuleCollider>().material.dynamicFriction = 0f;
                GetComponent<CapsuleCollider>().material.staticFriction = 0f;
                RemoveVerticalVelocity();
                float velocity = 2f * Mathf.Abs(Physics.gravity.y) * jumpHeight;
                velocity = Mathf.Sqrt(velocity);
                behaviourManager.GetRigidBody.AddForce(Vector3.up * velocity, ForceMode.VelocityChange);
            }
        }

        else if (behaviourManager.GetAnim.GetBool(jumpBool))
        {

            if (!behaviourManager.IsGrounded() && !isColliding && behaviourManager.GetTempLockStatus())
            {
                behaviourManager.GetRigidBody.AddForce(transform.forward * jumpIntertialForce * Physics.gravity.magnitude * sprintSpeed, ForceMode.Acceleration);
            }

            if ((behaviourManager.GetRigidBody.velocity.y < 0) && behaviourManager.IsGrounded())
            {
                behaviourManager.GetAnim.SetBool(groundedBool, true);
                GetComponent<CapsuleCollider>().material.dynamicFriction = 0.6f;
                GetComponent<CapsuleCollider>().material.staticFriction = 0.6f;
                jump = false;
                behaviourManager.GetAnim.SetBool(jumpBool, false);
                behaviourManager.UnlockTempBehaviour(this.behaviourCode);
            }
        }
    }
    void MovementManagement(float horizontal, float vertical)
    {
        if (behaviourManager.IsGrounded())
            behaviourManager.GetRigidBody.useGravity = true;
        else if (!behaviourManager.GetAnim.GetBool(jumpBool) && behaviourManager.GetRigidBody.velocity.y > 0)
        {
            RemoveVerticalVelocity();
        }
        Rotating(horizontal, vertical);
        Vector2 dir = new Vector2(horizontal, vertical);
        speed = Vector2.ClampMagnitude(dir, 1f).magnitude;
        speedSeeker += Input.GetAxis("Mouse ScrollWheel");
        speedSeeker = Mathf.Clamp(speedSeeker, walkSpeed, runSpeed);
        speed *= speedSeeker;
        if (behaviourManager.IsSprinting())
        {
            speed = sprintSpeed;
        }

        behaviourManager.GetAnim.SetFloat(speedFloat, speed, speedDampTime, Time.deltaTime);
    }
    private void RemoveVerticalVelocity()
    {
        Vector3 horizontalVelocity = behaviourManager.GetRigidBody.velocity;
        horizontalVelocity.y = 0;
        behaviourManager.GetRigidBody.velocity = horizontalVelocity;
    }
    Vector3 Rotating(float horizontal, float vertical)
    {
        Vector3 forward = behaviourManager.playerCamera.TransformDirection(Vector3.forward);
        forward.y = 0.0f;
        forward = forward.normalized;
        Vector3 right = new Vector3(forward.z, 0, -forward.x);
        Vector3 targetDirection;
        targetDirection = forward * vertical + right * horizontal;
        if ((behaviourManager.IsMoving() && targetDirection != Vector3.zero))
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            Quaternion newRotation = Quaternion.Slerp(behaviourManager.GetRigidBody.rotation, targetRotation, behaviourManager.turnSmoothing);
            behaviourManager.GetRigidBody.MoveRotation(newRotation);
            behaviourManager.SetLastDirection(targetDirection);
        }
        if (!(Mathf.Abs(horizontal) > 0.9 || Mathf.Abs(vertical) > 0.9))
        {
            behaviourManager.Repositioning();
        }

        return targetDirection;
    }

    private void OnCollisionStay(Collision collision)
    {
        isColliding = true;

        if (behaviourManager.IsCurrentBehaviour(this.GetBehaviourCode()) && collision.GetContact(0).normal.y <= 0.1f)
        {
            GetComponent<CapsuleCollider>().material.dynamicFriction = 0f;
            GetComponent<CapsuleCollider>().material.staticFriction = 0f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
        GetComponent<CapsuleCollider>().material.dynamicFriction = 0.6f;
        GetComponent<CapsuleCollider>().material.staticFriction = 0.6f;

    }
}
