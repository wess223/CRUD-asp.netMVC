using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.Dominio

{
    public class Usuarios
    {

        public int Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o nome do usuário")]
        public string Nome { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "informe o cargo do usuário")]
        public string Cargo { get; set; }

        [DisplayName("Data de Cadastro")]
        [Required(ErrorMessage = "informe a data de cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

    }
}
