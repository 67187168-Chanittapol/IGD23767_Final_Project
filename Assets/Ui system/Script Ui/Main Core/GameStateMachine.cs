using Unity.VisualScripting;
using UnityEngine;

public class GameStateMachine 
{
    private IGameState priState;

    public IGameState pubState => priState;

    public void ChangeState(IGameState newState) 
    {
        if (priState == newState)
            return;

        priState?.Exit();
        priState = newState;
        priState?.Enter();
    }

    public void Update() 
    {
        priState?.Update();
    }
}
