using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class PlayerAnimator : MonoBehaviour
{
    InputReader input;

    void Awake()
    {
        input = GetComponent<InputReader>();
    }

    void Update()
    {
        //if (input.MoveInput != Vector2.zero)
        //    Debug.Log("Walk");
        //else
        //    Debug.Log("Idle");

        //if (input.AttackInput)
        //    Debug.Log("Attack");
    }
}