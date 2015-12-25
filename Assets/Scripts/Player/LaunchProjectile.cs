using UnityEngine;
using UnityEngine.UI;

public class LaunchProjectile : ShooterTemplate {

    public Slider aimSlider;
    public GameObject activeSlider;
    public float minLaunchForce = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    private float currentLaunchForce;
    private float chargeSpeed;
    private bool hasFired;

    private void OnEnable() {
        currentLaunchForce = minLaunchForce;
        aimSlider.value = minLaunchForce;
    }


	// Use this for initialization
	protected override void Start () {
        base.Start();
        chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
	}
	
	// Update is called once per frame
	protected override void Update () {

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
            activeSlider.SetActive(true);
            aimSlider.value = currentLaunchForce;
        }
        else if (Input.GetButtonUp(fireButton) && !hasFired) {
            Shoot();
        }
	}

    /// <summary>
    /// Instantiates a Rigidbody prefab and uses the physics engine to launch
    /// the projectile.
    /// on launch, aim slider is deactivated
    /// </summary>
    private void Shoot() {
        hasFired = true;
        Rigidbody shot = Instantiate(projectile, shotTransform.position, shotTransform.rotation) as Rigidbody;
        shot.velocity = currentLaunchForce * shotTransform.forward;

        currentLaunchForce = minLaunchForce;

        activeSlider.SetActive(false);

    }
}
