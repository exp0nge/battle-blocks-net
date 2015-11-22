using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
    public MovementStates mstate;
    //public ParticleSystem moveparticles;
    //public ParticleSystem dashparticles;
    public ParticleSystem[] particle;

    void Awake()
    {
        particle = GetComponentsInChildren<ParticleSystem>();
        //moveparticles = GetComponentInChildren<ParticleSystem>();
        //dashparticles = GetComponentInChildren<ParticleSystem>();
    }

    // Use this for initialization
    void Start()
    {
        //if (Input.GetKeyDown(left) || Input.GetKeyDown(right) || Input.GetKeyDown(forward) || Input.GetKeyDown(back))
    }

    void Update ()
    {
        if (mstate == MovementStates.isMoving)
        {
            particle[0].Play();
            //moveparticles.Play();
        }
        else if (mstate == MovementStates.isDashing)
        {
            particle[1].Play();
            //dashparticles.Play();
        }
        else// (mstate == MovementStates.isStill)
        {
            particle[0].Pause();
            //moveparticles.Pause();
        }
    }

}

