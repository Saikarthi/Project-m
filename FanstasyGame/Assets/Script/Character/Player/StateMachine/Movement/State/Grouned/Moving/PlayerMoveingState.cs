using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveingState : PlayerGroundState
{
    public PlayerMoveingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }
}
