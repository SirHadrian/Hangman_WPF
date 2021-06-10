using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hangman.Model;

namespace Hangman.ViewModel
{
    class view_model: INotifyPropertyChanged
    {
        model Model = new model();

        public view_model()
        {
            loadOrase();
            loadRauri();
        }


        private ICommand _buttonCategory;
        public ICommand ButtonCategory
        {
            get
            {
                return _buttonCategory ?? (_buttonCategory = new RelayCommand(() => ButtonPressed(), () => CanExecute));
            }
        }

        public bool CanExecute
        {
            get
            {
                return true;
            }
        }

        private void ButtonPressed()
        {
            throw new NotImplementedException();
        }

        public string cuvant 
        {
            get
            {
                return Model.cuvant;
            }
            set
            {
                Model.cuvant = value;
                OnPropertyChanged("cuvant");
            }
        }

        public List<string> ListaOrase 
        {
            get
            {
                return Model.ListaOrase;
            }
            set 
            {
                Model.ListaOrase = value;
                OnPropertyChanged("ListaOrase");
            }
        }

        public void loadOrase()
        {
            StreamReader sr2 = new StreamReader("../../Model/Orase.txt");

            while (!sr2.EndOfStream)
            {
                ListaOrase.Add(sr2.ReadLine());
            }
        }

        public List<string> ListaRauri
        {
            get
            {
                return Model.ListaRauri;
            }
            set 
            {
                Model.ListaRauri = value;
                OnPropertyChanged("ListaRauri");
            }
        }

        public void loadRauri()
        {
            StreamReader sr1 = new StreamReader("../../Model/Rauri.txt");

            while (!sr1.EndOfStream)
            {
                ListaRauri.Add(sr1.ReadLine());
            }
        }

        public List<string> ListaCuvinte
        {
            get
            {
                return Model.ListaCuvinte;
            }
            set
            {
                Model.ListaCuvinte = value;
                OnPropertyChanged("ListaCuvinte");
            }
        }


        public Bitmap image
        {
            get
            {
                return Model.img[wrongs];
            }
            set { }
        }

        public int wrongs
        {
            get
            {
                return Model.wrongs;
            }

            set
            {
                Model.wrongs = value;
                OnPropertyChanged("wrongs");
            }
        }

        public string listaLitere
        {
            get
            {
                return Model.listaLitere;
            }

            set
            {
                Model.listaLitere = value;
                OnPropertyChanged("listaLitere");
            }
        }

        public int maxWrongs
        {
            get
            {
                return Model.maxWrongs;
            }

            set
            {
                Model.maxWrongs = value;
                OnPropertyChanged("maxWrongs");
            }
        }

        public string cuvantCurent
        {
            get
            {
                return Model.cuvantCurent;
            }
            set
            {
                Model.cuvantCurent = value;
                OnPropertyChanged("cuvantCurent");
            }
        }

        public bool gresit
        {
            get
            {
                return Model.gresit;
            }
            set
            {
                Model.gresit = value;
                OnPropertyChanged("gresit");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
