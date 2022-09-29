using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Essentials;

namespace XamEssential1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DatosMovil();
        }

        private void DatosMovil()
        {
            DeviceInfor.Text = DeviceInfo.Model;
            DeviceVersion.Text = DeviceInfo.VersionString;
            DeviceName.Text = DeviceInfo.Name;
            DeviceManuf.Text = DeviceInfo.Manufacturer;
        }

        private void BtnCall_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open("046004000");
        }

        private async void BtnSMS_Clicked(object sender, EventArgs e)
        {
            await Sms.ComposeAsync(new SmsMessage("SMS Curso de XAMARIN-" + DeviceName.Text, "0960574445"));
        }

        private async void BtnEmail_Clicked(object sender, EventArgs e)
        {
            List<string> reciben;
            reciben = new List<string>();

            reciben.Add("vidapogosoft@hotmail.com");

            var message = new EmailMessage
            {
                Subject = "Curso de Xamarin",
                Body = "Curso dicatdo por la empresa SIPECOM en al ciudad de GYE",
                To = reciben
                //Cc = reciben
            };

            await Email.ComposeAsync(message);

        }
    }
}
