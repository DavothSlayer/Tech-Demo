using System;
using System.Collections.Generic;
using Zenject;

public class TimeStateFactory
{
    private readonly DiContainer _container;
    private readonly Dictionary<Type, Type> _transitions;

    [Inject]
    public TimeStateFactory(DiContainer container)
    {
        _container = container;

        _transitions = new Dictionary<Type, Type>
        {
            { typeof(DayTimeState), typeof(NightTimeState) },
            { typeof(NightTimeState), typeof(DayTimeState) }
        };
    }

    public ITimeState CreateInitialState() => _container.Instantiate<DayTimeState>();

    public ITimeState GetNextState(ITimeState current)
    {
        if (_transitions.TryGetValue(current.GetType(), out var nextType))
            return (ITimeState)_container.Instantiate(nextType);

        return null;
    }
}
