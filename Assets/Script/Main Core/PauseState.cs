using UnityEngine;

public class PauseState : IGameState
{
   public void Enter() 
   {
        Debug.Log(" Pause Enable ");
        Time.timeScale = 0f;
   }
   public void Update()
   {

   }
   public void Exit()
   {
        Debug.Log(" Pause Disable ");
        Time.timeScale = 1f;
   }



}
