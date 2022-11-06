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
    public class WszystkieAdresyViewModel :WszystkieViewModel<Adres>

    {
        #region  Konstruktor
        public WszystkieAdresyViewModel()
            : base("Adresy")
        {  
        }
        #endregion
        public override void Load()
        {
            List = new ObservableCollection<Adres>
            (
             //Zapytanie linQ (Obiektowa wersja SQL)
             from adres in FakturyEntities.Adres // dla kazdego towaru w ..
             where adres.CzyAktywna == true
             select adres //wybierz wszystkie towary
             );
        }
       
    }
}
