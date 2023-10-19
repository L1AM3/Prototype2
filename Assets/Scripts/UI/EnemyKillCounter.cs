using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKillCounter : MonoBehaviour
{
    //int for enemies killed in a playthrough
    private int killCounter = 0;

    //reference to text object
    public TMP_Text KillingCount;

    //public reference to script
    public KillCounterAnimation KillCounterAnim;

    public void Awake()
    {
        //Sets kill counter to zero to make sure game starts with it at zero
        killCounter = 0;
    }

    //Called when enemy is killed
    public void KillCount ()
    {
        //Adds to kill counter
        killCounter++;

        //Animates kill counter to be visible and then back to invisible
        KillCounterAnim.KillerCounterAnimation(true);
        Invoke("Delay", 2);
    }

    public void Update()
    {
        //Updates kill counter text with the enemies killed
        KillingCount.text = killCounter.ToString();
    }

    public void Delay()
    {
        //Sets kill counter back to invisible
        KillCounterAnim.KillerCounterAnimation(false);
    }
}
