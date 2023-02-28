using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody Rigidbody { get; private set; }

    public PlayerInputAction inputActions { get; private set; }

    public PlayerInputAction.PlayerActionMapActions  playerActions { get; private set; }

    private void Awake()
    {
        inputActions = new PlayerInputAction();

        playerActions = inputActions.PlayerActionMap;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void Start()
    {
        
    }

    private void OnDisable()
    {
        inputActions.Disable();

    }


}
