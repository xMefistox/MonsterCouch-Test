using Common;
using MonsterCouchTest.Input;
using MonsterCouchTest.Zenject.Signals;
using UnityEngine;
using Zenject;

namespace MonsterCouchTest.Zenject
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputSystem_Actions>().FromInstance(new InputSystem_Actions()).AsSingle().NonLazy();
        }
    }
}

