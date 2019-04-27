using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViaCepCore.Model;

namespace ViaCepCore.Client
{
    public static class ViaCepClient
    {
        private static string _viaCepUri = "https://viacep.com.br/ws/";

        /// <summary>
        /// Busca por CEP
        /// </summary>
        /// <param name="cep">CEP que será pesquisado</param>
        /// <returns>Objeto com os dados do cep <seealso cref="ViaCepResponseDto"/></returns>
        public static async Task<ViaCepResponseDto> BuscaPorCep(string cep)
        {
            #region Valida paramêtro

            if (string.IsNullOrEmpty(cep))
                throw new ArgumentException("Cep é obrigatório", nameof(cep));
            if (!cep.All(char.IsDigit))
                throw new ArgumentException("Cep deve possuir apenas números", nameof(cep));
            if (cep.Length != 8)
                throw new ArgumentException("Cep deve possuir exatamente 8 números", nameof(cep));

            #endregion

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_viaCepUri)
            };

            var response = await httpClient.GetAsync($"{cep}/json").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<ViaCepResponseDto>().ConfigureAwait(false);

        }

        /// <summary>
        /// Busca por endereço
        /// </summary>
        /// <param name="uf">UF que será pesquisada</param>
        /// <param name="cidade">Cidade que será pesquisada</param>
        /// <param name="logradouro">Logradouro que será pesquisado</param>
        /// <returns>Lista de objetos com os dados dos endereços<seealso cref="IEnumerable{ViaCepResponseDto}"/></returns>
        public static async Task<IEnumerable<ViaCepResponseDto>> BuscaPorEndereco(string uf, string cidade, string logradouro)
        {
            if(string.IsNullOrEmpty(uf))
                throw new ArgumentException("Uf é obrigatório", nameof(uf));
            if (string.IsNullOrEmpty(cidade))
                throw new ArgumentException("Cidade é obrigatório", nameof(cidade));
            if (string.IsNullOrEmpty(logradouro))
                throw new ArgumentException("Logradouro é obrigatório", nameof(logradouro));


            if (uf.All(char.IsDigit))
                throw new ArgumentException("UF não deve possuir números", nameof(uf));
            if (uf.Length != 2)
                throw new ArgumentException("UF deve possuir exatamente 2 caracteres", nameof(uf));

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_viaCepUri)
            };

            var response = await httpClient.GetAsync($"{uf}/{cidade}/{logradouro}/json").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<IEnumerable<ViaCepResponseDto>>().ConfigureAwait(false);
        }
    }
}