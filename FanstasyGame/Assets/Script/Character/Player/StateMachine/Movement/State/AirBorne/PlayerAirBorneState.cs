using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirBorneState : PlayerMovementState
{
    public PlayerAirBorneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }


    public override void Entry()
    {
        base.Entry();

        StartAndStopAnimation(stateMachine.player.AnimationData.AirBroneParameterHash, true);
    }
    public override void Exit()
    {
        base.Exit();

        StartAndStopAnimation(stateMachine.player.AnimationData.AirBroneParameterHash, false);
    }

    public override void OnContactWithGround(Collider Colllider)
    {
        stateMachine.ChangeState(stateMachine.idelingState);
    }
}
