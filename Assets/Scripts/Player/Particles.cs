using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
    
    public ParticleSystem moveParticles;
    public ParticleSystem dashParticles;

    private MovementStates mstate;

    void Awake()
    {
        //particle = GetComponentsInChildren<ParticleSystem>();
        //moveparticles = GetComponentInChildren<ParticleSystem>();
        //dashparticles = GetComponentInChildren<ParticleSystem>();
    }

    void Update ()
    {
        mstate = GetComponent<Movement>().currentState;
        if (mstate == MovementStates.isMoving)
        {
            moveParticles.gameObject.SetActive(true);
            moveParticles.Play();
            if (!dashParticles.isPlaying) {
                dashParticles.Pause();
                dashParticles.gameObject.SetActive(false);
            }
        }
        else if (mstate == MovementStates.isDashing)
        {
            dashParticles.gameObject.SetActive(true);
            dashParticles.Play();
        }
        else if (mstate == MovementStates.isStill)
        {
            moveParticles.Pause();
            moveParticles.gameObject.SetActive(false);
            if (!dashParticles.isPlaying) {
                dashParticles.Pause();
                dashParticles.gameObject.SetActive(false);
            }
        }
    }

}

