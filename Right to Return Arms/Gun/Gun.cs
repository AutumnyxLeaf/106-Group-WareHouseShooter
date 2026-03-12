using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms.Gun
{
    /// <summary>
    /// A class representing the players Gun and it's upgrades
    /// </summary>
    internal class Gun
    {
        // Gun Part Fields
        private GunPart _barrel; // The barrel of the gun
        private GunPart _grip; // The grip of the gun
        private GunPart _stock; // The stock of the gun
        private GenericGunUpgrade[] _genericGunUpgrades; // The generic gun upgrades

        // Gun Shooting Fields
        private float _shootingCoolDown;

        /// <summary>
        /// Creates a gun with the barrel, grip, stock, and generic upgrades
        /// </summary>
        /// <param name="barrel">The gun's Barrel Part</param>
        /// <param name="grip">The gun's Grip Part</param>
        /// <param name="stock">The gun's Stock Part</param>
        /// <param name="genericGunUpgrades">All the gun's generic upgrades</param>
        public Gun(GunPart barrel, GunPart grip, GunPart stock, 
            params GenericGunUpgrade[] genericGunUpgrades)
        {
            _barrel = barrel;
            _grip = grip;
            _stock = stock;
            _genericGunUpgrades = genericGunUpgrades;
        }

        public Bullet ShootBullet()
        {
            return new Bullet();
        }
    }
}
