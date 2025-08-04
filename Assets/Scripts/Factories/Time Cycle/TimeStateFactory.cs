using System;
using System.Collections.Generic;
using Zenject;

public class TimeStateFactory
{
    private readonly DayNightCycler _cycler;
    private readonly Dictionary<Type, Func<ITimeState>> _transitions;

    [Inject]
    public TimeStateFactory(DayNightCycler cycler)
    {
        _cycler = cycler;
        _transitions = new Dictionary<Type, Func<ITimeState>>
        {
            { typeof(DayTimeState), () => new NightTimeState(_cycler) },
            { typeof(NightTimeState), () => new DayTimeState(_cycler) }
        };
    }

    public ITimeState CreateInitialState() => new DayTimeState(_cycler);

    public ITimeState GetNextState(ITimeState current)
    {
        var type = current.GetType();
        return _transitions.TryGetValue(type, out var factory) ? factory() : null;
    }
}