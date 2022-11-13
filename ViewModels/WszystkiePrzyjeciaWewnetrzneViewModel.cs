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
    public class WszystkiePrzyjeciaWewnetrzneViewModel : WszystkieViewModel<PrzyjecieZewnetrzne>
    {
        #region  Konstruktor
        public WszystkiePrzyjeciaWewnetrzneViewModel()
            : base("Wszystkie przyjecia zewnetrzne")
        {
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<PrzyjecieZewnetrzne>
            (
             //Zapytanie linQ (Obiektowa wersja SQL)
             from PrzyjecieZewnetrzne in FakturyEntities.PrzyjecieZewnetrzne // dla kazdego towaru w ..
             where PrzyjecieZewnetrzne.CzyAktywny == true
             select PrzyjecieZewnetrzne //wybierz wszystkie towary
             );
        }

    }
}
