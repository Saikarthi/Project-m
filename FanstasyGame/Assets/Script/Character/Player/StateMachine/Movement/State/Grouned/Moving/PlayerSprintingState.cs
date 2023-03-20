using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintingState : PlayerMoveingState
{
    public PlayerSprintingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Entry()
    {
        base.Entry();

        stateMachine.Reusabledata.MovementSpeedModifier = MovementData.BaseSprintingData.SpeedModifer;
        stateMachine.Reusabledata.CurrentJumpForce = AirBroneData.JumpData.StrongForce;

    }

    #region Istate Methods
    public override void Update()
    {
        base.Update();

        if (stateMachine.Reusabledata.ShouldSprint == true)
            return;

        OnSprint(); //Mine
    }
    #endregion
    private void OnSprint() //mine
    {
        stateMachine.ChangeState(stateMachine.walkingState);
    }
}
