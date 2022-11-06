using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class NowyAdresViewModel : JedenViewModel<Adres>
    {
        #region Konstruktor
        public NowyAdresViewModel()
            : base("Nowy adres")
        {
            Item = new Adres(); // pusty adres creat
        }
        #endregion
        #region Propertis
        public string KodPocztowy
        {
            get
            {
                return Item.KodPocztowy;
            }
            set
            {
                if (value != Item.KodPocztowy)
                {
                    Item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }

        public string Kraj
        {
            get
            {
                return Item.Kraj;
            }
            set
            {
                if (value != Item.Kraj)
                {
                    Item.Kraj = value;
                    base.OnPropertyChanged(() => Kraj);
                }
            }
        }

        public string Miasto
        {
            get
            {
                return Item.Miasto;
            }
            set
            {
                if (value != Item.Miasto)
                {
                    Item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return Item.Ulica;
            }
            set
            {
                if (value != Item.Ulica)
                {
                    Item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NrDomu
        {
            get
            {
                return Item.NrDomu;
            }
            set
            {
                if (value != Item.NrDomu)
                {
                    Item.NrDomu = value;
                    base.OnPropertyChanged(() => NrDomu);
                }
            }
        }
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            //dodajemy towar do lokalnej kolkcji
            Db.Adres.AddObject(Item);
            //zapisujemy zmiany w bazie danych
            Db.SaveChanges();
        }
        #endregion
    }
}
