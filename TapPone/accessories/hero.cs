using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapPone
{
    public class hero : item
    {
        private long _attack;
        public long attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = value;
            }
        }
        private long _level;
        public long level
        {
            get
            {
                return _level;
            }
            set
            {
                if (_level != value)
                {
                    _level = value;
                    attack += 20;
                }
            }
        }
        
        public bool levelUpEnable
        {
            get
            {
                if (gold >= level * 10)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
