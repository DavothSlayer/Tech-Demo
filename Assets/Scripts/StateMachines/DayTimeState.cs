using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeState : ITimeState
{
    private DayNightCycler _dayNightCycler;

    public DayTimeState(DayNightCycler _cycler)
    {
        this._dayNightCycler = _cycler;
    }

    public void OnEnter()
    {
        
    }

    public void OnUpdate()
    {

    }

    public void OnExit()
    {
        _dayNightCycler.SunMoonLight.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
    }
}
