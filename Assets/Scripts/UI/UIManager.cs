using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject preloader;
    [SerializeField] private GameObject panelLobby;
    [SerializeField] private GameObject panelFinish;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject kills;
    

    private void SetVisiblePanel(GameObject panel, bool visible)
    {
        if (panel)
            panel.SetActive(visible);
    }

    public void OpenPanelLobby() => SetVisiblePanel(panelLobby, true);
    
    public void ClosePanelLobby() => SetVisiblePanel(panelLobby, false);
    
    public void OpenPanelFinish() => SetVisiblePanel(panelFinish, true);
    
    public void OpenTimer() => SetVisiblePanel(timer, true);
    
    public void CloseTimer() => SetVisiblePanel(timer, false);
    
    public void OpenKills() => SetVisiblePanel(kills, true);
    
    public void CloseKills() => SetVisiblePanel(kills, false);
    
    public void OpenPreloader() => SetVisiblePanel(preloader, true);
    
    public void ClosePreloader() => SetVisiblePanel(preloader, false);

}
