using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace Hangman.Model
{
    class model
    {
        public Bitmap[] img = { Properties.Resources.HangMan_1, Properties.Resources.HangMan_2, Properties.Resources.HangMan_3,
        Properties.Resources.HangMan_4, Properties.Resources.HangMan_5, Properties.Resources.HangMan_6,
        Properties.Resources.HangMan_7, Properties.Resources.HangMan_8};
        

        public string cuvant = "ABBCD";
        public string cuvantCurent = "";
        public string listaLitere = "";

        public bool gresit;

        public int maxWrongs = 7;
        public int wrongs = 0;

        public List<string> ListaRauri = new List<string>();
        public List<string> ListaOrase = new List<string>();

        public List<string> ListaCuvinte = new List<string>();
        

        
    }
}

