using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //int for enemy's health
    public int EnemyHealthCount = 3;

    //public references to different scripts
    public PenguinBotDeathAnimation BotDead;
    public PenguinBotDamage BotDamage;
    public EnemyKillCounter EnemyKill;

    //Decreases enemy health when called
    public void EnemyHealthDecrease(int damage = 1)
    {
        //Subtracting damage variable from current enemy health count
        EnemyHealthCount -= damage;

        //Plays animation and reverts it when damage is taken
        BotDamage.PenguinBotHurtAnimatior(true);
        Invoke("RevertDelay", 1);

        //Calls enemy death to check if enemy has died
        EnemyDeath();
    }

    //Kills enemy if they have 0 health
    public void EnemyDeath()
    {
        //If enemy has no health left, they will die
        if (EnemyHealthCount == 0)
        {
            //Adds to kill counter when enemy is killed
            EnemyKill.KillCount();

            //Plays enemy death animation then sets them to false
            BotDead.PenguinBotDeathAnimatior(true);
            Invoke("Delay", 1);
        }
    }
    
    //Delay so animation for death can play
    public void Delay()
    {
        //Sets game object to false when done
        gameObject.SetActive(false);
    }

    //Delay so animation for damage can play
    public void RevertDelay()
    {
        //Sets animation back to false so the eyes go back to normal
        BotDamage.PenguinBotHurtAnimatior(false);
    }

}
