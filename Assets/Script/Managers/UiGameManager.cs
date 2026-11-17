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
}
