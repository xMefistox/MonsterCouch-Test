using UnityEngine;

namespace MonsterCouchTest.Zenject.Signals
{
    public class GoToSettingsSignal
    {
        public GameObject SignalOrigin { get; private set; }

        public GoToSettingsSignal(GameObject signalOrigin)
        {
            SignalOrigin = signalOrigin;
        }
    }
}