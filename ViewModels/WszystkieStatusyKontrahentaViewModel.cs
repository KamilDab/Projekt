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
    public class WszystkieStatusyKontrahentaViewModel : WszystkieViewModel<StatusKontrahenta>

    {
        #region  Konstruktor
        public WszystkieStatusyKontrahentaViewModel()
            : base("Statusy kontrahenta")
        {
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<StatusKontrahenta>
            (
             //Zapytanie linQ (Obiektowa wersja SQL)
             from StatusKontrahenta in FakturyEntities.StatusKontrahenta // dla kazdego towaru w ..
             where StatusKontrahenta.CzyAktywne == true
             select StatusKontrahenta //wybierz wszystkie towary
             );
        }

    }
}
