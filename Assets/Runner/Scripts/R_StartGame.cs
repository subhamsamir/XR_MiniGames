using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private bool Right_H = false, Left_H = false;

    [SerializeField]
    R_OculusPlayerController oculusPlayerController;

    public GameObject canvas;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RightHand")
        {
            Debug.Log("Right done");
            Right_H = true;
        }
        if (other.gameObject.tag == "LeftHand")
        {
            Debug.Log("Left done");
            Left_H = true;
        }
        if (Right_H == true && Left_H == true)
        {
            Debug.Log("Final done");
            Destroy(canvas);
            oculusPlayerController.StartPlayer(20.0f);
        }
    }
}
