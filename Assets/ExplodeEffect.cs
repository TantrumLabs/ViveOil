using UnityEngine;
using System.Collections;

public class ExplodeEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem partSys;

	public void PlayExplode()
    {
        partSys.Play();
    }
}
