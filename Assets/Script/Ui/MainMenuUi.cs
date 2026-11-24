using UnityEngine;

public class MainMenuUi : BaseUi
{
    public void OnQuit() 
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
