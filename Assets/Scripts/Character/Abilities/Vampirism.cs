using UnityEngine;

public class Vampirism : Ability
{
    [SerializeField] private float _damage = 1;
    [SerializeField] private HealthCounter _userHealth;

    protected override void Trigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, Range);
        HealthCounter targetHealth = null;
        float lowestDistance = Range;

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != _userHealth.gameObject && hit.TryGetComponent(out HealthCounter healthCounter))
            {
                float distance = Vector2.Distance(hit.ClosestPoint(transform.position), transform.position);

                if (distance <= lowestDistance)
                {
                    lowestDistance = distance;
                    targetHealth = healthCounter;
                }
            }
        }

        if (targetHealth != null)
        {
            targetHealth.Change(-_damage);
            _userHealth.Change(_damage);
        }
    }
}
