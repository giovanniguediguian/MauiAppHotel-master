using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }

    private async void btnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContratacaoHospedagem());
    }
}
