using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuState : IGameState
{ 
   public void Enter() 
   {
        Debug.Log("Enter Menu");
        if (SceneManager.GetActiveScene().name != "Ui menu scene")
        {
            SceneManager.LoadScene("Ui menu scene");
        }
    }
   public void Update()
   {
        Debug.Log("Update Menu");
   }
   public void Exit()
   {
        Debug.Log("Exit Menu");
   }
}
