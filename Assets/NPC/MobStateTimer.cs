using System;
using System.Collections;
using UnityEngine;

public class MobStateTimer : MonoBehaviour, ITimer
{
    [SerializeField] private float _requiredTime;
    [SerializeField] private float _currentTime;

    private Coroutine _calculating;

    public float RequiredTime { get => _requiredTime; set => _requiredTime = value; }
    public float CurrentTime { get => _currentTime; set => _currentTime = value; }

    public bool IsReached()
    {
        return CurrentTime >= RequiredTime;
    }

    public void StartCalculate()
    {
        if (RequiredTime <= 0)
            throw new ArgumentOutOfRangeException("RequiredTime", "RequiredTime must be greater than 0");

        _calculating = StartCoroutine(Calculating());
    }

    public void StopCalculate()
    {
        if (_calculating == null)
            throw new InvalidOperationException("Coroutine wasn't started");

        StopCoroutine(_calculating);
        CurrentTime = 0;
        RequiredTime = 0;
    }

    private IEnumerator Calculating()
    {
        yield return new WaitWhile(() =>
        {
            CurrentTime += Time.deltaTime;
            return IsReached() == false;
        });

        Debug.Log("Выход");
    }
}
