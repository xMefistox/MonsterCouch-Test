using MonsterCouchTest.Zenject.Signals;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject]
    private SignalBus signalBus;
    private void OnEnable()
    {
        signalBus.Subscribe<GoToMainMenuSignal>(OnGoToMainMenu);
    }

    private void OnGoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
