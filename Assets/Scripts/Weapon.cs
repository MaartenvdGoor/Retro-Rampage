using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
	public class Weapon
	{
		public float TimeBetweenShots;
		public float Spread;
		public WeaponType WeaponType;
		public int MaxAmmo;
		public int CurrentAmmo;

		public Weapon(float spread, WeaponType weaponType)
		{
			switch (weaponType)
			{
				case WeaponType.Pistol:
					TimeBetweenShots = PlayerShoot.PistolROF;
					break;
				case WeaponType.Shotgun:
					TimeBetweenShots = PlayerShoot.ShotgunROF;
					break;
				case WeaponType.SMG:
					TimeBetweenShots = PlayerShoot.SMGROF;
					break;
				default:
					break;
			}
			Spread = spread;
			WeaponType = weaponType;
		}
	}
	public enum WeaponType
	{
		Pistol,
		Shotgun,
		SMG
	}
}
