using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : IGameState
{
   public void Enter() 
   {
        Debug.Log(" Pause Enable ");
        Time.timeScale = 0f;

        if (!SceneManager.GetSceneByName("Pause scene").isLoaded)
        {
            SceneManager.LoadScene("Pause scene", LoadSceneMode.Additive);
        }
    }
   public void Update()
   {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UiGameManager.Instance.ChangeState(new PlayState());
        }
    }
   public void Exit()
   {
        Debug.Log(" Pause Disable ");
        Time.timeScale = 1f;

        if (SceneManager.GetSceneByName("Pause scene").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Pause scene");
        }
    }



}
