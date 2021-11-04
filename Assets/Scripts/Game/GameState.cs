using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState: MonoBehaviour
{
    public static GameState Instance; 
    public static event Action<EnumGameState> Get;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Set(EnumGameState.Preloader);
    }

    public void Lobby()
    {
        Set(EnumGameState.Lobby);
    }

    public void Game()
    {
        Set(EnumGameState.Game);
    }

    public void Finish()
    {
        Set(EnumGameState.Finish);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Set(EnumGameState state)
    {
        Get?.Invoke(state);
    }
    
    private void OnDestroy()
    {
        Get = null;
    }
}
