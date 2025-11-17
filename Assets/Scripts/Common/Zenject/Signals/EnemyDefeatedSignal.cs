using UnityEngine;

namespace MonsterCouchTest.Zenject.Signals
{
    public class EnemyDefeatedSignal
    {
        public GameObject SignalOrigin { get; private set; }

        public EnemyDefeatedSignal(GameObject signalOrigin)
        {
            SignalOrigin = signalOrigin;
        }
    }
}