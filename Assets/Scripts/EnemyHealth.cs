using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHealthCount = 3;
    public PenguinBotDeathAnimation BotDead;

    public void EnemyHealthDecrease(int damage = 1)
    {
        EnemyHealthCount -= damage;
        Debug.Log(EnemyHealthCount);
        EnemyDeath();
    }

    public void EnemyDeath()
    {
        if (EnemyHealthCount <= 0)
        {
            BotDead.PenguinBotDeathAnimatior(true);
            Invoke("Delay", 1);
        }
    }
    
    public void Delay()
    {
        gameObject.SetActive(false);
    }

}
