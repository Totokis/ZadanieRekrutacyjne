using UnityEngine;
using Random = UnityEngine.Random;

public class TargetController : MonoBehaviour
{
    [SerializeField] private float points = 2f;

    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private ParticleController particleController;

    private Color _color;


    public void Hit()
    {
        GameManager.Instance.AddPoints(points);
        Blow();
    }

    public void Blow()
    {
        Debug.Log("Particles");
        particleController.Blow();
        meshRenderer.enabled = false;
    }
    public void Restart()
    {
        meshRenderer.enabled = false;
    }
    public void WakeUp()
    {
        _color = Random.ColorHSV(0.5f, 1f);

        meshRenderer.enabled = true;
        meshRenderer.material.color = _color;

        particleController.Restart(_color);
    }
}