using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MemoryGameSettings", menuName = "ScriptableObjects/MemoryGameSettings", order = 1)]

public class SOPlayerSettings : ScriptableObject
{
    public float PlayerSpeed;
    public float PlayerSpeedInAir;
    public float JumpForce;
}
