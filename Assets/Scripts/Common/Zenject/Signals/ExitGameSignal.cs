using UnityEngine;

namespace MonsterCouchTest.Zenject.Signals
{
    public class ExitGameSignal
    {
        public GameObject SignalOrigin { get; private set; }

        public ExitGameSignal(GameObject signalOrigin)
        {
            SignalOrigin = signalOrigin;
        }
    }
}