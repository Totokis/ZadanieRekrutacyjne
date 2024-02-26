using UnityEngine;

public class TargetLocation : MonoBehaviour
{
    public bool isTaken;

    public bool IsNotTaken => !isTaken;
}