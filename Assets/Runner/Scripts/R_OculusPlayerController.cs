using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class R_OculusPlayerController : MonoBehaviour
{
    public Transform VRPlayer;

    public AudioSource CoinMusic;

    public float lookDoownAngle = 15.0f;

    public float speed = 3.0f;

    public bool isPlaying = false;
    CharacterController characterController;

    [SerializeField]
    GameObject GameOverUI;
    bool isCollied = false;

    public R_SpawnManager spawnManager;
    private R_ScoringSystem scoringSystem;

    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;

    private void Start()
    {
        speed = 0f;
        scoringSystem = new R_ScoringSystem();
        characterController = GetComponent<CharacterController>();
        // Get the devices for left and right hand controllers
        leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }
    private void Update()
    {
        if(VRPlayer.eulerAngles.x < lookDoownAngle && VRPlayer.eulerAngles.x < 120.0f) {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }

        if (isPlaying == true)
        {
            Vector3 foward = VRPlayer.TransformDirection(Vector3.forward);
            characterController.SimpleMove(foward * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Collid");
            spawnManager.spawnTriggerEntered();
            rightHandDevice.SendHapticImpulse(0, .5f, .5f);
            leftHandDevice.SendHapticImpulse(0, .5f, .5f);
        }
        if (other.gameObject.tag == "Box" && isCollied == false)
        {
            GameOver();
            isCollied = true;
            rightHandDevice.SendHapticImpulse(0, .5f, .5f);
            leftHandDevice.SendHapticImpulse(0, .5f, .5f);
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            scoringSystem.AddScore(1);
            CoinMusic.Play();
            Debug.Log("Coin");
            rightHandDevice.SendHapticImpulse(0, .5f, .5f);
            leftHandDevice.SendHapticImpulse(0, .5f, .5f);
        }
        //if (other.gameObject.tag == "SpawnTrigger")
        
        if(other.gameObject.tag == "resetGame")
        {
            rightHandDevice.SendHapticImpulse(0, .5f, .5f);
            leftHandDevice.SendHapticImpulse(0, .5f, .5f);
            ResetGame("R_Level 1");
        }


    }

    public void StartPlayer(float PlayerSpeed)
    {
        speed = PlayerSpeed;
    }

    private void OnTriggerExit(Collider other)
    {
        isCollied = false;
    }

    private void GameOver()
    {
        speed = 0f;
        GameOverUI.SetActive(true);
    }
    public void ResetGame(string name)
    {
        scoringSystem.Reset();
        SceneManager.LoadScene(name);
    }
    public void stop()
    {
        speed = 0f;
    }

}
