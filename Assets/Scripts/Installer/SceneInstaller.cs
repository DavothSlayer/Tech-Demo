using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private DayNightData _data;
    [SerializeField] private Transform _directionalLightRotater;

    public override void InstallBindings()
    {
        Container.Bind<DayNightData>().FromInstance(_data).AsSingle();
        Container.Bind<Transform>().FromInstance(_directionalLightRotater).AsSingle();

        Container.Bind<TimeStateFactory>().AsSingle();
        Container.Bind<DayNightCycler>().FromComponentInHierarchy().AsSingle();
    }
}