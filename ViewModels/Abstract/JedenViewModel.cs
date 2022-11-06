using Projekt.Helper;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels.Abstract
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        public ProjektPDABEntities Db { get; set; }
        public T Item { get; set; }
        #endregion

        #region Konstruktor
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName;//tu ustawiamy nazwę zakładki
            Db = new ProjektPDABEntities();
        }
        #endregion




        #region Command
        //to jest komendka ktora zostanie podpieta (zbidowana) z pryskiem zapisz i zamknij ,komenda ta wywola 
        // funkcje saveAndClose
        private BaseCommand _SaveAndCloseCommand;
        public ICommand SveAndCLoseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => SaveAndClose());
                }
                return _SaveAndCloseCommand;
            }
        }
        #endregion

        #region Save
        public abstract void Save();

        private void SaveAndClose()
        {
            //zapisuje towar
            Save();
            //zamyka zakladke
            base.OnRequestClose();
        }
        #endregion
    }
}
