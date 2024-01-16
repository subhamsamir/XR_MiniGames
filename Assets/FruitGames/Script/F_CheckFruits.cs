using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_CheckFruits : MonoBehaviour
{
    [SerializeField]
    private bool isApple, isOrange, isMango;

    [SerializeField]
    private F_ScoreSystem scoreSystem;

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
            }
            if(other.gameObject.tag == "Orange")
            {
                scoreSystem.WrongFruit(60, "Orange");
            }
        }
        if (isOrange)
        {
            if (other.gameObject.tag == "Apple")
            {
                scoreSystem.WrongFruit(40, "Apple");
            }
            if (other.gameObject.tag == "Mango")
            {
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
                scoreSystem.WrongFruit(40, "Apple");
            }
            if (other.gameObject.tag == "Mango")
            {
                // Mmm
            }
            if (other.gameObject.tag == "Orange")
            {
                scoreSystem.WrongFruit(60, "Orange");
            }
        }
    }
}
