using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;

    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputManager>().FromComponentInNewPrefab(inputManager).AsSingle();
    }
}