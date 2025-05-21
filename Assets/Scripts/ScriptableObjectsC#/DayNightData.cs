using UnityEngine;

[CreateAssetMenu(fileName = "New Day/Night Data", menuName = "Day Night Data")]
public class DayNightData : ScriptableObject
{
    [Header("Day & Night Durations in Seconds")]
    [SerializeField] private float _dayDuration;
    [SerializeField] private float _nightDuration;

    [Header("Sun & Moon Settings")]
    [SerializeField] private Color _sunColor;
    [SerializeField] private float _sunLightIntensity;
    [Space]
    [SerializeField] private Color _moonColor;    
    [SerializeField] private float _moonLightIntensity;

    public float DayDuration => _dayDuration;
    public float NightDuration => _nightDuration;

    public Color SunColor => _sunColor;
    public float SunLightIntensity => _sunLightIntensity;
    public Color MoonColor => _moonColor;
    public float MoonLightIntensity => _moonLightIntensity;
}
