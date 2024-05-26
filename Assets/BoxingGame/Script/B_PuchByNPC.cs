using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class B_PuchByNPC : MonoBehaviour
{

    [SerializeField]
    AudioSource HitAudio;
    [SerializeField]
    B_scoreSyem0 scoreSyem;
    public Volume volume;

    void Start()
    {
        //volume.weight = 1.0f;
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
        Debug.Log("hhiiiiiiii");
        if(other.gameObject.tag == "NPC")
        {
            Debug.Log("hit by npc");
            HitAudio.Play();
            scoreSyem.RedScoreAdd();
            StartCoroutine(OnHit());
        }
    }
}
