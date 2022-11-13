using Projekt.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Projekt.ViewModels
{
    // to jest klasa view model ktora dziala dla widoku MainWindow
    public class MainWindowViewModel : BaseViewModel
    {
        #region konstruktor
        public MainWindowViewModel()
        {

        }
        #endregion


        //będzie zawierała kolekcje komend, które pojawiają się w menu lewym oraz kolekcje zakładek 
        #region Komendy menu i paska narzedzi
        public ICommand NowyTowarCommand //ta komenda zostanie podpieta pod menu i pasek narzedzi
        {
            get
            {
                return new BaseCommand(() => createView(new NowyTowarViewModel()));//to jest komenda, która wyw. funkcję createTowar
            }
        }

        public ICommand TowaryCommand
        {
            get
            {
                return new BaseCommand(showAllTowar);
            }
        }
        public ICommand StatusyKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAllStstusKontrahenta);
            }
        }
        public ICommand KategoriaSprzedazyCommand
        {
            get
            {
                return new BaseCommand(showAllKategoriaSprzedazy);
            }
        }

        public ICommand NowaFakturaCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowaFakturaViewModel()));
            }
        }
        public ICommand FakturyCommand
        {
            get
            {
                return new BaseCommand(showAllFaktury);
            }
        }
        public ICommand NowyKontrahentCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyKontrachentViewModel()));
            }
        }
        public ICommand NowyAdresCommand
        { 
            get
            {
                return new BaseCommand(() => createView(new NowyAdresViewModel()));
            }
        }
        public ICommand NowyStatusKontrahenta
        {
            get
            {
                return new BaseCommand(() => createView(new NowyStatusKontrahentaViewModels()));
            }
        }
        public ICommand NowyRodzajKontrahentaCommand
        {
            get
            {
                return new BaseCommand(() => createView(new NowyRodzajKontrahentaViewModel()));
            }
        }
        public ICommand NowaKategoriaSprzedazy 
        {
            get
            {
                return new BaseCommand(() => createView(new NowaKategoriaSprzedazyViewModel()));
            }
        }
        public ICommand KontrahenciCommand
        {
            get
            {
                return new BaseCommand(showAllKontrachenci);
            }
        }

        public ICommand RodzajKontrahentaCommand
        {
            get
            {
                return new BaseCommand(showAllRodzajKontrahenta);
            }
        }
        public ICommand WszystkieAdresyCommand
        {
            get
            {
                return new BaseCommand(showAllAdresy);
            }
        }

        public ICommand WszystkieRodzajeFakturyCommand
        {
            get
            {
                return new BaseCommand(showAllRodzajeFaktury);
            }
        }

        public ICommand WszystkieSposobyZaplatyCommand
        {
            get
            {
                return new BaseCommand(showAllSposobyZaplaty);
            }
        }

        public ICommand WszystkiePrzyjeciaZewnetrzneCommand
        {
            get
            {
                return new BaseCommand(showAllPrzyjeciaZewnetrzne);
            }
        }

        public ICommand WszystkieWydaniaWewnetrzneCommand
        {
            get
            {
                return new BaseCommand(showAllWydaniaWewnetrzne);
            }
        }
        #endregion

        #region Przyciski w menu z lewej strony
        private ReadOnlyCollection<CommandViewModel> _Commands;//to jest kolekcja komend w emnu lewym
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)//sprawdzam czy przyciski z lewej strony menu nie zostały zainicjalizowane
                {
                    List<CommandViewModel> cmds = this.CreateCommands();//tworzę listę przyciskow za pomocą funkcji CreateCommands
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);//tę listę przypisuje do ReadOnlyCollection (bo readOnlyCollection można tylko tworzyć, nie można do niej dodawać)
                }
                return _Commands;
            }
        }
        private List<CommandViewModel> CreateCommands()//tu decydujemy jakie przyciski są w lewym menu
        {
            return new List<CommandViewModel>
                {
                    //new CommandViewModel("Towary",new BaseCommand(showAllTowar), "pack://application:,,,/Views/Content/Icons/package-variant-closed-white.png",
                    //    "pack://application:,,,/Views/Content/Icons/package-variant-closed.png"), //to tworzy pierwszy przycisk o nazwie Towary, który pokaże zakładkę wszystkie towary
                    //new CommandViewModel("Towar",new BaseCommand(()=>createView(new NowyTowarViewModel())), "pack://application:,,,/Views/Content/Icons/package-variant-closed-plus-white.png",
                    //    "pack://application:,,,/Views/Content/Icons/package-variant-closed-plus.png"),
                    new CommandViewModel("Faktura",new BaseCommand(()=>createView(new NowaFakturaViewModel())), "pack://application:,,,/Views/Content/Icons/Zamknij.png",
                        "pack://application:,,,/Views/Content/Icons/Zamknij.png"),
                    new CommandViewModel("Faktury",new BaseCommand(showAllFaktury), "pack://application:,,,/Views/Content/Icons/Zamknij.png",
                        "pack://application:,,,/Views/Content/Icons/Zamknij.png"),
                    new CommandViewModel("Kontrahent",new BaseCommand(()=>createView(new NowyKontrachentViewModel())), "pack://application:,,,/Views/Content/Icons/Zamknij.png",
                        "pack://application:,,,/Views/Content/Icons/Zamknij.png"),
                    new CommandViewModel("Kontraheci",new BaseCommand(showAllKontrachenci), "pack://application:,,,/Views/Content/Icons/Zamknij.png",
                        "pack://application:,,,/Views/Content/Icons/Zamknij.png"),
                };
        }
        #endregion

        #region Zakładki
        private ObservableCollection<WorkspaceViewModel> _Workspaces; //to jest kolekcja zakładek
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.onWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void onWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.onWorkspaceRequestClose;
        }
        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }
        #endregion

        #region Funkcje pomocnicze
        private void createView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.setActiveWorkspace(workspace);
        }
        private void showAllFaktury()
        {
            WszystkieFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel) as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
       
        private void showAllKategoriaSprzedazy()
        {
            WszystkieKategoriaSprzedazyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieKategoriaSprzedazyViewModel) as WszystkieKategoriaSprzedazyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieKategoriaSprzedazyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllKontrachenci()
        {
            WszyscyKontracheciViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszyscyKontracheciViewModel) as WszyscyKontracheciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKontracheciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);

        }
        private void showAllRodzajKontrahenta()
        {
            RodzajKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is RodzajKontrahentaViewModel) as RodzajKontrahentaViewModel;
            if(workspace == null)
            {
                workspace = new RodzajKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllAdresy()
        {
            WszystkieAdresyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)as WszystkieAdresyViewModel;
            if(workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        
             private void showAllStstusKontrahenta()
        {
            WszystkieStatusyKontrahentaViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyKontrahentaViewModel) as WszystkieStatusyKontrahentaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyKontrahentaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }

        private void showAllRodzajeFaktury()
        {
           WszystkieRodzajeFakturyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeFakturyViewModel) as WszystkieRodzajeFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllSposobyZaplaty()
        {
            WszystkieSposobyZaplatyViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieSposobyZaplatyViewModel) as WszystkieSposobyZaplatyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSposobyZaplatyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllPrzyjeciaZewnetrzne()
        {
            WszystkiePrzyjeciaWewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkiePrzyjeciaWewnetrzneViewModel) as WszystkiePrzyjeciaWewnetrzneViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePrzyjeciaWewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        private void showAllWydaniaWewnetrzne()
        {
            WszytskieWydaniaWewnetrzneViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszytskieWydaniaWewnetrzneViewModel) as WszytskieWydaniaWewnetrzneViewModel;
            if (workspace == null)
            {
                workspace = new WszytskieWydaniaWewnetrzneViewModel();
                this.Workspaces.Add(workspace);
            }
            this.setActiveWorkspace(workspace);
        }
        //to jest funkcja, która otwiera nową zakładke Towar
        //za każdym tworzy nową NOWĄ zakładkę do dodawania towaru

        //private void createTowar()
        //{
        //    //tworzy zakładke NowyTowar (VM)
        //    NowyTowarViewModel workspace = new NowyTowarViewModel();
        //    //dodajmy ją do kolkcji aktywnych zakładek
        //    this.Workspaces.Add(workspace);
        //    this.setActiveWorkspace(workspace);
        //}

        //to jest funkcja, która otwiera zakładke ze wszystkimi towarami
        //za każdym razem sprawdza czy zakladka z towarami jest juz otwarta, jak jest to ja aktywuje, ajk nie ma to tworzy
        private void showAllTowar()
        {
            //szukamy w kolekcji zakladek takiej zakladki ktora jest wszystkimi towarami
            WszystkieTowaryViewModel workspace = this.Workspaces.FirstOrDefault(vm => vm is WszystkieTowaryViewModel) as WszystkieTowaryViewModel;
            //jezeli takiej zakladki nie ma ta ja tworzymy
            if (workspace == null)
            {
                //tworzymy nowa zakladke Wszystkie towary
                workspace = new WszystkieTowaryViewModel();
                //i dodajemy ja do kolekcji zakladek
                this.Workspaces.Add(workspace);
            }
            //aktywujemy zakladke
            this.setActiveWorkspace(workspace);
        }
        private void setActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        #endregion



    }
}



