using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHead : MonoBehaviour
{
    public GameObject deathvfx;
    public AudioSource hitsfx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //play dead animation
            //play vfx and sfx
            //hitsfx.Play();
            Instantiate(deathvfx, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
