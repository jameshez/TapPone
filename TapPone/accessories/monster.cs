using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapPone
{
    public class monster : item
    {
        private double _total_monster_hp;
        public double total_monster_hp
        {
            get
            {
                return _total_monster_hp;
            }
            set
            {
                _total_monster_hp = value;
            }
        }

        private double _left_monster_hp;
        public double left_monster_hp
        {
            get
            {
                return _left_monster_hp;
            }
            set
            {
                _left_monster_hp = value;
            }
        }

    }
}
