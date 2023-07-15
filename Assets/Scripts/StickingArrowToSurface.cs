using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private SphereCollider myCollider;

    [SerializeField]
    private GameObject stickingArrow;

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject Arrow = Instantiate(stickingArrow);
        Arrow.transform.position = transform.position;
        Arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            Arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        //collision.collider.GetComponent<IHittable>()?.GetHit();

        Destroy(gameObject);
    }
}
