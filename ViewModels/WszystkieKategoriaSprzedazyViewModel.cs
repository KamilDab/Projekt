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
    public class WszystkieKategoriaSprzedazyViewModel : WszystkieViewModel<KategoriaSprzedazy>
    {
        #region  Konstruktor
        public WszystkieKategoriaSprzedazyViewModel()
            : base("Wszystkie kategorie sprzedazy")
        {
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<KategoriaSprzedazy>
            (
             //Zapytanie linQ (Obiektowa wersja SQL)
             from KategoriaSprzedazy in FakturyEntities.KategoriaSprzedazy // dla kazdego towaru w ..
             where KategoriaSprzedazy.CzyAktywny == true
             select KategoriaSprzedazy //wybierz wszystkie towary
             );
        }

    }
}

