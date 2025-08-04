using UnityEngine;
using Zenject;

public class DayNightCycler : MonoBehaviour
{
    private ITimeState _currentTimeState;
    private TimeStateFactory _timeStateFactory;

    [SerializeField] private DayNightData _dayNightData;
    [SerializeField] private Light _sunMoonLight;

    public DayNightData DayNightData => _dayNightData;
    public Light SunMoonLight => _sunMoonLight;

    [Inject]
    private void Construct(DayNightData data, Light sunMoonLight, TimeStateFactory timeStateFactory)
    {
        _dayNightData = data;
        _sunMoonLight = sunMoonLight;
        _timeStateFactory = timeStateFactory;
    }

    private void Start() => UpdateState(_timeStateFactory.CreateInitialState());

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
        var nextState = _timeStateFactory.GetNextState(_currentTimeState);
        UpdateState(nextState);
    }
}
