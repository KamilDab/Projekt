using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class RodzajKontrahentaViewModel : WszystkieViewModel<Rodzaj>
    {
        #region Konstruktor
        public RodzajKontrahentaViewModel()
            : base("Rodzaj kontrahenta")
        {
        }
        public override void Load()
        {
            List = new ObservableCollection<Rodzaj>
              (
               //Zapytanie linQ (Obiektowa wersja SQL)
               from rodzaj in FakturyEntities.Rodzaj // dla kazdego towaru w ..
               where rodzaj.CzyAktywny == true
               select rodzaj //wybierz wszystkie towary
               );
        }
        #endregion
    }
}
    