using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private new ParticleSystem particleSystem;

    public void Blow()
    {
        particleSystem.gameObject.SetActive(true);
    }
    public void Restart(Color color)
    {
        var main = particleSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(color);
        particleSystem.gameObject.SetActive(false);
    }
}