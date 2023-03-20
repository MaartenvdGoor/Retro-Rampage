using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
	public class Weapon
	{
		public float timeBetweenShots;
		public float Spread;
		public WeaponType WeaponType;

	}
	public enum WeaponType
	{
		Pistol,
		Shotgun,
		SMG
	}
}
