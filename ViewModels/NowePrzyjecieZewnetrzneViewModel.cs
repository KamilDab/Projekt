using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class NowePrzyjecieZewnetrzneViewModel : JedenViewModel<PrzyjecieZewnetrzne>
    {
        #region Konstruktor
        public NowePrzyjecieZewnetrzneViewModel()
            : base("Nowe przyjecie zewnetrzne")
        {
            Item = new PrzyjecieZewnetrzne(); // pusty adres creat
        }
        #endregion
        #region Propertis
        public string Nazwa
        {
            get
            {
                return Item.Nazwa;
            }
            set
            {
                if (value != Item.Nazwa)
                {
                    Item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
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

        public DateTime? Data
        {
            get
            {
                return Item.Data;
            }
            set
            {
                if (value != Item.Data)
                {
                    Item.Data = value;
                    base.OnPropertyChanged(() => Data);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywny = true;
            //dodajemy towar do lokalnej kolkcji
            Db.PrzyjecieZewnetrzne.AddObject(Item);
            //zapisujemy zmiany w bazie danych
            Db.SaveChanges();
        }
        #endregion
    }
}
