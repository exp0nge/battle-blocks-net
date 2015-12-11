using UnityEngine;
using System.Collections;
using Utilities.Singleton;

public class ParticleManager : Singleton<ParticleManager> {

    public int numberOfParticles = 10;
    public ParticleSystem particleEffect;

    private ParticleSystem[] allParticles;
    private ParticleSystem[] damageParticles;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < numberOfParticles; i++) {
            Instantiate(particleEffect, Vector3.zero, Quaternion.identity);
        }

        allParticles = FindObjectsOfType<ParticleSystem>();

        for (int i = 0; i < allParticles.Length; i++) {
            if (allParticles[i].name == "Take hit(Clone)") {
                damageParticles[i] = allParticles[i];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {

	}
}
