using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCep.Servico.Modelo;
using ConsultarCep.Servico;

namespace ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnCEP.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            
            if (ValidacaoCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if(end != null)
                    {
                        Resultado.Text = string.Format("Endereço: {2} de {3} {0}, {1} - {4}", end.localidade, end.uf, end.logradouro, end.bairro, end.cep);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não foi encontrado, pelo CEP: "+cep, "OK");
                    }

                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
                
            }
        }

        private bool ValidacaoCEP(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve Conter 8 caracteres", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep,out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto com numeros", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
