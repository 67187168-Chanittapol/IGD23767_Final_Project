using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverState : IGameState
{
    public void Enter() 
    {
        Debug.Log("Enter Game Over State");

        Time.timeScale = 1f;

        SceneManager.LoadScene("GameOver scene");
    }
    public void Update()
    {

    }
    public void Exit()
    {
        Debug.Log("Exit Game Over State");
    }

}
