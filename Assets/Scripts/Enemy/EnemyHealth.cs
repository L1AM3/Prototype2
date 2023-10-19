using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHealthCount = 3;
    public PenguinBotDeathAnimation BotDead;
    public PenguinBotDamage BotDamage;
    public EnemyKillCounter EnemyKill;

    public void EnemyHealthDecrease(int damage = 1)
    {
        EnemyHealthCount -= damage;
        BotDamage.PenguinBotHurtAnimatior(true);
        Invoke("RevertDelay", 1);
        //Debug.Log(EnemyHealthCount);
        EnemyDeath();
    }

    public void EnemyDeath()
    {
        if (EnemyHealthCount == 0)
        {
            Debug.Log("EnemyDie!");
            EnemyKill.KillCount();
            BotDead.PenguinBotDeathAnimatior(true);
            Invoke("Delay", 1);
        }
    }
    
    public void Delay()
    {
        gameObject.SetActive(false);
    }

    public void RevertDelay()
    {
        BotDamage.PenguinBotHurtAnimatior(false);
    }

}
