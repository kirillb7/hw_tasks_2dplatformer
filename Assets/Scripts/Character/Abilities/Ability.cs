using UnityEngine;

[RequireComponent(typeof(TimeCounter))]
abstract public class Ability : MonoBehaviour
{
    [SerializeField] protected float ActiveDuration;
    [SerializeField] protected float CooldownDuration;
    [SerializeField] protected float Range;
    [SerializeField] protected Transform Visual;

    protected TimeCounter Counter;

    public bool IsAvailable { get; protected set; }
    public bool IsOnCooldown { get; protected set; }

    private void Awake()
    {
        Counter = GetComponent<TimeCounter>();
    }

    private void OnEnable()
    {
        Counter.Tick += Trigger;
        Counter.Finished += UpdateCooldown;
    }

    private void OnDisable()
    {
        Counter.Tick -= Trigger;
        Counter.Finished -= UpdateCooldown;
    }

    protected void Start()
    {
        IsAvailable = true;
        IsOnCooldown = false;
        Visual.gameObject.SetActive(false);

        Visual.localScale *= Range;
    }

    public void Activate()
    {
        IsAvailable = false;
        IsOnCooldown = false;
        Visual.gameObject.SetActive(true);

        Counter.StartCount(ActiveDuration, isBackwards: true);
    }

    abstract protected void Trigger();

    private void UpdateCooldown()
    {
        Visual.gameObject.SetActive(false);

        if (IsOnCooldown)
        {
            IsOnCooldown = false;
            IsAvailable = true;
        }
        else
        {
            IsOnCooldown = true;

            Counter.StartCount(CooldownDuration, isTicking: false);
        }
    }
}
