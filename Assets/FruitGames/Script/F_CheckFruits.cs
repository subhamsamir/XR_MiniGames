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
    IEnumerator OnHit()
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
                scoreSystem.WrongFruit(40,"Mango");
                StartCoroutine(OnHit());
            }
            if(other.gameObject.tag == "Orange")
            {
                scoreSystem.WrongFruit(60, "Orange");
                StartCoroutine(OnHit());

            }
        }
        if (isOrange)
        {
            if (other.gameObject.tag == "Apple")
            {
                scoreSystem.WrongFruit(40, "Apple");
                StartCoroutine(OnHit());

            }
            if (other.gameObject.tag == "Mango")
            {
                scoreSystem.WrongFruit(40, "Mango");
                StartCoroutine(OnHit());

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
                scoreSystem.WrongFruit(40, "Apple");
                StartCoroutine(OnHit());

            }
            if (other.gameObject.tag == "Mango")
            {
                // Mmm
            }
            if (other.gameObject.tag == "Orange")
            {
                scoreSystem.WrongFruit(60, "Orange");
                StartCoroutine(OnHit());

            }
        }
    }
}
