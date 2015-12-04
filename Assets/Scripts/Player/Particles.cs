﻿using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
    public MovementStates mstate;
    public ParticleSystem moveparticles;
    public ParticleSystem dashparticles;
    //public ParticleSystem[] particle;

    void Awake()
    {
        //particle = GetComponentsInChildren<ParticleSystem>();
        //moveparticles = GetComponentInChildren<ParticleSystem>();
        //dashparticles = GetComponentInChildren<ParticleSystem>();
    }

    // Use this for initialization
    void Start()
    {
    }

    void Update ()
    {
        mstate = GetComponent<Movement>().currentState;
        if (mstate == MovementStates.isMoving)
        {
            //particle[0].Play();
            moveparticles.Play();
            Debug.Log("MOVE particles playing");
        }
        else if (mstate == MovementStates.isDashing)
        {
            //particle[1].Play();
            dashparticles.Play();
            Debug.Log("DASH particles playing");

        }
        else if (mstate == MovementStates.isStill)
        {
            //particle[0].Pause();
            moveparticles.Pause();
            Debug.Log("particles stopped");

        }
    }

}

