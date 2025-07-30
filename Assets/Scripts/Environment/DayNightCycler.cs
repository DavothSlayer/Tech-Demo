using UnityEngine;

public class DayNightCycler : MonoBehaviour
{
    private ITimeState _currentTimeState;

    [SerializeField] private DayNightData _dayNightData;
    [SerializeField] private Light _sunMoonLight;

    public DayNightData DayNightData => _dayNightData;
    public Light SunMoonLight => _sunMoonLight;

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

    public void OnStateFinished(ITimeState _finishedState)
    {
        if (_finishedState is DayTimeState)
            UpdateState(new NightTimeState(this));
        else if (_finishedState is NightTimeState)
            UpdateState(new DayTimeState(this));
    }
}
