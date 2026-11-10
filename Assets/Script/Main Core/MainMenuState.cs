using UnityEngine;

public class MainMenuState : IGameState
{ 
   public void Enter() 
   {
        Debug.Log("Enter Menu");
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
