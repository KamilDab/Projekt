using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class NowyTowarViewModel : JedenViewModel<Towar>
    {
        #region Konstruktor
        public NowyTowarViewModel()
            : base("Towar")
        {
            Item = new Towar(); // pusty towar creat
        }
        #endregion


        #region Propertis
        //dla kazdego pola edytowanego na interfejscie tworzymy propertisa
        //te propertisy bedziemy podlacza (bindowac)
        public string Kod
        {
            get
            {
                return Item.Kod;
            }
            set
            {
                if (value != Item.Kod)
                {
                    Item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
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

        public decimal? Cena
        {
            get
            {
                return Item.Cena;
            }
            set
            {
                if (value != Item.Cena)
                {
                    Item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        public decimal? Marza
        {
            get
            {
                return Item.Marza;
            }
            set
            {
                if (value != Item.Marza)
                {
                    Item.Marza = value;
                    base.OnPropertyChanged(() => Marza);
                }
            }
        }      
        public decimal? CenaVatZakupu
        {
            get
            {
                return Item.CenaVatZakupu;
            }
            set
            {
                if (value != Item.CenaVatZakupu)
                {
                    Item.CenaVatZakupu = value;
                    base.OnPropertyChanged(() => CenaVatZakupu);
                }
            }
        }
        public decimal? CenaVatSprzedazy
        {
            get
            {
                return Item.CenaVatSprzedazy;
            }
            set
            {
                if (value != Item.CenaVatSprzedazy)
                {
                    Item.CenaVatSprzedazy = value;
                    base.OnPropertyChanged(() => CenaVatSprzedazy);
                }
            }
        }   
        public decimal Ilosc_minimalna
        {
            get
            {
                return Item.Ilosc_minimalna;
            }
            set
            {
                if (value != Item.Ilosc_minimalna)
                {
                    Item.Ilosc_minimalna = value;
                    base.OnPropertyChanged(() => Ilosc_minimalna);
                }
            }
        }  
            public string Jm
        {
            get
            {
                return Item.Jm;
            }
            set
            {
                if (value != Item.Jm)
                {
                    Item.Jm = value;
                    base.OnPropertyChanged(() => Jm);
                }
            }
        }
        #endregion



        #region Save
        public override void Save()
        {
            Item.CzyAktywna = true;
            //dodajemy towar do lokalnej kolkcji
            Db.Towar.AddObject(Item);
            //zapisujemy zmiany w bazie danych
            Db.SaveChanges();
        }
        #endregion
    }
}
