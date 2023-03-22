using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayeraAnimationData 
{
    [Header("State Group Parameter Names")]
    [SerializeField] private string groundParameterName= "IsGrounded";
    [SerializeField] private string movingParameterName= "Moving";
    [SerializeField] private string stopingParameterName= "Stoping";
    [SerializeField] private string airBroneParameterName= "IsAirBorne";

    [Header("Grounded Parameter Names")]
    [SerializeField] private string idelParameterName= "IsIdeling";
    [SerializeField] private string walkParameterName= "IsWalking";
    [SerializeField] private string sprintParameterName= "IsSprinting";
    [SerializeField] private string hardStopingParameterName= "IsHardStoping";


    [Header("AirBrone Parameter Names")]
    [SerializeField] private string jumpParameterName= "IsJump";
    #region public property

    public int GrounedParameterHash { get; private set; }
    public int MovingParameterHash { get; private set; }
    public int StopingParameterHash { get; private set; }
    public int AirBroneParameterHash { get; private set; }


    public int IdelParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int SprintParameterHash { get; private set; }
    public int HardStopingParameterHash { get; private set; }


    public int JumpParameterHash { get; private set; } 
    #endregion


    public void Initialize()
    {
        GrounedParameterHash = Animator.StringToHash(groundParameterName);
        MovingParameterHash = Animator.StringToHash(movingParameterName);
        StopingParameterHash = Animator.StringToHash(stopingParameterName);
        AirBroneParameterHash = Animator.StringToHash(airBroneParameterName);


        IdelParameterHash = Animator.StringToHash(idelParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        SprintParameterHash = Animator.StringToHash(sprintParameterName);
        HardStopingParameterHash = Animator.StringToHash(hardStopingParameterName);

        JumpParameterHash = Animator.StringToHash(jumpParameterName);
    }

}
