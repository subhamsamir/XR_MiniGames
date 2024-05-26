using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class B_BlueHit : MonoBehaviour
{

    [SerializeField]
    AudioSource HitAudio;
    [SerializeField]
    B_scoreSyem0 scoreSyem;

    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;

    void Start()
    {
        // Get the devices for left and right hand controllers
        leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hhiiiiiiii");
        if (other.gameObject.tag == "Right")
        {
            Debug.Log("hit by Player");
            HitAudio.Play();
            scoreSyem.BlueScoreAdd();
            rightHandDevice.SendHapticImpulse(0, .5f, .5f);
            //leftHandDevice.SendHapticImpulse(0, .5f, .5f);
        }
        if (other.gameObject.tag == "Left")
        {
            Debug.Log("hit by Player");
            HitAudio.Play();
            scoreSyem.BlueScoreAdd();
            //rightHandDevice.SendHapticImpulse(0, .5f, .5f);
            leftHandDevice.SendHapticImpulse(0, .5f, .5f);
        }
    }
}
