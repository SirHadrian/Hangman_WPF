using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hangman.ViewModel;

namespace Hangman.View
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class view : Window
    {
        view_model viewModel = new view_model();

        string temp = "";

        public view()
        {
            InitializeComponent();



            viewModel.ListaCuvinte = viewModel.ListaRauri.Concat(viewModel.ListaOrase).ToList();

            Random random = new Random();
            int index = random.Next(viewModel.ListaCuvinte.Count);

            //viewModel.cuvant = viewModel.ListaCuvinte[index];

            temp = viewModel.ListaCuvinte[index];

            viewModel.cuvant = temp;


            for (int i = 0; i < viewModel.cuvant.Length; i++)
            {
                viewModel.cuvantCurent = viewModel.cuvantCurent + "_";
            }
            displayCuvantCurent(viewModel.cuvantCurent.ToCharArray());



            Hangman_Image.Source = BitmapToImageSource(viewModel.image);
            //TEST.Content = viewModel.wrongs;
            TEST_Copy.Content = viewModel.maxWrongs;

            this.DataContext = viewModel;
        }

        private void Cuvant_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        

            Button test = sender as Button;
            string temp = test.Content.ToString();

            char[] tempCuvant = viewModel.cuvantCurent.ToCharArray();




            for (int i = 0; i < viewModel.cuvant.Length; i++)
            {
                if (viewModel.cuvant[i] == temp[0])
                {
                    tempCuvant[i] = temp[0];
                    viewModel.gresit = true;
                }
            
            }

            if (!viewModel.gresit)
            {
                viewModel.wrongs++;
                viewModel.listaLitere += temp[0] + " ";
            }

                displayCuvantCurent(tempCuvant);
            test.IsEnabled = false;
            viewModel.gresit = false;
            TEST.Content = viewModel.wrongs;
            Hangman_Image.Source = BitmapToImageSource(viewModel.image);



            if (viewModel.wrongs >= viewModel.maxWrongs)
            {
                Game.Content = "You lose";
                return;
            }

            if (viewModel.cuvantCurent == viewModel.cuvant)
            {
                Game.Content = "You win";
                return;
            }
            
        }
        public BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void displayCuvantCurent(char[] e)
        {
            string temp = "";

            for (int i = 0; i < e.Length; i++)
            {
                temp += e[i] + " ";
            }

            viewModel.cuvantCurent = new string(e);
            Cuvant_TextBox.Text = temp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
