using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targetLocations;

    public List<TargetController> targetsToSpawn;
    private readonly List<TargetController> _targets = new();

    public void Hit(GameObject colliderGameObject)
    {
        var target = _targets.FirstOrDefault(o => o.gameObject.Equals(colliderGameObject));
        if (target)
        {
            target.Hit();
        }
    }
    public void Create()
    {
        if (targetLocations.Count == 0)
        {
            Debug.Log("Locations are empty. Fill to generate targets");
        }

        foreach (var location in targetLocations)
        {
            var createdTarget = Instantiate(targetsToSpawn[Random.Range(0, targetsToSpawn.Count)], location.transform.position, Quaternion.identity);
            _targets.Add(createdTarget);
        }
    }
}