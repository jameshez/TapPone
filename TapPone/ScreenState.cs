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

        public ScreenState()
        {
            total_monster_hp = 250;
            left_monster_hp = 250;
            attack = 20;
            level = 1;
            imageUri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png");
            monster_name = imageUri.ToString();
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
            //throw new NotImplementedException();
            level++;
            attack += 20;
        }

        private void UpdateImageCommand_Executed()
        {
            left_monster_hp -= attack;

            if (_left_monster_hp <= 0)
            {
                imageUri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png");
                monster_name = imageUri.ToString();
                total_monster_hp += 40;
                left_monster_hp = total_monster_hp;
            }
            NotifyPropertyChanged("monster_left_percentage");
        }

        private void userTap()
        {
            //System.Reflection.Emit
        }


        //monster image 
        private Uri _imageUri;
        public Uri imageUri
        {
            get
            {
                return _imageUri;
            }
            set
            {
                _imageUri = value;
                NotifyPropertyChanged("imageUri");
            }
        }

        
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
