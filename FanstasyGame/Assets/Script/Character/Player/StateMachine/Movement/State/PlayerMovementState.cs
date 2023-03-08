using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine stateMachine;
    protected PlayerGrounedData MovementData;

    public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;
        MovementData = stateMachine.player.Data.GrounedData;
        InitializeData();
        
    }

    private void InitializeData()
    {
        stateMachine.Reusabledata.TimeToReachTargetRotation = MovementData.BaseRotationData.TargetRotationReachTime;
        
    }

    #region Istate
    public virtual void Entry()
    {
        Debug.Log("State:" + GetType().Name);
        AddInputActionCallback();
    }



    public virtual void Exit()
    {
        RemoveInputActionCallBack();
    }

    public virtual void HandleInput()
    {
        ReadMovementInput();
    }


    public virtual void PhysicsUpdate()
    {
        Move();
    }


    public virtual void Update()
    {

    }
    #endregion

    #region Main Function


    private void Move()
    {
        if (stateMachine.Reusabledata.MovementInput == Vector2.zero || stateMachine.Reusabledata.MovementSpeedModifier == 0)
            return;
        Vector3 movementDirection = GetMovementDirection();
        float targetRoatationYAngle = Rotate(movementDirection);
        Vector3 targetRoatationDirection = GetTargetRoationDirection(targetRoatationYAngle);
        float movementSpeed = GetMovementSpeed();
        Vector3 currentVelocity = GetCurrentVelocity();
        stateMachine.player.rb.AddForce(targetRoatationDirection * movementSpeed - currentVelocity,ForceMode.VelocityChange);
    }



    private float Rotate(Vector3 direction)
    {
        float angle = UpdateTargetRoation(direction);

        RotateTowardsTragerPostion();
        return angle;
    }

    private float UpdateTargetRoation(Vector3 direction, bool shouldConsiderCameraRoation = true)
    {
        float angle = GetDirectionAngle(direction);
        
        if(shouldConsiderCameraRoation)
            angle = AddCameraRoataion2Angle(angle);

        if (angle != stateMachine.Reusabledata.CurrentTargetRotation.y)
        {
            UpdateTragetRoationData(angle);
        }
        return angle;
    }

    private void UpdateTragetRoationData(float targetangle)
    {
        stateMachine.Reusabledata.CurrentTargetRotation.y = targetangle;
        stateMachine.Reusabledata.DampedTargetRotationPassedTime.y = 0f;
    }

    private float AddCameraRoataion2Angle(float angle)
    {
        angle += stateMachine.player.mainCameraTransform.eulerAngles.y;
        if (angle > 360)
        {
            angle -= 360;
        }

        return angle;
    }

    private static float GetDirectionAngle(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        if (angle < 0)
        {
            angle += 360;
        }

        return angle;
    }

    private void ReadMovementInput()
    {
        stateMachine.Reusabledata.MovementInput = stateMachine.player.input.playerActions.Movement.ReadValue<Vector2>();
    }

    #endregion


    #region Reusable Function

    protected Vector3 GetMovementDirection()
    {
        return new Vector3(stateMachine.Reusabledata.MovementInput.x, 0, stateMachine.Reusabledata.MovementInput.y);
    }
    protected Vector3 GetPlayerVerticalVelocity()
    {
        return new Vector3(0,stateMachine.player.rb.velocity.y ,0 );
    }
    protected float GetMovementSpeed()
    {
        return MovementData.BaseSpeed * stateMachine.Reusabledata.MovementSpeedModifier;
    }
    protected Vector3 GetCurrentVelocity()
    {
        Vector3 temp = stateMachine.player.rb.velocity;
        temp.y = 0;
        return temp;
    }
    protected void RotateTowardsTragerPostion()
    {
        float currentYAngle = stateMachine.player.rb.rotation.eulerAngles.y;
        if (currentYAngle == stateMachine.Reusabledata.CurrentTargetRotation.y)
            return;
        float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, stateMachine.Reusabledata.CurrentTargetRotation.y, ref stateMachine.Reusabledata.DampedtargetRotationCurrentVelocity.y, stateMachine.Reusabledata.TimeToReachTargetRotation.y - stateMachine.Reusabledata.DampedTargetRotationPassedTime.y);

        stateMachine.Reusabledata.DampedTargetRotationPassedTime.y += Time.deltaTime;

        Quaternion traget = Quaternion.Euler(0f,smoothedYAngle, 0f);

        stateMachine.player.rb.MoveRotation(traget);
    }

    protected Vector3 GetTargetRoationDirection(float targetAngle)
    {
        return Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }

    protected void ResetVelocity()
    {
        stateMachine.player.rb.velocity= Vector3.zero;
    }

    protected virtual void AddInputActionCallback()
    {
        stateMachine.player.input.playerActions.Sprint.started += OnSprintToggleStarted;
        stateMachine.player.input.playerActions.Sprint.canceled += OnSprintToggleEnded; //Mine
    }

    protected virtual void RemoveInputActionCallBack()
    {
        stateMachine.player.input.playerActions.Sprint.started -= OnSprintToggleStarted;
        stateMachine.player.input.playerActions.Sprint.canceled -= OnSprintToggleEnded; //Mine
    }
    #endregion
    #region InputMethod

    private void OnSprintToggleStarted(InputAction.CallbackContext obj)
    {
        stateMachine.Reusabledata.ShouldSprint = true;
    } 
    private void OnSprintToggleEnded(InputAction.CallbackContext obj) //Mine
    {
        stateMachine.Reusabledata.ShouldSprint = false;
    } 
    #endregion
}
