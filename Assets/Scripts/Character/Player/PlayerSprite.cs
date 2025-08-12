using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerSprite : MonoBehaviour
{
    private Animator _animator;
    private bool _isFlipped = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Animate(float direction)
    {
        bool isRunning = direction != 0;

        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, isRunning);

        if (isRunning)
        {
            if (_isFlipped != direction < 0)
            {
                transform.Rotate(0, 180, 0);
                _isFlipped = direction < 0;
            }
        }
    }
}
