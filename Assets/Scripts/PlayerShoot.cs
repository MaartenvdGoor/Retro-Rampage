using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFire;
    public Weapon SelectedWeapon;

	private float timer;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFire)
            {
                canFire = true;
                timer = 0;
            }
        }
		switch (SelectedWeapon.WeaponType)
		{
			case WeaponType.Pistol:
				FirePistol();
				break;
			case WeaponType.Shotgun:
				FireShotGun();
				break;
			case WeaponType.SMG:
				FireSMG();
				break;
			default:
				break;
		}
	}

    void FirePistol()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, transform.position,Quaternion.identity);
        }
    }

    void FireShotGun()
    {

    }

    void FireSMG()
    {

    }
}


