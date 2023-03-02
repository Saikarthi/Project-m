using UnityEngine;

[System.Serializable]
public class PlayerWalkData 
{
    [field: SerializeField][field: Range(0, 5f)] public float SpeedModifer { get; private set; } = 1f;
}
