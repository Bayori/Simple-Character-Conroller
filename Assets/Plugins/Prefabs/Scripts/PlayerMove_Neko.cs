using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove_Neko : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    public float moveSpeed = 5.0f;
    public float sprintSpeedModifier = 1.5f;

    [SerializeField] float gravity = -20f;

    public float jumpHeight = 15;

    Vector2 _moveInputValue;
    float _isSprintPressed;
    float _isJumpPressed;
    public bool isSprinting = false;

    Vector3 moveDirection;
    

    private void LateUpdate()
    {
        Move();
    }

    public void ReadKeyboardMoveInput(InputAction.CallbackContext context)
    {
        _moveInputValue = context.ReadValue<Vector2>();
    }
    public void ReadKeyboardSprintInput(InputAction.CallbackContext context)
    {
        _isSprintPressed = context.ReadValue<float>();
    }
    public void ReadKeyboardJumpInput(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValue<float>();
    }

    private void Sprint()
    {
        if (_isSprintPressed > 0f)
        {
            moveDirection *= sprintSpeedModifier;
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private void Move()
    {
       
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(_moveInputValue.x, 0f, _moveInputValue.y);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;

            Sprint();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpHeight;
            }
        }

        moveDirection.y += gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }

}
