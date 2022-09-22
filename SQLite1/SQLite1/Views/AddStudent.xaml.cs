using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite1.Model;

namespace SQLite1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudent : ContentPage
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var item = (Student)BindingContext;

                //Agregar un nuevo registro
                //hacer llamado a la base de datos local
                await App.dao.SaveStudent(item);

                //mensajes de confirmacion
                await DisplayAlert("Exito", "Datos registrados en la base de datos", "De Acuerdo");

                //Abro la navegacion
                await Navigation.PopAsync();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Cerrar", ex.Message, "Cerar");
            }
        }
    }
}