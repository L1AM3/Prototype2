using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public LaserInteract Interact;
    public LaserAnimation shoot;
    public bool FireLaser;

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    public void ShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Interact.IsActive = true;
            FireLaser = true;
            shoot.LaserShootAnimation(FireLaser);
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Interact.IsActive = false;
            FireLaser = false;
            shoot.LaserShootAnimation(FireLaser);
        }
    }
}
