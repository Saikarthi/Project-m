using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerLayerData 
{
    [field: SerializeField] public LayerMask groundLayer { get; private set; } 

    public bool Containlayer(LayerMask layerMask,int layer)
    {
        return (1<<layer& layerMask) != 0;
    }

    public bool IsGroundLayer(int layer)
    {
        return Containlayer( groundLayer,layer);
    }
}
