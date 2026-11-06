
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Quartos : ContentPage
{
    App PropriedadesApp;

    public Quartos()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current!;

        listaQuartos.ItemsSource = PropriedadesApp.lista_quartos;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
