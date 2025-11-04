using System;
using System.Collections;
using UnityEngine;

public class TimeCounter : Counter
{
    [SerializeField] private bool _isFullOnStart;

    public event Action Tick;
    public event Action Finished;

    private new void Start()
    {
        if (_isFullOnStart)
        {
            Value = MaxValue;
        }
        else
        {
            Value = 0;
        }

        base.Start();
    }

    protected override void ChangeByItem(Item item)
    {

    }

    public void StartCount(float duration, bool isTicking = true, bool isBackwards = false)
    {
        if (isBackwards)
        {
            StartCoroutine(CountDown(duration, isTicking));
        }
        else
        {
            StartCoroutine(CountUp(duration, isTicking));
        }
    }

    private IEnumerator CountUp(float duration, bool isTicking)
    {
        MaxValue = duration;
        Value = 0;

        while (Value < MaxValue)
        {
            yield return null;

            Change(Time.deltaTime);
            
            if (isTicking)
            {
                Tick?.Invoke();
            }
        }

        Finished?.Invoke();
    }

    private IEnumerator CountDown(float duration, bool isTicking)
    {
        MaxValue = duration;
        Value = MaxValue;

        while (Value > 0)
        {
            yield return null;

            Change(-Time.deltaTime);

            if (isTicking)
            {
                Tick?.Invoke();
            }
        }

        Finished?.Invoke();
    }
}
