using UnityEngine;
using Zenject;
using MonsterCouchTest.Zenject.Signals;
using System;
using UnityEngine.SceneManagement;

namespace MonsterCouchTest.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private GameObject mainMenuUI;
        [SerializeField]
        private GameObject settingsUI;

        protected SignalBus signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void OnEnable()
        {
            signalBus.Subscribe<PlayGameSignal>(OnPlayGameClicked);
            signalBus.Subscribe<GoToSettingsSignal>(OnGoToSettingsClicked);
            signalBus.Subscribe<GoToMainMenuSignal>(GoToMainMenuClicked);
            signalBus.Subscribe<ExitGameSignal>(OnExitGameClicked);
        }

        public void OnDisable()
        {
            signalBus.Unsubscribe<PlayGameSignal>(OnPlayGameClicked);
            signalBus.Unsubscribe<GoToSettingsSignal>(OnGoToSettingsClicked);
            signalBus.Unsubscribe<GoToMainMenuSignal>(GoToMainMenuClicked);
            signalBus.Unsubscribe<ExitGameSignal>(OnExitGameClicked);
        }

        private void Start()
        {
            GoToMainMenuClicked();
        }

        private void GoToMainMenuClicked()
        {
            mainMenuUI.SetActive(true);
            settingsUI.SetActive(false);
        }

        private void OnGoToSettingsClicked()
        {
            mainMenuUI.SetActive(false);
            settingsUI.SetActive(true);
        }

        private void OnPlayGameClicked()
        {
            SceneManager.LoadScene("GameScene");
        }

        private void OnExitGameClicked()
        {
            Application.Quit();
        }
    }
}
