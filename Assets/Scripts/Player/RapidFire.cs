using UnityEngine;
using System.Collections;

public class RapidFire : MonoBehaviour
{

    public Rigidbody projectile;
    public Transform shotPosition;
    public float shotForce = 1000f;
    public float fireRate = 3f;
    public int counter = 10;
    public KeyCode shooterKey = KeyCode.Space;

    private float nextInterval;
 //   public Shooter sht;

    // Update is called once per frame
    void Update()
    {
        //Player will shoot if input is true and if the time interval is greater than the set interval
        if(counter > 0)
        {
            GetComponent<Shooter>().enabled = false;
        }
        else
        {
            GetComponent<Shooter>().enabled = true;
        }

        if (Input.GetKey(shooterKey) && Time.time > nextInterval && counter > 0)
        {
            nextInterval = Time.time + fireRate;
            Rigidbody shot = Instantiate(projectile, shotPosition.position, shotPosition.rotation) as Rigidbody;
            shot.AddForce(shotPosition.forward * shotForce);
            counter -= 1;

        }


    }
}