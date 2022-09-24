using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite1.Model;
using SQLite1.DTO;

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

            }
            catch (Exception ex)
            {
                await DisplayAlert("Cerrar", ex.Message, "Cerar");
            }
        }

        private async void BtnSincronizar_Clicked(object sender, EventArgs e)
        {
            int grabado = 0;

            var datos = (Student)BindingContext;

            try
            {
                // Agregar un nuevo registro
                //hacer llamado de api rest post

                var item = new DTORegistrado
                {
                    Identificacion = datos.stdlevel,
                    Apellidos = datos.stdname,
                    Nombres = datos.stdcourse,
                };

                grabado = await App.Manager.SaveRegistro(item, true);

                if (grabado == 1)
                {
                    //mensajes de confirmacion
                    await DisplayAlert("Registro", "Tus dastos sincronizados con exito.", "De Acuerdo");

                    await Navigation.PopAsync();
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Cerrar", ex.Message, "Cerar");
            }

        }

        private async void BtnHome_Clicked(object sender, EventArgs e)
        {
            //Abro la navegacion
            await Navigation.PopAsync();

        }
    }
}