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
    public class WszystkieSposobyZaplatyViewModel : WszystkieViewModel<SposobZaplaty>
    {
        #region  Konstruktor
        public WszystkieSposobyZaplatyViewModel()
            : base("Wszystkie kategorie sprzedazy")
    {
    }
    #endregion
    public override void Load()
    {
        List = new ObservableCollection<SposobZaplaty>
        (
         //Zapytanie linQ (Obiektowa wersja SQL)
         from SposobZaplaty in FakturyEntities.SposobZaplaty // dla kazdego towaru w ..
         where SposobZaplaty.CzyAktywny == true
         select SposobZaplaty //wybierz wszystkie towary
         );
    }

}
}
