using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Projekt.ViewModels
{
   public class WszytskieWydaniaWewnetrzneViewModel : WszystkieViewModel<WydanieWewnetrzne>
    {
        #region  Konstruktor
        public WszytskieWydaniaWewnetrzneViewModel()
            : base("Wszystkie wydania wewnetrzne")
        {
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<WydanieWewnetrzne>
            (
             //Zapytanie linQ (Obiektowa wersja SQL)
             from WydanieWewnetrzne in FakturyEntities.WydanieWewnetrzne // dla kazdego towaru w ..
             where WydanieWewnetrzne.CzyAktywny == true
             select WydanieWewnetrzne //wybierz wszystkie towary
             );
        }

    }
}
