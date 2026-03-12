using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms.Gun
{
    enum GunPartID
    {
        STOCK,
        BARREL,
        GRIP
    }

    /// <summary>
    /// A class representing a gun part and it's 
    /// stat's on the gun
    /// </summary>
    internal class GunPart
    {
        private string _name; // The name of the gun part
        private string _description; // The description of the gun aprt

        private GunPartID _gunPartID; // The ID of what gun part it is
        private StatModifier[] _statModifiers; // The stat modifiers of the gun part

        /// <summary>
        /// Creates a Gun Part with a name, description, and modifiers
        /// </summary>
        /// <param name="name">The name of the gun part</param>
        /// <param name="description">The description of the gun part</param>
        /// <param name="gunPartID">The ID for what part it is</param>
        /// <param name="modifiers">The stat modifiers for the gun part</param>
        public GunPart(string name, string description, GunPartID gunPartID, params StatModifier[] modifiers)
        {
            _name = name;
            _description = description;
            _gunPartID = gunPartID;
            _statModifiers = modifiers;
        }
    }
}
