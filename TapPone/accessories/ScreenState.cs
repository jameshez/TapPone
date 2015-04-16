using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TapPone
{
    /// <summary>
    /// let's do it next version by using MVVM
    /// </summary>
    public partial class ScreenState : INotifyPropertyChanged
    {
        Random random = new Random();
        private int _count = 1;

        private monster _monster;
        public monster monster
        {
            get
            {
                return _monster;
            }
            set
            {
                _monster = value;
                NotifyPropertyChanged("monster");
            }
        }

        private hero _hero;
        public hero hero
        {
            get
            {
                return _hero;
            }
            set
            {
                _hero = value;
                NotifyPropertyChanged("hero");
            }
        }

        private Uri _monsterImage;
        public Uri monsterImage
        {
            get
            {
                return _monsterImage;
            }
            set
            {
                _monsterImage = value;
                NotifyPropertyChanged("monsterImage");
            }
        }
 



        public ScreenState()
        {
            monster = new monster()
            {
                total_monster_hp = 250,
                left_monster_hp = 250,
                gold = 1,
                imageUri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png"),
                name = "怪物小兵" + _count,
            };

            hero = new hero()
            {
                attack = 20,
                level = 1,
                gold = 0,
            };

            monsterImage = monster.imageUri;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public ICommand UpdateImageCommand
        {
            get
            {
                return new DelegateCommand(this.UpdateImageCommand_Executed);
            }
        }

        public ICommand levelUpCommand
        {
            get
            {
                return new DelegateCommand(this.levelUpCommand_Executed);
            }
        }

        private void levelUpCommand_Executed()
        {
            
            hero.attack += 20;
            hero.gold -= hero.level * 10;
            hero.level++;
            NotifyPropertyChanged("hero");
        }

        private void UpdateImageCommand_Executed()
        {
            monster.left_monster_hp -= hero.attack;

            //level up
            if (monster.left_monster_hp <= 0)
            {
                _count++;
                hero.gold += monster.gold;

                if (_count % 10 != 0)
                {
                    monster.imageUri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 13) + ".png");
                    monster.name = "怪物小兵" + _count;
                    if (_count % 10 == 1)
                    {
                        monster.total_monster_hp -= 200;
                        monster.gold = (int)(_count / 10) + 1;
                    }
                    monster.total_monster_hp += 20;
                }
                else
                {
                    monster.imageUri = new Uri("ms-appx:///images/monsters/13.png");
                    monster.name = "怪物Boss";
                    monster.total_monster_hp += 220;
                    monster.gold = _count;
                }

                monster.left_monster_hp = monster.total_monster_hp;
                
                monsterImage = monster.imageUri;
                NotifyPropertyChanged("monsterImage");
                
            }
            NotifyPropertyChanged("monster");
            NotifyPropertyChanged("hero");
            
        }

        private void userTap()
        {
            //System.Reflection.Emit
        }


        //monster image 
        

        
    }




    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;

        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute();
            }
        }
    }
}
