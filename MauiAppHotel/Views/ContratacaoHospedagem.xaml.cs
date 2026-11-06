
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current!;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        DateTime hoje = DateTime.Now;

        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkin.MaximumDate = hoje.AddMonths(1);

        DateTime dataCheckIn = dtpck_checkin.Date ?? hoje;

        dtpck_checkout.MinimumDate = dataCheckIn.AddDays(1);
        dtpck_checkout.MaximumDate = dataCheckIn.AddMonths(6);
    }

    private async void Button_Quartos(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Quartos());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private async void Button_Sobre(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new Sobre());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pck_quarto.SelectedItem is not Quarto quarto)
            {
                await DisplayAlertAsync("Atenção", "Selecione um quarto.", "OK");
                return;
            }

            DateTime dataCheckIn = dtpck_checkin.Date
                ?? throw new InvalidOperationException("Selecione a data de check-in.");

            DateTime dataCheckOut = dtpck_checkout.Date
                ?? throw new InvalidOperationException("Selecione a data de check-out.");

            if (dataCheckOut <= dataCheckIn)
            {
                await DisplayAlertAsync("Atenção", "O check-out deve acontecer depois do check-in.", "OK");
                return;
            }

            Hospedagem h = new Hospedagem
            {
                QuartoSelecionado = quarto,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                QntCriancas = Convert.ToInt32(stp_criancas.Value),
                DataCheckIn = dataCheckIn,
                DataCheckOut = dataCheckOut,
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (sender is not DatePicker elemento)
            return;

        DateTime dataSelecionadaCheckIn = elemento.Date ?? DateTime.Now;

        dtpck_checkout.MinimumDate = dataSelecionadaCheckIn.AddDays(1);
        dtpck_checkout.MaximumDate = dataSelecionadaCheckIn.AddMonths(6);
    }
}
