using UnityEngine;
using System.Collections;

public class Particles : MonoBehaviour {
    public MovementStates mstate;
    public ParticleSystem moveparticles;
    public ParticleSystem dashparticles;
    //public KeyCode dashInput = KeyCode.LeftAlt;
    //public KeyCode left = KeyCode.LeftArrow;
    //public KeyCode right = KeyCode.RightArrow;
    //public KeyCode forward = KeyCode.UpArrow;
    //public KeyCode back = KeyCode.DownArrow;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    { 
        // particle = GetComponentsInChildren<ParticleSystem>();
    }
    void Playtheparticles()
    {
        
    }
    // Use this for initialization
    void Start () {
        //if (Input.GetKeyDown(left) || Input.GetKeyDown(right) || Input.GetKeyDown(forward) || Input.GetKeyDown(back))
       

    }

    // Update is called once per frame
    void Update ()
    {
        if (mstate == MovementStates.isMoving)
        {
            moveparticles.Play();
        }
        if (mstate == MovementStates.isDashing)
        {
            dashparticles.Play();
        }
        else
        {
            moveparticles.Pause();
        }
       

    }

}

