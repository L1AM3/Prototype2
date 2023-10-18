using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKillCounter : MonoBehaviour
{
    private int KillCounter = 0;
    public TMP_Text KillingCount;
    public KillCounterAnimation KillCounterAnim;

    public void Awake()
    {
        KillCounter = 0;
    }

    public void KillCount ()
    {
        KillCounter++;
        KillCounterAnim.KillerCounterAnimation(true);
        Invoke("Delay", 2);
        Debug.Log(KillCounter);
    }

    public void Update()
    {
        KillingCount.text = KillCounter.ToString();
    }

    public void Delay()
    {
        KillCounterAnim.KillerCounterAnimation(false);
    }
}
