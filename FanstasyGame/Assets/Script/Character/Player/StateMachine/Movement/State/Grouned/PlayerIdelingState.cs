using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdelingState : PlayerMovementState
{
    public PlayerIdelingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Entry()
    {
        base.Entry();
        speedModifer= 0;
        ResetVelocity();
    }
}
