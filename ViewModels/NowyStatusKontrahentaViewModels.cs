using Projekt.Model;
using Projekt.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.ViewModels
{
    public class NowyStatusKontrahentaViewModels : JedenViewModel<StatusKontrahenta>
    {
        #region Konstruktor
        public NowyStatusKontrahentaViewModels()
            : base("Nowy adres")
        {
            Item = new StatusKontrahenta(); 
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

        public string Status
        {
            get
            {
                return Item.Status;
            }
            set
            {
                if (value != Item.Status)
                {
                    Item.Status = value;
                    base.OnPropertyChanged(() => Status);
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
        #endregion

        #region Save
        public override void Save()
        {
            Item.CzyAktywne = true;
            //dodajemy towar do lokalnej kolkcji
            Db.StatusKontrahenta.AddObject(Item);
            //zapisujemy zmiany w bazie danych
            Db.SaveChanges();
        }
        #endregion

    }
}
