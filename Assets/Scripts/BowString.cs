using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class BowString : MonoBehaviour
{
    [SerializeField]
    private Transform End1, End2;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Start()
    {
        createString(null);
    }

    public void createString(Vector3? midPositon)
    {
        Vector3[] LinePoints = new Vector3[midPositon == null ? 2 : 3];
        LinePoints[0] = End1.localPosition;
        if (midPositon!= null)
        {
            LinePoints[1] = transform.InverseTransformPoint(midPositon.Value);
        }
        LinePoints[^1] = End2.localPosition;
        lineRenderer.positionCount = LinePoints.Length;
        lineRenderer.SetPositions(LinePoints);
    }
}
