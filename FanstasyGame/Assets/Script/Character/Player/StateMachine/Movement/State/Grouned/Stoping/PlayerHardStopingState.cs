using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHardStopingState : PlayerStopIngState
{
    public PlayerHardStopingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
    public override void Entry()
    {
        base.Entry();
        stateMachine.Reusabledata.MovementDecelrationForce = MovementData.StopingData.HardForce;
        StartAndStopAnimation(stateMachine.player.AnimationData.HardStopingParameterHash, true);

    }
    public override void Exit()
    {
        base.Exit();
        StartAndStopAnimation(stateMachine.player.AnimationData.HardStopingParameterHash, false);
    }
}
