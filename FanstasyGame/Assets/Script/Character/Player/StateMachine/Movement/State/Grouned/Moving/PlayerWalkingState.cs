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

        StartAndStopAnimation(stateMachine.player.AnimationData.WalkParameterHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        StartAndStopAnimation(stateMachine.player.AnimationData.WalkParameterHash, false);
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

    #region Input
    protected override void OnMovenmentCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(stateMachine.mediumStopingState);
    }

    #endregion

}
