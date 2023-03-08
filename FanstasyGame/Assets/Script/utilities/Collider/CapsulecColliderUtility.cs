using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CapsulecColliderUtility
{

    public CapsuleColliderData CapsuleColliderData { get; private set; }
    [field: SerializeField] public DefaultColliderData DefaultColliderData { get; private set; }
    [field: SerializeField]  public SlopeData SlopeData { get; private set; }


    public void Initialize(GameObject gameObject)
    {
        if(CapsuleColliderData !=null)
        {
            return;
        }
        CapsuleColliderData = new CapsuleColliderData();
        CapsuleColliderData.Initialize(gameObject);
    }
    public void CalculateCapsuleColliderDimensions()
    {
        SetCapsuleCollideRadius(DefaultColliderData.radius);

        SetCapsuleCollideHeight(DefaultColliderData.height * (1f - SlopeData.stepHeightPercentage));

        ReCalculateCapsuleCollideCentre();
        float halfColliderHeight = CapsuleColliderData.Collider.height / 2f;
        if(halfColliderHeight < CapsuleColliderData.Collider.radius) 
        {
            SetCapsuleCollideRadius(halfColliderHeight);
        }

        CapsuleColliderData.UpdataColliderData();
    }

    public void SetCapsuleCollideRadius(float radius)
    {
        CapsuleColliderData.Collider.radius = radius;
    }
    public void SetCapsuleCollideHeight(float Height)
    {
        CapsuleColliderData.Collider.height = Height;
        
    }
    public void ReCalculateCapsuleCollideCentre()
    {
        float colliderHeightDifference = DefaultColliderData.height - CapsuleColliderData.Collider.height;
        Vector3 newColliderCentre = new Vector3(0f, DefaultColliderData.centreY + (colliderHeightDifference / 2f),0f); 

        CapsuleColliderData.Collider.center = newColliderCentre;


    }
}
