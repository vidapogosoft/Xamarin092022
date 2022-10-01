using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using CollectionSwippe.Models;

namespace CollectionSwippe
{
    public partial class MainPage : ContentPage
    {
        public List<DTOItems> AllItems;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Metodo de consulta y llena el collection

            CargarItems();

        }

        public void CargarItems()
        {
            AllItems = new List<DTOItems>();

            AllItems = new List<DTOItems>()
            {
                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="AZUCAR BLANCA DON ANTONIO 1 KG",
                    Pallet="2"

                },


                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="LECHE ENTERA EL HACENDADO 1 L FUNDA",
                    Pallet="2"

                },


                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="LECHE ENTERA EL HACENDADO 1 L FUNDA",
                    Pallet="2"

                },


                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="LECHE ENTERA EL HACENDADO 1 L FUNDA",
                    Pallet="2"

                },

                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="LECHE ENTERA EL HACENDADO 1 L FUNDA",
                    Pallet="2"

                },

                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="LECHE ENTERA EL HACENDADO 1 L FUNDA",
                    Pallet="2"

                },

                new DTOItems
                {
                    Frecuencia="6",
                    CodItem="40000656",
                    Item="LECHE ENTERA EL HACENDADO 1 L TETRA",
                    Pallet="3"

                },

                new DTOItems
                {
                    Frecuencia="2",
                    CodItem="40000656",
                    Item="AGUA PURE WATER 1200 ML",
                    Pallet="5"

                }


            };


            if (AllItems.Count > 0)
            {
                CVItems.ItemsSource = AllItems;
            }


        }

        private async void CVItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(e.CurrentSelection.Any())
            {

                string Item, action;

                Item = (CVItems.SelectedItem as DTOItems)?.Item;


                //Mostrar el display action

                action = await DisplayActionSheet("¿Que deseas realizar?", "Cancelar", null,
                    "Revisar Detalles de item:" + Item, "Borrar item: " + Item);

                if(action == "Revisar Detalles de item:" + Item)
                {
                    await DisplayAlert("Mensaje", "Detalles: " + Item, "Cerrar");
                }

                if (action == "Borrar item: " + Item)
                {
                    await DisplayAlert("Mensaje", "Borrado: " + Item, "Cerrar");
                }

                //Reset de la seleccion del collection
                CVItems.SelectedItem = null;

            }


        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            try
            {

                string result = await DisplayPromptAsync("Pedido", "Ingrese Cantidad:", initialValue: "1",
                maxLength: 2, keyboard: Keyboard.Numeric);

                if (int.Parse(result) > 0)
                {
                    await DisplayAlert("Mensaje", "Iten agregado", "Cerrar");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Cerrar");
            }


        }

        private async void ArchivarItem_Invoked(object sender, EventArgs e)
        {
            await DisplayAlert("Mensaje", "Iten Archivado", "Cerrar");
        }

        private void SwipeItem_Clicked(object sender, EventArgs e)
        {
           
        }
    }
}
