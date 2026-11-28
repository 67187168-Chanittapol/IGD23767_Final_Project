using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;

    public void OnPause()
    {
        
        uiManager.ShowPause();
    }

    public void OnContinue()
    {
        
        uiManager.HidePause();
    }

    public void OnMainMenu()
    {
        uiManager.HidePause();
        Time.timeScale = 1f;
        ;
        UiGameManager.Instance.ChangeState(new MainMenuState());
    }
}
