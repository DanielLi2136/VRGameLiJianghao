using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrorRotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Rb;

    private void FixedUpdate()
    {
       transform.forward =
            Vector3.Slerp(transform.forward, Rb.velocity.normalized, Time.fixedDeltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
