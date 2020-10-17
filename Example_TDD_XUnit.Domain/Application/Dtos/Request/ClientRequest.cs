namespace Example_TDD_XUnit.Domain.Application.Dtos.Request
{
    public class ClientRequest
    {
        /// <summary>
        /// Representa o identificador unico do cliente
        /// </summary>
        /// <exemple>f17422bd-ed37-439b-a8d5-85cd3772ea31</exemple>
        public string Id { get; set; }

        /// <summary>
        /// Representa o nome da pessoa juridica ou pessoa fisica
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Representa o endereco completo do cliente
        /// incluindo localidade, numero, complemento e bairro
        /// </summary>
        public string EnderecoCompleto { get; set; }

        /// <summary>
        /// Representa a Cidade referente ao campo EnderecoCompleto
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Representa o codigo postal do campo EnderecoCompleto
        /// </summary>
        public string Cep { get; set; }

        /// <summary>
        /// Representa a Unidade Federativa referente ao campo Cidade
        /// </summary>
        public string UF { get; set; }

        /// <summary>
        /// Representa o pais referente ao campo UF
        /// </summary>
        public string Pais { get; set; }
    }
}
