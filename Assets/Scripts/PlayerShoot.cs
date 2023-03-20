using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public bool canFire;
    public Weapon SelectedWeapon;

    public static float PistolROF = 0.3f;
    public static float ShotgunROF = 0.5f;
    public static float SMGROF = 0.1f;

	private float timer;
	// Start is called before the first frame update
	void Start()
    {
        SelectedWeapon = new Weapon(0, WeaponType.SMG);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > SelectedWeapon.TimeBetweenShots)
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
		if (Input.GetMouseButtonDown(0) && canFire)
		{
			canFire = false;

            for (int i = 0; i < 5; i++)
            {

            }
		}
	}

    void FireSMG()
    {
		if ((Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) && canFire)
		{
			canFire = false;
			Instantiate(bullet, transform.position, Quaternion.identity);
            Debug.Log("Fired");
		}
	}
}


