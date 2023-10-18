using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKillCounter : MonoBehaviour
{
    private int KillCounter = 0;
    public TMP_Text KillingCount;

    public void Awake()
    {
        KillCounter = 0;
    }

    public void KillCount ()
    {
        KillCounter++;
        Debug.Log(KillCounter);
    }

    public void Update()
    {
        KillingCount.text = KillCounter.ToString();
    }
}
