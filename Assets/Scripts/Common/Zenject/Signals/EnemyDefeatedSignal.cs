using UnityEngine;

namespace MonsterCouchTest.Zenject.Signals
{
    public class EnemyDefeatedSignal
    {
        public Enemy SignalOrigin { get; private set; }

        public EnemyDefeatedSignal(Enemy signalOrigin)
        {
            SignalOrigin = signalOrigin;
        }
    }
}