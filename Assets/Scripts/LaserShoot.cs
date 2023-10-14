using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour
{
    public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
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
            laser.SetActive(true);
        }
        else if (!Input.GetKey(KeyCode.Mouse1))
        {
            laser.SetActive(false);
        }
    }
}
