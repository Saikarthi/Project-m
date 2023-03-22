using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediumStopingState : PlayerStopIngState
{
    public PlayerMediumStopingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    public override void Entry()
    {
        base.Entry();
        stateMachine.Reusabledata.MovementDecelrationForce = MovementData.StopingData.MediumForce;
        // no animition Bool For it Because of the state machine 

    }
}
