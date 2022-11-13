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
    public class WszystkieRodzajeFakturyViewModel : WszystkieViewModel<RodzajFaktury>
    {
        #region  Konstruktor
        public WszystkieRodzajeFakturyViewModel()
            : base("Wszystkie rodzaje faktury")
    {
    }
    #endregion
    public override void Load()
    {
        List = new ObservableCollection<RodzajFaktury>
        (
         //Zapytanie linQ (Obiektowa wersja SQL)
         from RodzajFaktury in FakturyEntities.RodzajFaktury // dla kazdego towaru w ..
         where RodzajFaktury.CzyAktywny == true
         select RodzajFaktury //wybierz wszystkie towary
         );
    }

}
}
