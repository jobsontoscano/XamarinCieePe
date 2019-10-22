using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

namespace ConsultarCep.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null)
            {
                return null;
            }
            return endereco;
        }
    }
}
