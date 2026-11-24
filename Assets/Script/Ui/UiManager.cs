using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Pause UI")]
    [SerializeField] private GameObject pausePanel;


    public void ShowUI(BaseUi targetUI)
    {
        if (targetUI == null)
        {
            Debug.LogWarning("Target UI is missing!");
            return;
        }
        
        targetUI.Show();
    }


    public void HideUI(BaseUi targetUI)
    {
        if (targetUI == null)
        {
            Debug.LogWarning("Target UI is missing!");
            return;
        }

        targetUI.Hide();
    }

    public void ShowPause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HidePause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
