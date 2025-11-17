using UnityEngine;

namespace MonsterCouchTest.Zenject.Signals
{
    public class PlayGameSignal
    {
        public GameObject SignalOrigin { get; private set; }

        public PlayGameSignal(GameObject signalOrigin)
        {
            SignalOrigin = signalOrigin;
        }
    }
}