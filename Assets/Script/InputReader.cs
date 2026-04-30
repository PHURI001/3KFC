using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputAction moveAction;
    public Vector2 MoveInput { get; private set; }

    private InputAction AttackAction;
    public bool AttackInput { get; private set; }

    private void OnEnable()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        AttackAction = InputSystem.actions.FindAction("Attack");
    }

    private void Update()
    {
        MoveInput = moveAction.ReadValue<Vector2>();
        //Debug.Log($"Move Input: {MoveInput}");

        AttackInput = AttackAction.triggered;
        //Debug.Log($"Attack Input: {AttackInput}");
    }
}