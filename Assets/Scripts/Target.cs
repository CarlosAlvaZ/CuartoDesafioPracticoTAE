using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float healt = 50f;

    public GameObject explode;

    public void TakeDamage(float amount)
    {
        healt -= amount;
        if (healt <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        GameObject explosion = Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion, 2f);
    }
}
