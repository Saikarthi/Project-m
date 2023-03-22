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

        StartAndStopAnimation(stateMachine.player.AnimationData.SprintParameterHash, true);

    }

    public override void Exit()
    {
        base.Exit();
        StartAndStopAnimation(stateMachine.player.AnimationData.SprintParameterHash, false);
    }
    #region Istate Methods
    public override void Update()
    {
        base.Update();

        if (stateMachine.Reusabledata.ShouldSprint == true)
            return;

        OnWalk(); //Mine
    }
    #endregion
    private void OnWalk() //mine
    {
        stateMachine.ChangeState(stateMachine.walkingState);
    }
    #region Input
    protected override void OnMovenmentCanceled(InputAction.CallbackContext obj)
    {
        stateMachine.ChangeState(stateMachine.hardStopingState);
    }

    #endregion
}
