using UnityEngine;

public class Vampirism : Ability
{
    [SerializeField] private float _damage = 1;
    [SerializeField] private HealthCounter _userHealth;

    protected override void Trigger()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, Range);
        HealthCounter targetHealth = null;
        float lowestDistance = Range * Range;

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != _userHealth.gameObject && hit.TryGetComponent(out HealthCounter healthCounter))
            {
                float distance = (hit.ClosestPoint(transform.position) - (Vector2)transform.position).sqrMagnitude;

                if (distance <= lowestDistance)
                {
                    lowestDistance = distance;
                    targetHealth = healthCounter;
                }
            }
        }

        if (targetHealth != null)
        {
            float remainingHealth = targetHealth.GetValue;

            if (remainingHealth > _damage)
            {
                _userHealth.Heal(_damage);
            }
            else
            {
                _userHealth.Heal(remainingHealth);
            }

            targetHealth.Damage(_damage);
        }
    }
}
