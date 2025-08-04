using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private DayNightData _data;
    [SerializeField] private Light _sunMoonLight;

    public override void InstallBindings()
    {
        Container.Bind<DayNightData>().FromInstance(_data).AsSingle();
        Container.Bind<Light>().FromInstance(_sunMoonLight).AsSingle();

        Container.Bind<TimeStateFactory>().AsSingle();
        Container.Bind<DayNightCycler>().FromComponentInHierarchy().AsSingle();
    }
}