using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUi : BaseUi
{
    public void OnRestart() 
    {
        Time.timeScale = 1f;

        UiGameManager.Instance.ChangeState(new PlayState());
    }

    public void OnMainMenu()
    {
        Time.timeScale = 1f;
        UiGameManager.Instance.ChangeState(new MainMenuState());
    }

}
