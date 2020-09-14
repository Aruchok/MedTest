using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        public Result()
        {
            InitializeComponent();
            Res();
        }
        public void GoBack(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new StartPage());
        }
        public void Res()
        {
            int[] resultD = { 0, 0 };
            int j = 4;
            int i = 1;
            Desiase des = new Desiase();
            Symptoms sym = new Symptoms();

            while (i < 4)
            {
                sym = App.Database.GetItem(i);
                resultD[0] += sym.Uverennost;
                i++;
            }

            while (j < 7)
            {
                sym = App.Database.GetItem(j);
                resultD[1] += sym.Uverennost;
                j++;
            }

            resultD[0] = resultD[0] / 3; 
            resultD[1] = resultD[1] / 3;

            des = App.Database.GetItemD(1);           
            ResultLabel_1.Text = "With a " + resultD[0] + "% chance you have " + des.Diagnoz_one;

            des = App.Database.GetItemD(2);
            ResultLabel_2.Text = "With a " + resultD[1] + "% chance you have " + des.Diagnoz_one;
        }
    }
}