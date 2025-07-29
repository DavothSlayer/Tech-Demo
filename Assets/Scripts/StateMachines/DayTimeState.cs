using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class DayTimeState : ITimeState
{
    private DayNightCycler _dayNightCycler;

    public DayTimeState(DayNightCycler _cycler)
    {
        this._dayNightCycler = _cycler;
    }

    private float _xRotationRate;
    private float _targetXRotation;

    public void OnEnter()
    {
        _dayNightCycler.SunMoonLight.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        WaitUntilEnd().Forget();
    }

    public void OnUpdate()
    {
        _xRotationRate = 180f * (Time.deltaTime / _dayNightCycler.DayNightData.DayDuration);

        _targetXRotation += _xRotationRate;

        _dayNightCycler.SunMoonLight.transform.rotation = Quaternion.Euler(_targetXRotation, 0f, 0f);
    }

    public void OnExit()
    {
        _dayNightCycler.SunMoonLight.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }

    private async UniTaskVoid WaitUntilEnd()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_dayNightCycler.DayNightData.DayDuration));
        _dayNightCycler.OnStateFinished(this);
    }
}
