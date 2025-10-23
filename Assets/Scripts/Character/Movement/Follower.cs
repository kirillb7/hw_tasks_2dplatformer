using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Follower : MonoBehaviour
{
    private Mover _mover;
    private float _sufficientDistanceX = 1f;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
    }

    public IEnumerator Follow(Transform target)
    {
        while (isActiveAndEnabled)
        {
            if (Mathf.Abs(target.position.x - transform.position.x) > _sufficientDistanceX)
            {
                _mover.Move(Mathf.Sign(target.position.x - transform.position.x));
            }

            yield return null;
        }
    }
}
