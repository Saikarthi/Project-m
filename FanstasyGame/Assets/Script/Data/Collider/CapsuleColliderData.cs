using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleColliderData : MonoBehaviour
{
    public CapsuleCollider Collider { get; private set; }

    public Vector3 ColliderCentreInLocalSpace { get; private set; }

    public void Initialize(GameObject gameObject)
    {
        if (Collider != null)
            return;
        Collider = gameObject.GetComponent<CapsuleCollider>();

        UpdataColliderData();
    }
    public void UpdataColliderData()
    {
        ColliderCentreInLocalSpace = Collider.center;
    }
}
