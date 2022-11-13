using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class NowaKategoriaSprzedazyViewModel : JedenViewModel<KategoriaSprzedazy>
    {
        #region Konstruktor
        public NowaKategoriaSprzedazyViewModel()
            : base("Nowy kategoria sprzedazy")
        {
            Item = new KategoriaSprzedazy(); // pusty adres creat
        }
        #endregion
        #region Propertis
        public string Opis
        {
            get
            {
                return Item.Opis;
            }
            set
            {
                if (value != Item.Opis)
                {
                    Item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }

        public string Rodzaj
        {
            get
            {
                return Item.Rodzaj;
            }
            set
            {
                if (value != Item.Rodzaj)
                {
                    Item.Rodzaj = value;
                    base.OnPropertyChanged(() => Rodzaj);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            //dodajemy towar do lokalnej kolkcji
            Db.KategoriaSprzedazy.AddObject(Item);
            //zapisujemy zmiany w bazie danych
            Db.SaveChanges();
        }
        #endregion
    }
}
