using UnityEngine;
 
[System.Serializable]
public class PlayerSprintingData 
{
    [field: SerializeField][field: Range(0, 5f)] public float SpeedModifer { get; private set; } = 2f;
}
