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
                NotifyPropertyChanged("attack");
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
                NotifyPropertyChanged("level");
            }
        }
    }
}
