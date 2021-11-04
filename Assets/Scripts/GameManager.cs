using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameState))]
[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(UIManager))]
public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    private TimeScaleHelpers _timeScaleHelpers;
    private void Awake()
    {
        _timeScaleHelpers = new TimeScaleHelpers();
        uiManager = GetComponent<UIManager>();
        GameState.Get += GetState;
    }

    private void GetState(EnumGameState state)
    {
        switch (state)
        {
            case EnumGameState.Preloader:
                uiManager.OpenPreloader();
                StartCoroutine(StartLobby());
                _timeScaleHelpers.SetTimeScale(0);
                break;
            case EnumGameState.Lobby:
                uiManager.CloseKills();
                uiManager.CloseTimer();
                uiManager.ClosePreloader();
                uiManager.OpenPanelLobby();
                _timeScaleHelpers.SetTimeScale(0);
                break;
            case EnumGameState.Game:
                uiManager.OpenKills();
                uiManager.OpenTimer();
                uiManager.ClosePanelLobby();
                _timeScaleHelpers.SetTimeScale(1);
                break;
            case EnumGameState.Finish:
                uiManager.CloseKills();
                uiManager.CloseTimer();
                uiManager.OpenPanelFinish();
                _timeScaleHelpers.SetTimeScale(0);
                break;
        }
    }

    private IEnumerator StartLobby()
    {
        yield return new WaitForSecondsRealtime(1f);
        GameState.Instance.Lobby();
    }
}
