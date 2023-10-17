using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBotDamage : MonoBehaviour
{
    private Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void PenguinBotDamageEffect()
    {
        m_Renderer.material.color = Color.black;
    }

    public void PenguinBotDamageEffectRevert()
    {
        m_Renderer.material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
