using UnityEngine;
using Zenject;
using MonsterCouchTest.Zenject.Signals;
using UnityEngine.UI;

namespace MonsterCouchTest.UI
{
    public class PlayGameButton : MonoBehaviour
    {
        [SerializeField]
        protected Button button;

        [Inject]
        protected SignalBus signalBus;

        private void Start()
        {
            button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            signalBus.Fire(new PlayGameSignal(this.gameObject));
        }        
    }
}
