using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;
        private void btnCliqueAqui_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = "Você clicou " + count.ToString() + " vezes";
        }

        private async void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"O nome tem {txtNome.Text.Length} caracteres";
            await DisplayAlert("Mensagem", texto, "Ok");
        }

        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Pergunta", "Deseja realmente limpar a tela?", "Yes", "No"))
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique aqui";
                count = 0;

            }
        }

        /*
         * private void btnDiasVividos_Clicked(object sender, EventArgs e)
        {
            DateTime dataNasc = dataNascimento.Date;
            DateTime dataAtual = DateTime.Now;
            int dias = dataAtual.Subtract(dataNasc).Days;
            lblIdade.Text = $"Você viveu {dias} dias";
        }
        */

        private async void btnInformarDataNascimento_Clicked(object sender, EventArgs e)
        {
            try
            {
                string dataDigitada = await DisplayPromptAsync("Info", "Digite a data de nascimento", "Ok");
                DateTime dataConvertida;

                bool converteu = DateTime.TryParse(dataDigitada, new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida);

                //if(!converteu)
                if (converteu == false)
                {
                    throw new Exception("Esta não é uma data válida");
                }
                else
                {
                    int diasVividos = (int)DateTime.Now.Subtract(dataConvertida).TotalDays;
                    await DisplayAlert("Info", $"Você já viveu {diasVividos} dias!", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }
        }

        private async void btnOpcoes_Clicked(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message + ex.InnerException, "OK");
            }
        }
    }
}
