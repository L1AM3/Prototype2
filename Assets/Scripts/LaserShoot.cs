using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public LaserAnimation shoot;
    public bool FireLaser;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<CapsuleCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    public void ShootLaser()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //GetComponent<CapsuleCollider>().enabled = true;
            FireLaser = true;
            shoot.LaserShootAnimation(FireLaser);
        }
        else if (!Input.GetKey(KeyCode.Mouse1))
        {
            //GetComponent<CapsuleCollider>().enabled = false;
            FireLaser = false;
            shoot.LaserShootAnimation(FireLaser);
        }
    }
}
