using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrorRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Rb;

    private void FixedUpdate()
    {
       transform.right =
            Vector3.Slerp(transform.right, Rb.velocity.normalized, Time.fixedDeltaTime);
    }
}
