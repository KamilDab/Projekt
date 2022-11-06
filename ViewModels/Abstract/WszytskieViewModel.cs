using Projekt.Helper;
using Projekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.ViewModels.Abstract
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel // bo wszystkie zakladki dziedzicza po WokrspaceViewModel
    {
        #region Fields
        //to jest obiekt ktory bedzie sluzyl do operacji na bazie danych
        private readonly ProjektPDABEntities fakturyEntities;
        public ProjektPDABEntities FakturyEntities
        {
            get
            {
                return fakturyEntities;
            }
        }
        //to jest komenda do zaladowania towarow
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());//pusta komenda wywoluje load()
                }
                return _LoadCommand;
            }
        }
        //w tym obiekcie beda wszystkie towary
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) //jak lista jest pusta to wywola load()
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        #endregion

        #region Konstruktor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;//tu ustawiamy nazwę zakładki
            this.fakturyEntities = new ProjektPDABEntities();
        }
        #endregion

        #region Helpers
        public abstract void Load();

        #endregion
    }
}
