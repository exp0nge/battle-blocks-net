using UnityEngine;
using System.Collections;

public class ParticleManager : MonoBehaviour {

    public int numberOfParticles = 10;
    public ParticleSystem particleEffect;

    private ParticleSystem[] particles;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < numberOfParticles; i++) {
            Instantiate(particleEffect, Vector3.zero, Quaternion.identity);
        }

        particles = FindObjectsOfType<ParticleSystem>();

        for (int i = 0; i < particles.Length; i++) {
            if (particles[i].name == "Take hit(Clone)") {

            }
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
