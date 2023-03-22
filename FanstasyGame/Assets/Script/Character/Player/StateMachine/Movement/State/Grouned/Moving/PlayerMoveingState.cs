using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveingState : PlayerGroundState
{
    public PlayerMoveingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    public override void Entry()
    {
        base.Entry();

        StartAndStopAnimation(stateMachine.player.AnimationData.MovingParameterHash, true);
    }
    public override void Exit()
    {
        base.Exit();

        StartAndStopAnimation(stateMachine.player.AnimationData.MovingParameterHash, false);
    }
}
