using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string _horizontalAxis = "Horizontal";
    private const KeyCode _jumpKey = KeyCode.W;

    public float Direction { get; private set; }
    public bool IsJumping { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(_horizontalAxis);
        IsJumping = Input.GetKeyDown(_jumpKey);
    }
}

