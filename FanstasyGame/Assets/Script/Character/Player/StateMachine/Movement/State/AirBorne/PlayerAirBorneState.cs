using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirBorneState : PlayerMovementState
{
    public PlayerAirBorneState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void OnContactWithGround(Collider Colllider)
    {
        stateMachine.ChangeState(stateMachine.idelingState);
    }
}
