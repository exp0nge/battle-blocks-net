using UnityEngine;
using UnityEngine.UI;

public class LaunchProjectile : MonoBehaviour {

    public int playerNumber = 1;
    public Rigidbody projectile;
    public Transform shotTransform;
    public Slider aimSlider;
    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    private string fireButton;
    private float currentLaunchForce;
    private float chargeSpeed;
    private bool hasFired;

    private void OnEnable() {
        currentLaunchForce = minLaunchForce;
        aimSlider.value = minLaunchForce;
    }


	// Use this for initialization
	private void Start () {
        fireButton = "Fire" + playerNumber;
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
	}
	
	// Update is called once per frame
	private void Update () {

        aimSlider.value = minLaunchForce;

        if (currentLaunchForce >= maxLaunchForce && !hasFired) {
            currentLaunchForce = maxLaunchForce;
            Shoot();    
        }
        else if (Input.GetButtonDown(fireButton)) {
            hasFired = false;
            currentLaunchForce = minLaunchForce;
        }
        else if (Input.GetButton (fireButton) && !hasFired) {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            aimSlider.value = currentLaunchForce;
        }
        else if (Input.GetButtonUp(fireButton) && !hasFired) {
            Shoot();
        }
	}

    private void Shoot() {
        hasFired = true;
        Rigidbody shot = Instantiate(projectile, shotTransform.position, shotTransform.rotation) as Rigidbody;
        shot.velocity = currentLaunchForce * shotTransform.forward;

        currentLaunchForce = minLaunchForce;
    }
}
