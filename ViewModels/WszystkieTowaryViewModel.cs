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
    public class WszystkieTowaryViewModel : WszystkieViewModel<Towar>
    {
        #region Konstruktor
        public WszystkieTowaryViewModel()
            : base("Towary")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Towar>
                (
                //Zapytanie linQ (Obiektowa wersja SQL)
                from towar in FakturyEntities.Towar // dla kazdego towaru w ..
                where towar.CzyAktywna == true
                select towar //wybierz wszystkie towary
                );
        }
        #endregion
    }
}
