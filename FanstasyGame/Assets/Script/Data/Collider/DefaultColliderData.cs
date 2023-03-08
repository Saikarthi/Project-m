using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DefaultColliderData
{
    [field: SerializeField] public float height { get; private set; } = 1.5f;
    [field: SerializeField] public float centreY { get; private set; } = 0.75f;
    [field: SerializeField] public float radius { get; private set; } = 0.32f;

}
