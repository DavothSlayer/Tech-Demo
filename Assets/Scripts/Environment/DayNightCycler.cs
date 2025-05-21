using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycler : MonoBehaviour
{
    private ITimeState _currentTimeState;

    [SerializeField] private DayNightData _dayNightData;
    [SerializeField] private Light _sunMoonLight;

    public DayNightData DayNightData => _dayNightData;
    public Light SunMoonLight => _sunMoonLight;

    private float _currentTime;

    private void Awake() => UpdateState(new DayTimeState(this));

    private void Update()
    {
        _currentTimeState?.OnUpdate();
    }

    public void UpdateState(ITimeState _targetState)
    {
        _currentTimeState?.OnExit();
        _currentTimeState = _targetState;
        _currentTimeState?.OnEnter();
    }
}
