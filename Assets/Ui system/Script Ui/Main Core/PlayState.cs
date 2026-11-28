using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IGameState
{
    public void Enter() 
    {
        Debug.Log("Enter Play State");

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene != "F1" &&
            currentScene != "F2" &&
            currentScene != "F3")
        {
            SceneManager.LoadScene("F1");
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UiGameManager.Instance.ChangeState(new PauseState());
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Play State");
    }

}
