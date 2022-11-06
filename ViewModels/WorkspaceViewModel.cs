using Projekt.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    //to jest klasa z ktorej beda dziedziczyc wszystkie view modele zakladaek
    public class WorkspaceViewModel : BaseViewModel
    {
        #region Pola i komendy
        public string DisplayName { get; set; } // nazwa zakladki
        private BaseCommand _CloseCommand; //to jest komenda do obsługi zamykania okna
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => this.OnRequestClose()); //ta komenda wyoła funkcje zamykającą zakładkę 
                return _CloseCommand;
            }
        }
        #endregion
        #region RequestClose [event]
        public event EventHandler RequestClose;
        public void OnRequestClose()
        {
            EventHandler handler = this.RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
        
    }
}
