using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int EnemyHealthCount = 3;
    public PenguinBotDeathAnimation BotDead;
    public PenguinBotDamage BotDamage;

    public void EnemyHealthDecrease(int damage = 1)
    {
        BotDamage.PenguinBotDamageEffect();
        EnemyHealthCount -= damage;
        //Invoke("RevertDelay", 2);
        //Debug.Log(EnemyHealthCount);
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

    public void RevertDelay()
    {
        BotDamage.PenguinBotDamageEffectRevert();
    }

}
