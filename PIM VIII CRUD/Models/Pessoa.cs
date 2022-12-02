using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PIM_VIII_CRUD.Models
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public Guid Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("Cpf")]
        [Display(Name = "CPF")]
        public long Cpf { get; set; }

        [Column("Logradouro")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Column("Número")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Column("CEP")]
        [Display(Name = "CEP")]
        public int Cep { get; set; }

        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public int Telefone { get; set; }

        [Column("Ddd")]
        [Display(Name = "DDD")]
        public int Ddd { get; set; }

        [Column("Tipo Telefone")]
        [Display(Name = "Tipo Telefone")]
        public string TipoTelefone { get; set; }

    }
}
