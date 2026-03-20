using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms.GunClasses
{
    /// <summary>
    /// The stat's of the gun that can be upgraded
    /// </summary>
    enum GunStat
    {
        DAMAGE,
        FIRE_RATE,
        BULLET_SPEED,
        SHOOTING_COOLDOWN,
        MAX_AMMO
    }

    /// <summary>
    /// Represents an upgrade to the gun's stat's
    /// </summary>
    internal class StatModifier
    {
        private GunStat _gunStat; // The gun stat it's modifying
        private float _modifier; // How much it's modifying

        /// <summary>
        /// Creates a Gun Part that represents a modifier to the gun.
        /// </summary>
        /// <param name="gunStat">The gun stat that it is modifying</param>
        /// <param name="modifier">How much it modifies the gun by</param>
        public StatModifier(GunStat gunStat, float modifier)
        {
            _modifier = modifier;
            _gunStat = gunStat;
        }

        public override string ToString()
        {
            string toString = "";

            toString = $"{_gunStat.ToString()} -> {_modifier}";

            return toString;
        }
    }
}
