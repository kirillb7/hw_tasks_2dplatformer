using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";

    private const KeyCode JumpKey = KeyCode.W;
    private const KeyCode AttackKey = KeyCode.Mouse0;
    private const KeyCode AbilityKey = KeyCode.E;

    public float Direction { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsUsingAbility { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(HorizontalAxis);
        IsJumping = Input.GetKeyDown(JumpKey);
        IsAttacking = Input.GetKeyDown(AttackKey);
        IsUsingAbility = Input.GetKeyDown(AbilityKey);
    }
}

