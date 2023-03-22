using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerIdelingState : PlayerGroundState
{
    public PlayerIdelingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Entry()
    {
        base.Entry();

        stateMachine.Reusabledata.MovementSpeedModifier = 0;
        stateMachine.Reusabledata.CurrentJumpForce = AirBroneData.JumpData.StationaryForce;


        ResetVelocity();

        StartAndStopAnimation(stateMachine.player.AnimationData.IdelParameterHash, true);

    }

    public override void Exit()
    {
        base.Exit();
        StartAndStopAnimation(stateMachine.player.AnimationData.IdelParameterHash, false);
    }
    public override void Update()
    {
        base.Update();

        if(stateMachine.Reusabledata.MovementInput == Vector2.zero)
        return; 

        OnMove();
    }


}
