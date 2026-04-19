using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]

    [SerializeField] private float moveSpeed = 5f;

    [Header("Depenencies")]

    [SerializeField] private Rigidbody rb;


    public bool IsSneaking { get; private set; }
    public bool IsMoving => input.sqrMagnitude > 0.01f;

    private Vector3 input;

    private void FixedUpdate()
    {

        if (!IsMoving) return;

        float currentSpeed = IsSneaking ? (moveSpeed / 2f) : moveSpeed;
        rb.MovePosition(rb.position + input * currentSpeed * Time.fixedDeltaTime);
    }



    public void OnMoveInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector3>();
    }
    public void OnSneakInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsSneaking = true;

        }
        else if (context.canceled)
        {
            IsSneaking = false;
        }
    }

}
