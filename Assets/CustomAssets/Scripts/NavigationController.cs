using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR;

public class NavigationController : Navigation
{
    public XRNode PrimarySource;
    public XRNode SecondarySource;

    // Update is called once per frame
    void Update()
    {
        InputDevice primaryDevice = InputDevices.GetDeviceAtXRNode(PrimarySource);
        primaryDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out MovementAxis);
        primaryDevice.TryGetFeatureValue(CommonUsages.triggerButton, out run);

        InputDevice secondaryDevice = InputDevices.GetDeviceAtXRNode(SecondarySource);
        secondaryDevice.TryGetFeatureValue(CommonUsages.primaryButton, out jump);
    }
}
