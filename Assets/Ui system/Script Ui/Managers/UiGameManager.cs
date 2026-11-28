using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class UiGameManager : MonoBehaviour
{
    public static UiGameManager Instance { get; private set; }

    private GameStateMachine stateMachine;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        stateMachine = new GameStateMachine();

        ChangeState(new MainMenuState());
    }

   

    private void Update()
    {
        stateMachine?.Update();

        if (Input.GetKeyDown(KeyCode.L))
        {
            OnGameOver();
        }

    }

    public void ChangeState(IGameState newState) 
    {
        stateMachine.ChangeState(newState);
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button Clicked!");

        ChangeState(new PlayState());
    }

    public void OnGameOver()
    {
        ChangeState(new GameOverState());
    }

    private void TestGameOver()
    {
        OnGameOver();
    }

}
