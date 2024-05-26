using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class F_CheckFruits : MonoBehaviour
{
    [SerializeField]
    private bool isApple, isOrange, isMango;

    [SerializeField]
    private F_ScoreSystem scoreSystem;

    [SerializeField]
    AudioClip coin;
    [SerializeField]
    AudioClip error;

    AudioSource coinSource;

    public Volume volume;

    void Start()
    {
        //volume.weight = 1.0f;
        coinSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    // Call this method when the player gets hit
    public IEnumerator OnHit()
    {
        volume.weight = 1.0f;
        yield return new WaitForSeconds(1);
        volume.weight = 0.0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isApple)
        {
            if(other.gameObject.tag == "Apple")
            {
               //scoreSystem.WrongFruit(,"");
            }
            if (other.gameObject.tag == "Mango")
            {
                StartCoroutine(OnHit());

                scoreSystem.WrongFruit(40,"Mango");
            }
            if(other.gameObject.tag == "Orange")
            {
                StartCoroutine(OnHit());
                scoreSystem.WrongFruit(60, "Orange");
    

            }
        }
        if (isOrange)
        {
            if (other.gameObject.tag == "Apple")
            {
                StartCoroutine(OnHit());

                scoreSystem.WrongFruit(40, "Apple");

            }
            if (other.gameObject.tag == "Mango")
            {
                StartCoroutine(OnHit());

                scoreSystem.WrongFruit(40, "Mango");

            }
            if (other.gameObject.tag == "Orange")
            {
                // Oooo
            }
        }
        if (isMango)
        {
            if (other.gameObject.tag == "Apple")
            {
                StartCoroutine(OnHit());

                scoreSystem.WrongFruit(40, "Apple");
                Debug.Log("wrong");

            }
            if (other.gameObject.tag == "Mango")
            {
                // Mmm
            }
            if (other.gameObject.tag == "Orange")
            {
                StartCoroutine(OnHit());

                scoreSystem.WrongFruit(60, "Orange");
                Debug.Log("wrong");


            }
        }
    }
}
