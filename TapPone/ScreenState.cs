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
    class ScreenState : INotifyPropertyChanged
    {
        Random random = new Random();
        //monster image 
        private Uri _imageUri;
        public double total_monster_hp { get; set; }
        public double left_monster_hp { get; set; }

        public ScreenState()
        {
            total_monster_hp = 250;
            left_monster_hp = 250;
            _imageUri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png");
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

        private void UpdateImageCommand_Executed()
        {
            imageUri = new Uri("ms-appx:///images/monsters/" + random.Next(1, 14) + ".png");
            left_monster_hp -= 10;
            //NotifyPropertyChanged("imageUri");
            NotifyPropertyChanged("left_monster_hp");
        }

        private void userTap()
        {

        }

        

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
