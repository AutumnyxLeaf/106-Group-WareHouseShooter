using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Right_to_Return_Arms.GunClasses
{
    /// <summary>
    /// A class representing a generic part that gives a small gun upgrade
    /// </summary>
    internal class GenericGunUpgrade
    {
        private string _name;
        private string _description;
        private StatModifier _statModifier;
        
        /// <summary>
        /// Creates a Generic Gun Part
        /// </summary>
        /// <param name="name">Name of the Part</param>
        /// <param name="description">The Explanation of the Part</param>
        /// <param name="statModifier">The Stat Modifier</param>
        public GenericGunUpgrade(string name, string description, StatModifier statModifier)
        {
            _name = name;
            _description = description;
            _statModifier = statModifier;
        }

        public override string ToString()
        {
            string toString = "";

            toString = $"{_name}, {_description}\n";
            toString += "\t" + _statModifier.ToString();

            return toString;
        }
    }
}
