using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DecisionMaker
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> decisionList = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();
            itemList.ItemsSource = decisionList;
        }

        private void btn_AddItem_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(itemName.Text))
            { 
                decisionList.Add(itemName.Text);
                itemName.Text = "";
            }

        }

        private async void btn_Decision_Clicked(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int currItems = decisionList.Count();

            int choice = rnd.Next(0, currItems);


            if (decisionList.Count < 1)
            {
                ViewExtensions.CancelAnimations(btn_Decision);

                decWarning.Opacity = 1;
                decWarning.Text = "Not enough options";

                await btn_Decision.TranslateTo(-3, 0, 25);
                await btn_Decision.TranslateTo(6, 0, 50);
                await btn_Decision.TranslateTo(-6, 0, 50);
                await btn_Decision.TranslateTo(3, 0, 25);

                await Task.Delay(500);
                await decWarning.FadeTo(0, 500);
                decWarning.Text = "";
            }
            else
            {
                await DisplayAlert("The Decision", decisionList.ElementAt(choice) + " has been decided", "OK");
            }
                
        }

        private void btn_clearItems_Clicked(object sender, EventArgs e)
        {
            decisionList.Clear();
        }
    }
}
