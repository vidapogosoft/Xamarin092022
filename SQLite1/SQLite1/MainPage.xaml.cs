using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SQLite1.Views;
using SQLite1.Model;

namespace SQLite1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var Toolbaritem = new ToolbarItem
            {
                Text = "Nuevo (+)"
            };

            Toolbaritem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new AddStudent()
                {
                    BindingContext = new Student()
                });
            };

            ToolbarItems.Add(Toolbaritem);

        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                StdList.ItemsSource = await App.dao.GetStudents();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Cerrar", ex.Message, "Cerar");
            }

            
        }

        private async void StdList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new EditStudent()
                {
                    BindingContext = e.SelectedItem as Student
                });
            }
        }
    }
}
