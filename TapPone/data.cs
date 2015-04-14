using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapPone
{
    /// <summary>
    ///  All variable/property inits here.
    ///  James He
    /// </summary>
    public partial class ScreenState
    {

        public double _total_monster_hp { get; set; }
        public double _left_monster_hp { get; set; }
        public double monster_left_percentage
        {
            get
            {
                return _left_monster_hp / _total_monster_hp * 250;
            }
        }
        public string monster_name { get; set; }
    }
}
