using UnityEngine;

namespace MonsterCouchTest.Zenject.Signals
{
    public class GoToMainMenuSignal
    {
        public GameObject SignalOrigin { get; private set; }

        public GoToMainMenuSignal(GameObject signalOrigin)
        {
            SignalOrigin = signalOrigin;
        }
    }
}