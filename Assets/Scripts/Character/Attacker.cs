using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _range = 1f;
    [SerializeField] private float _damage = 5;

    public float Range => _range;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _range);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject && hit.TryGetComponent(out HealthCounter healthCounter))
            {
                healthCounter.Damage(_damage);
            }
        }
    }
}
