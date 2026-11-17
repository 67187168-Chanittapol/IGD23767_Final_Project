using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public void ShowPause() 
    {
        pausePanel.SetActive(true);
    }

    public void HidePause()
    {
        pausePanel.SetActive(false);
    }
}
