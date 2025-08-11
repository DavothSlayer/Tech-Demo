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
        _dayNightCycler._directionalLightRotater.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        //_dayNightCycler._directionalLightRotater.color = _dayNightCycler._dayNightData.SunColor;
        //_dayNightCycler._directionalLightRotater.intensity = _dayNightCycler._dayNightData.SunLightIntensity;

        WaitUntilEnd().Forget();
    }

    public void OnUpdate()
    {
        _xRotationRate = 180f * (Time.deltaTime / _dayNightCycler._dayNightData.DayDuration);

        _targetXRotation += _xRotationRate;

        _dayNightCycler._directionalLightRotater.transform.rotation = Quaternion.Euler(_targetXRotation, 0f, 0f);
    }

    public void OnExit()
    {
        //_dayNightCycler._directionalLightRotater.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }

    private async UniTaskVoid WaitUntilEnd()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_dayNightCycler._dayNightData.DayDuration));
        _dayNightCycler.OnStateFinished(this);
    }
}
