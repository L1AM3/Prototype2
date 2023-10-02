using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class ThirdPersonCharacterController : MonoBehaviour
{
    public Camera cam;

    public float moveSpeed = 5;
    public float moveAcceleration = 10;

    public float jumpSpeed = 5;
    public float jumpMaxTime = 0.5f;
    private float jumpTimer = 0;

    public Transform attackRangeAnchor;
    public Vector3 attackRangeSize;

    private CharacterController characterController;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 currentHorizontalVelocity = Vector2.zero;
    private float currentVerticalVelocity = 0;

    private bool jumpInputPressed = false;
    private bool attackInputPressed = false;

    private bool isJumping = false;
    public bool canControl = true;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (canControl)
        {
            Vector3 cameraSpaceMovement = new Vector3(moveInput.x, 0, moveInput.y);
            cameraSpaceMovement = cam.transform.TransformDirection(cameraSpaceMovement);

            Vector2 cameraHorizontalMovement = new Vector2(cameraSpaceMovement.x, cameraSpaceMovement.z);

            currentHorizontalVelocity = Vector2.Lerp(currentHorizontalVelocity, cameraHorizontalMovement * moveSpeed, Time.deltaTime * moveAcceleration);

            if (isJumping == false)
            {
                currentVerticalVelocity += Physics.gravity.y * Time.deltaTime;

                if (characterController.isGrounded && currentVerticalVelocity < 0)
                {
                    currentVerticalVelocity = Physics.gravity.y * Time.deltaTime;
                }
            }
            else
            {
                jumpTimer += Time.deltaTime;

                if (jumpTimer >= jumpMaxTime)
                {
                    isJumping = false;
                }
            }

            Vector3 currentVelocity = new Vector3(currentHorizontalVelocity.x, currentVerticalVelocity, currentHorizontalVelocity.y);
            characterController.Move(currentVelocity * Time.deltaTime);

            RotateCharacter();
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump (InputValue value)
    {
        jumpInputPressed = value.Get<float>() > 0;

        if (jumpInputPressed)
        {
            if(characterController.isGrounded)
            {
                isJumping = true;

                jumpTimer = 0;

                currentVerticalVelocity = jumpSpeed;
            }
        }
        else
        {
            if (isJumping)
            {
                isJumping = false;
            }
        }
    }

    public void OnAttack(InputValue value)
    {
       attackInputPressed = value.Get<float>() > 0;
        Debug.Log(value.ToString());
        if (attackInputPressed)
            OverlapAttackCheck();

    }

    private void OverlapAttackCheck()
    {
        Collider[] overlapItems = Physics.OverlapBox(
                                        attackRangeAnchor.transform.position,
                                        attackRangeSize / 2,
                                        attackRangeAnchor.transform.rotation,
                                        Physics.AllLayers,
                                        QueryTriggerInteraction.Ignore);

        if (overlapItems.Length > 0)
        {
            foreach (Collider item in overlapItems)
            {
                Vector3 direction = item.transform.position - transform.position;
                item.SendMessage("OnPlayerAttack", direction, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackRangeAnchor != null)
        {
            Gizmos.color = new Vector4(1, 0, 0, 0.5f);
            Gizmos.DrawCube(attackRangeAnchor.transform.position, attackRangeSize);
        }
    }

    private void RotateCharacter()
    {
        Vector3 lookDirection = new Vector3(currentHorizontalVelocity.x, 0, currentHorizontalVelocity.y).normalized;

        if (lookDirection.magnitude > 0.001f)
        {
            Quaternion newRotation = Quaternion.LookRotation(lookDirection);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * moveAcceleration);
        }
    }
}
