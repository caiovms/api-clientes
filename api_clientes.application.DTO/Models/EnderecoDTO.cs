﻿namespace api_clientes.application.DTO.Models
{
    public class EnderecoDTO
    {
        public int? Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
