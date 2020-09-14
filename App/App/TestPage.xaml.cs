using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage 
    {
        int i = 1;
        public TestPage()
        {
            InitializeComponent();
            DisableAnswer();
            Symptoms symp = new Symptoms();
            symp = App.Database.GetItem(1);
            Question.Text = "How much do you feel " + symp.Symptom + "?";
            //Question.Text = mas[i];
            i++;
        }

        string[] mas = { "Question number One?", "Question number Two?", "Question number Three?", "Question number Four?", "Question number Five?" };
        int[] arrAnswer = new int[4];
 
        async void Answer(object sender, EventArgs e)
        {
            Symptoms symp = new Symptoms();
            symp = App.Database.GetItem(i - 1);
            App.database.SaveItem(CheckChooseAnswer(symp));
            //Symptoms selectSymptom = new Symptoms();
            //Question.Text = selectSymptom.ToString();

            //Symptoms selectedSymptom = (Symptoms)e.SelectedItem;
            //Question.Text = selectedSymptom.ToString();

            //Конец вопросов, переход на страницу результатов
            //if (i == 4)
            //{
            //    await Navigation.PushModalAsync(new Result());
            //}
            //else
            //{
            //    Question.Text = mas[i];
            //    arrAnswer[i] = CheckChooseAnswer();
            //}
            symp = App.Database.GetItem(i);
            if (symp.idSymptom == 7)
            {
                await Navigation.PushModalAsync(new Result());
            }
            else
            {
                Question.Text = "How much do you feel " + symp.Symptom + "?";
            }

            i++;
            RadioNull();
            DisableAnswer();
        }

        public void ChooseAnswer(object sender, EventArgs args)
        {
            NameAnswer.IsEnabled = true;
        }


        //Отключение таргета со всех ответов
        public void RadioNull()
        {
            Radio1.IsChecked = false;
            Radio2.IsChecked = false;
            Radio3.IsChecked = false;
            Radio4.IsChecked = false;
            Radio5.IsChecked = false;
        }


        //Для базы данных
        public Symptoms CheckChooseAnswer(Symptoms item)
        {
            if (Radio1.IsChecked == true)
            {
                item.Uverennost = 0;
                return item;
            }
            else if (Radio2.IsChecked == true)
            {
                item.Uverennost = 25;
                return item;
            }
            else if (Radio3.IsChecked == true)
            {
                item.Uverennost = 50;
                return item;
            }
            else if (Radio4.IsChecked == true)
            {
                item.Uverennost = 75;
                return item;
            }
            else
            {
                item.Uverennost = 100;
                return item;
            }
        }

        //Если ни один вариант не выбран, кнопка ответа недоступна
        public void DisableAnswer()
        {
            if (Radio1.IsChecked == false &&
                Radio2.IsChecked == false &&
                Radio3.IsChecked == false &&
                Radio4.IsChecked == false &&
                Radio5.IsChecked == false)
            {
                NameAnswer.IsEnabled = false;
            }
        }
    }
}