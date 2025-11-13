using Packages.Rider.Editor;
using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerController _player;

    public PlayerIdleState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("IdleState Enter()");
    }

    public void Execute()
    {
        Vector2 input = _player.GetMoveInput();

        if (input.magnitude > 0.1f)
        {
            _player.StateMachine.ChangeState(_player.MoveState);
        }
    }

    public void Exit()
    {
        Debug.Log("IdleStateExit()");
    }

}
