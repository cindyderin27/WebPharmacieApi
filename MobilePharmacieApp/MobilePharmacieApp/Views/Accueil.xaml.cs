using MobilePharmacieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePharmacieApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accueil : ContentPage
    {
        public Accueil()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // List<Proprio> pr;
            IEnumerable<Medicament> ModelListe = new List<Medicament>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://10.0.2.2:8002/api/Medicament");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    ModelListe = JsonConvert.DeserializeObject<IEnumerable<Medicament>>(json).ToList();

                }
            }
            collection.ItemsSource = ModelListe;

        }
    }
}