using UnityEngine;

public class MainMenuUi : BaseUi
{
    public void OnPlay()
    {
        UiGameManager.Instance.OnButtonClicked();
    }
    public void OnQuit() 
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
