using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AttackableItem : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        //Gets the rigidbody of the attackable item
        rb = GetComponent<Rigidbody>();
    }

    //Gets player input when the click the mouse
    public void OnPlayerAttack(Vector3 hitDirection)
    {
        //Adds force to rigidbody when input is detected
        rb.AddForce(hitDirection.normalized * 30, ForceMode.Impulse);
    }
}
