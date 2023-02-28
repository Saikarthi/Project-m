using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementStateMachine : StateMachine
{
    public Player player { get; }

    public PlayerIdelingState idelingState { get; }
    public PlayerWalkingState walkingState { get; }
    public PlayerSprintingState sprintingState { get; }

    public PlayerMovementStateMachine(Player _player)
    {
        player = _player;
        idelingState= new PlayerIdelingState(this);

        walkingState= new PlayerWalkingState(this);

        sprintingState= new PlayerSprintingState(this);
    }

}
