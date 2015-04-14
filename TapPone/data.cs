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
                NotifyPropertyChanged("total_monster_hp");
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
                NotifyPropertyChanged("left_monster_hp");
            }
        }
        public double monster_left_percentage
        {
            get
            {
                return _left_monster_hp / _total_monster_hp * 250;
            }
        }
        private string _monster_name;
        public string monster_name
        {
            get
            {
                return _monster_name;
            }
            set
            {
                _monster_name = value;
                NotifyPropertyChanged("monster_name");
            }
        }
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
