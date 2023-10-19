using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonCharacterController : MonoBehaviour
{
    //Reference to the camera
    public Camera Cam;

    //Variables for firing the laser
    public LaserInteract Interact;
    public LaserAnimation shoot;
    public bool FireLaser;

    //Variables for force pushing
    public ForcePush push;
    public ForcePushTwo pushtwo;

    //Variables for moving speed and acceleration
    public float moveSpeed = 5;
    public float moveAcceleration = 10;

    //Variables for jumping speed and the time possible
    public float jumpSpeed = 5;
    public float jumpMaxTime = 0.5f;
    private float jumpTimer = 0;

    //Variables for attacking range
    public Transform attackRangeAnchor;
    public Vector3 attackRangeSize;

    //Reference to the character controller
    private CharacterController characterController;

    //Variables for moving and velocity
    private Vector2 moveInput = Vector2.zero;
    private Vector2 currentHorizontalVelocity = Vector2.zero;
    private float currentVerticalVelocity = 0;

    //Input bools
    private bool jumpInputPressed = false;
    private bool attackInputPressed = false;
    private bool laserInputHeld = false;

    //Checking bools
    private bool isJumping = false;
    public bool canControl = true;

    private void Awake()
    {
        //Locks the cursor and makes it invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Getting the character controller off the player
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Checking for the can control bool from the cinematic script
        if (canControl)
        {
            //Taking input and applying it to the camera direction
            Vector3 cameraSpaceMovement = new Vector3(moveInput.x, 0, moveInput.y);
            cameraSpaceMovement = Cam.transform.TransformDirection(cameraSpaceMovement);

            //Putting the camera movement on the x and z axis and putting it into a Vector2
            Vector2 cameraHorizontalMovement = new Vector2(cameraSpaceMovement.x, cameraSpaceMovement.z);

            //Lerping movement so it looks smooth
            currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, cameraHorizontalMovement * moveSpeed, Time.deltaTime * moveAcceleration);

            //Checking if jumping is happening or not
            if (isJumping == false)
            {
                //Adds gravity to the player for jumping
                currentVerticalVelocity += Physics.gravity.y * Time.deltaTime;

                //Chekcing if the player is on the ground and that they have 0 vertical velocity
                if (characterController.isGrounded && currentVerticalVelocity < 0)
                {
                    //Adds gravity to the player for jumping
                    currentVerticalVelocity = Physics.gravity.y * Time.deltaTime;
                }
            }
            else
            {
                //Adding to jumptimer by time.deltatime
                jumpTimer += Time.deltaTime;

                //If the jump timer is greater than max jump time they can no longer jump any higher
                if (jumpTimer >= jumpMaxTime)
                {
                    isJumping = false;
                }
            }

            //Applying the movement inputs to the character controller
            Vector3 currentVelocity = new Vector3(currentHorizontalVelocity.x, currentVerticalVelocity, currentHorizontalVelocity.y);
            characterController.Move(currentVelocity * Time.deltaTime);

            //Calling rotation of the character
            RotateCharacter();
        }
    }

    public void OnMove(InputValue value)
    {
        //Taking the move value into a vector2
        moveInput = value.Get<Vector2>();
    }

    public void OnJump (InputValue value)
    {
        //Getting the jump input and taking it into a float
        jumpInputPressed = value.Get<float>() > 0;

        //Checking if the jump input is pressed
        if (jumpInputPressed)
        {
            //Checking if the player is grounded
            if(characterController.isGrounded)
            {
                //Sets jumping to true as the player is jumping
                isJumping = true;

                //Setting jump timer to 0
                jumpTimer = 0;

                //Making the curren vertical velocity the jump speed
                currentVerticalVelocity = jumpSpeed;
            }
        }
        else
        {
            //If player is jumping then set set it to false when they land
            if (isJumping)
            {
                isJumping = false;
            }
        }
    }

    public void OnAttack(InputValue value)
    {
        //Taking the input for jumping and putting it into a float
       attackInputPressed = value.Get<float>() > 0;

        //If the attack input is pressed then it will enter this statement
        if (attackInputPressed)
        {
            //Checking if the attack range overlaps the attackble item then attacks
            OverlapAttackCheck();
            push.ForcePushes();
            pushtwo.ForcePushes();
        }

    }

    public void OnLaser(InputValue value)
    {
        //Taking the input for shooting the laser and setting as a value that is only activated when pressed
        laserInputHeld = value.isPressed;

        //If the laser input is held then it will go into this statement
        if (laserInputHeld)
        {
            //Setting interact active
            Interact.IsActive = true;

            //Fire laser is true which will allow the animation to play
            FireLaser = true;
            shoot.LaserShootAnimation(FireLaser);
        }
        //If the laser input let go then it will go into this statement
        else if (!laserInputHeld)
        {
            //Setting interact inactive
            Interact.IsActive = false;

            //Fire laser is false which will play the ending animation
            FireLaser = false;
            shoot.LaserShootAnimation(FireLaser);
        }
    }

    private void OverlapAttackCheck()
    {
        //Checks if the collider for attacking is overlapping with the collider of the item it will attack
        Collider[] overlapItems = Physics.OverlapBox(
                                        attackRangeAnchor.transform.position,
                                        attackRangeSize / 2,
                                        attackRangeAnchor.transform.rotation,
                                        Physics.AllLayers,
                                        QueryTriggerInteraction.Ignore);

        if (overlapItems.Length > 0)
        {
            //Checking each overlapped items for their ability to attack and then sending a message to do so
            foreach (Collider item in overlapItems)
            {
                Vector3 direction = item.transform.position - transform.position;
                item.SendMessage("OnPlayerAttack", direction, SendMessageOptions.DontRequireReceiver);

            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Draws a gizmo to represent the attack range
        if (attackRangeAnchor != null)
        {
            Gizmos.color = new Vector4(1, 0, 0, 0.5f);
            Gizmos.DrawCube(attackRangeAnchor.transform.position, attackRangeSize);
        }
    }

    private void RotateCharacter()
    {
        //Calculates the looking direction
        Vector3 lookDirection = new Vector3(currentHorizontalVelocity.x, 0, currentHorizontalVelocity.y).normalized;

        //Checks if the look direction's magnitude is slightly larger than 0
        if (lookDirection.magnitude > 0.001f)
        {
            //Updates rotation based on the look direction
            Quaternion newRotation = Quaternion.LookRotation(lookDirection);

            //Slerps the rotation so it is smooth
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * moveAcceleration);
        }
    }
}
