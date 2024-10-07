using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    private InputManager inputManager;

    public Camera cam;
    public LayerMask mask;
    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    private AudioSource shot;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        inputManager = GetComponentInParent<InputManager>();
        shot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputManager.onFoot.Shoot.inProgress && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;


            Shoot();
        }
    }

    void Shoot()
    {

        muzzleFlash.Play();

        shot.PlayOneShot(shot.clip, Random.Range(0.7f, 1));

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * range);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range, mask))
        {
            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }


            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
