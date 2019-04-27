namespace ViaCepCore.Model
{
    /// <summary>
    /// Dto de retorno do WS ViaCep
    /// </summary>
    public class ViaCepResponseDto
    {
        /// <summary>
        /// CEP
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// UF
        /// </summary>
        public string Uf { get; set; }

        /// <summary>
        /// Unidade
        /// </summary>
        public string Unidade { get; set; }

        /// <summary>
        /// Código IBGE
        /// </summary>
        public string Ibge { get; set; }

        /// <summary>
        /// Código GIA
        /// </summary>
        public string Gia { get; set; }
    }
}