using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private GameObject MidPointVisualObject, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 10;

    public void prepareArrow()
    {
        MidPointVisualObject.SetActive(true);
    }

    public void ReleaseArrow(float strength)
    {
        MidPointVisualObject.SetActive(false);

        GameObject Arrow = Instantiate(arrowPrefab);
        Arrow.transform.position = arrowSpawnPoint.transform.position;
        Arrow.transform.rotation = MidPointVisualObject.transform.rotation;
        Rigidbody rb = Arrow.GetComponent<Rigidbody>();
        rb.AddForce(MidPointVisualObject.transform.forward * strength * arrowMaxSpeed, ForceMode.Impulse);
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
