using Common;
using MonsterCouchTest.Input;
using MonsterCouchTest.Zenject.Signals;
using UnityEngine;
using Zenject;

namespace MonsterCouchTest.Zenject
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField]
        private AudioManager audioManager;

        public override void InstallBindings()
        {
            InstallSignals();

            Container.BindInterfacesAndSelfTo<AudioManager>().FromInstance(audioManager).AsSingle().NonLazy();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<GoToSettingsSignal>();
            Container.DeclareSignal<PlayGameSignal>();
            Container.DeclareSignal<ExitGameSignal>();
            Container.DeclareSignal<GoToMainMenuSignal>();
            Container.DeclareSignal<EnemyDefeatedSignal>();
        }
    }
}

