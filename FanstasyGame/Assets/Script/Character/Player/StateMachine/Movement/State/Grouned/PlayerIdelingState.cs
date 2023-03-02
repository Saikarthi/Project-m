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

        ResetVelocity();
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.Reusabledata.MovementInput == Vector2.zero)
        return; 

        OnMove();
    }


}
