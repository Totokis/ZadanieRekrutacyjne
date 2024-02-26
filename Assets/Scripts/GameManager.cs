using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;

    [SerializeField] private TargetManager targetManager;

    private void Start()
    {
        targetManager.targetsToSpawn = waves.First().targetsToSpawn;
        targetManager.Create();
    }
}