using UnityEngine;
using Zenject;

public class DayNightCycler : MonoBehaviour
{
    private ITimeState _currentTimeState;
    public TimeStateFactory _timeStateFactory { get; private set; }

    public DayNightData _dayNightData { get; private set; }
    public Transform _directionalLightRotater { get; private set; }

    public Light _sun { get; private set; }
    public Light _moon { get; private set; }

    [Inject]
    public void Construct(DayNightData data, Transform directionalLightRotater, TimeStateFactory timeStateFactory, Light sun, Light moon)
    {
        _dayNightData = data;
        _directionalLightRotater = directionalLightRotater;
        _timeStateFactory = timeStateFactory;
        _sun = sun;
        _moon = moon;
    }

    private void Start() 
    { 
        UpdateState(_timeStateFactory.CreateInitialState());
    }

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
