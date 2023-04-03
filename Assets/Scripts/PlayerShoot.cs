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
        SelectedWeapon = new Weapon(0f, WeaponType.Pistol);
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
			GameObject pellet = Instantiate(bullet, transform.position,Quaternion.identity);
			pellet.GetComponent<Bullet>().spread = SelectedWeapon.Spread;
            pellet.GetComponent<Bullet>().isPlayerBullet = true;
		}
    }

    void FireShotGun()
    {
		if (Input.GetMouseButtonDown(0) && canFire)
		{
			canFire = false;

            for (int i = 0; i < 5; i++)
            {
                GameObject pellet = Instantiate(bullet,transform.position,Quaternion.identity);
                pellet.GetComponent<Bullet>().spread = SelectedWeapon.Spread;
				pellet.GetComponent<Bullet>().isPlayerBullet = true;
			}
		}
	}

    void FireSMG()
    {
		if ((Input.GetMouseButton(0) || Input.GetMouseButtonDown(0)) && canFire)
		{
			canFire = false;
			GameObject pellet = Instantiate(bullet, transform.position, Quaternion.identity);
			pellet.GetComponent<Bullet>().spread = SelectedWeapon.Spread;
			pellet.GetComponent<Bullet>().isPlayerBullet = true;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Pickup")
		{
			collision.gameObject.GetComponent<WeaponDrop>().player = gameObject;
			collision.gameObject.GetComponent<WeaponDrop>().canPickUp = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Pickup")
		{
			collision.gameObject.GetComponent<WeaponDrop>().player = null;
			collision.gameObject.GetComponent<WeaponDrop>().canPickUp = false;
		}
	}

}


