using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDrop : MonoBehaviour
{
	// Start is called before the first frame update
	public bool canPickUp = false;
	public WeaponType WeaponType;
	public float Spread;
	public GameObject player;


	private void Update()
	{
		if (canPickUp && Input.GetKeyDown(KeyCode.E))
		{
			Weapon weapon = new Weapon(Spread, WeaponType);
			player.GetComponent<PlayerShoot>().SelectedWeapon = weapon;
			Destroy(gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			player = collision.gameObject;
			canPickUp = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "False")
		{
			player = collision.gameObject;
			canPickUp = true;
		}
	}
}
