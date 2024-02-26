using UnityEngine;
using Random = UnityEngine.Random;

public class TargetController : MonoBehaviour
{
    [SerializeField] private float points = 2f;

    [SerializeField] private MeshRenderer meshRenderer;

    private void OnEnable()
    {
        meshRenderer.material.color = Random.ColorHSV(0.5f, 1f);
    }

    private void OnDisable()
    {
        Debug.Log("Particles");
    }


    public void Hit()
    {
        FindObjectOfType<GameManager>().AddPoints(points);
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        gameObject.SetActive(false);
    }
    public void WakeUp()
    {
        gameObject.SetActive(true);
    }
}