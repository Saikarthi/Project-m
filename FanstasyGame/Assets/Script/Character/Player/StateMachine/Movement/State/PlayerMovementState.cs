using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementState : IState
{
    protected PlayerMovementStateMachine stateMachine;

    protected Vector2 movementInput;

    protected float baseSpeed = 2f;
    protected float speedModifer =2;

    protected Vector3 currentTargetRotation;
    protected Vector3 timeToReachTargetRotation;
    protected Vector3 dampedTargetRotationCurrnetVelocity;
    protected Vector3 dampedTargetRotationpassedTime;
    public PlayerMovementState(PlayerMovementStateMachine playerMovementStateMachine)
    {
        stateMachine = playerMovementStateMachine;
        InitializeData();
    }

    private void InitializeData()
    {
        timeToReachTargetRotation.y = 0.14f;
    }

    #region Istate
    public virtual void Entry()
    {
        Debug.Log("State:" + GetType().Name);
    }

    public virtual void Exit()
    {

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
        if (movementInput == Vector2.zero || speedModifer == 0)
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

        if (angle != currentTargetRotation.y)
        {
            UpdateTragetRoationData(angle);
        }
        return angle;
    }

    private void UpdateTragetRoationData(float targetangle)
    {
        currentTargetRotation.y = targetangle;
        dampedTargetRotationpassedTime.y = 0f;
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
        movementInput = stateMachine.player.input.playerActions.Movement.ReadValue<Vector2>();
    }

    #endregion


    #region Reusable Function

    protected Vector3 GetMovementDirection()
    {
        return new Vector3(movementInput.x, 0, movementInput.y);
    }
    protected float GetMovementSpeed()
    {
        return baseSpeed * speedModifer;
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
        if (currentYAngle == currentTargetRotation.y)
            return;
        float smoothedYAngle = Mathf.SmoothDampAngle(currentYAngle, currentTargetRotation.y, ref dampedTargetRotationCurrnetVelocity.y, timeToReachTargetRotation.y - dampedTargetRotationpassedTime.y);

        dampedTargetRotationpassedTime.y += Time.deltaTime;

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
    #endregion
}
