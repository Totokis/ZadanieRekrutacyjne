using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave file", menuName = "Wave")]
public class Wave : ScriptableObject
{
    public List<TargetController> targetsToSpawn;
    public int pointLimit;
    public float frequencyOfSpawning;
}