using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class BowStringController : MonoBehaviour
{
    [SerializeField]
    private BowString BowStringRender;

    private XRGrabInteractable Interactable;
    [SerializeField]
    private Transform GrabPoint, MidPointVisualObject, MidPointParent;

    [SerializeField]
    private float BowStringStretchLimit = 0.3f;

    private Transform Interactor;

    private float Strength;

    public UnityEvent onBowPulled;
    public UnityEvent<float> OnBowReleased;

    private void Awake()
    {
        Interactable = GrabPoint.GetComponent<XRGrabInteractable>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        Interactable.selectEntered.AddListener(PrepareBowString);
        Interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        OnBowReleased?.Invoke(Strength);
        Strength = 0;

        Interactor = null;
        GrabPoint.localPosition = Vector3.zero;
        MidPointVisualObject.localPosition= Vector3.zero;
        BowStringRender.createString(null);
    }

    private void PrepareBowString(SelectEnterEventArgs arg0)
    {
        Interactor = arg0.interactableObject.transform;
        onBowPulled?.Invoke();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Interactor != null)
        {
            Vector3 MidPointLocalSpace =
                MidPointParent.InverseTransformPoint(GrabPoint.position);

            float MidPointLocalZAbs = Mathf.Abs(MidPointLocalSpace.z);

            HandleStringPushedBackToStart(MidPointLocalSpace);

            HandleStringPulledBackToLimit(MidPointLocalZAbs, MidPointLocalSpace);

            HandlePullingString(MidPointLocalZAbs, MidPointLocalSpace);

            BowStringRender.createString(MidPointVisualObject.position);
        }
    }

    private void HandlePullingString(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs < BowStringStretchLimit)
        {
            Strength = Remap(midPointLocalZAbs, 0, BowStringStretchLimit, 0, 1);
            MidPointVisualObject.localPosition = new Vector3(0, 0, midPointLocalSpace.z);
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackToLimit(float midPointLocalZAbs, Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z < 0 && midPointLocalZAbs >= BowStringStretchLimit)
        {
            Strength = 1;
            MidPointVisualObject.localPosition = new Vector3(0, 0, -BowStringStretchLimit);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 midPointLocalSpace)
    {
        if (midPointLocalSpace.z >= 0)
        {
            Strength = 0;
            MidPointVisualObject.localPosition = Vector3.zero;
        }
    }
}
