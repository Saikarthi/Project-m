using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkingState : PlayerMoveingState
{
    public PlayerWalkingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {

    }
    #region Istate Methods

    public override void Entry()
    {
        base.Entry();

        stateMachine.Reusabledata.MovementSpeedModifier = MovementData.BaseWalkData.SpeedModifer;
        stateMachine.Reusabledata.CurrentJumpForce = AirBroneData.JumpData.MediumForce;
    }

    public override void Update()
    {
        base.Update();

        if (stateMachine.Reusabledata.ShouldSprint == false)
            return;

        OnSprint(); //Mine
    }

    private void OnSprint() //mine
    {
        stateMachine.ChangeState(stateMachine.sprintingState);
    }
    #endregion



}
