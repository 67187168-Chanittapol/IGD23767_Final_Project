using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IGameState
{
    public void Enter() 
    {
        Debug.Log("Enter Play State");

        SceneManager.LoadScene("Gameplay Scene");
    }

    public void Update()
    {

    }

    public void Exit()
    {
        Debug.Log("Exit Play State");
    }

}
