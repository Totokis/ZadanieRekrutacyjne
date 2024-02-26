using System.Collections.Generic;
using System.Linq;
using Extensions;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private List<TargetLocation> targetLocations;
    private readonly Dictionary<TargetLocation, TargetController> _locationTargetMap = new();
    private readonly Dictionary<TargetController, TargetLocation> _targetLocationMap = new();
    private float _nextTimeToAct;
    private bool _start;
    private Wave _wave;

    private void Update()
    {
        if (_start)
        {
            if (Time.time >= _nextTimeToAct)
            {
                SpawnTarget();

                _nextTimeToAct = Time.time + _wave.frequencyOfSpawning;
            }
        }
    }

    public void Hit(GameObject colliderGameObject)
    {
        var target = _targetLocationMap.Keys.FirstOrDefault(tc => tc.gameObject.Equals(colliderGameObject));
        if (target)
        {
            target.Hit();
            _targetLocationMap[target].isTaken = false;
            _nextTimeToAct = Time.time + _wave.frequencyOfSpawning;
        }
    }
    private void SpawnTarget()
    {
        var location = _locationTargetMap.Keys.Where(tl => tl.IsNotTaken).ToList().RandomElementOrDefault();

        if (location != default)
        {
            location.isTaken = true;
            _locationTargetMap[location].WakeUp();
        }
        else
        {
            FindObjectOfType<GameManager>().GameOver();
            _start = false;
        }
    }

    public void Restart(Wave wave)
    {
        _start = true;
        _nextTimeToAct = Time.time + wave.frequencyOfSpawning;
        _wave = wave;

        _targetLocationMap.Clear();
        _locationTargetMap.Clear();

        foreach (var location in targetLocations)
        {
            var target = _wave.targetsToSpawn.RandomElementOrDefault();
            if (target == default)
            {
                Debug.Log("Wave object has empty target field");
            }
            else
            {
                var createdTarget = Instantiate(target, location.transform.position, Quaternion.identity);
                createdTarget.Restart();
                _targetLocationMap.Add(createdTarget, location);
                _locationTargetMap.Add(location, createdTarget);
            }
        }


        if (targetLocations.Count == 0)
        {
            Debug.Log("Locations are empty. Fill to generate targets");
        }
    }
}