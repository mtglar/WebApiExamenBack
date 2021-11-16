using System;
using System.ComponentModel.DataAnnotations;

namespace Capa_ModeloEntidades1
{
    public class Agenda
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Este campo es requerido, no debe estar vacio")]
        public string Name { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Este campo es requerido, no debe estar vacio")]
        [RegularExpression("^[0-9]*$")]
        public int Phone { get; set; }

        public string CodeCountry { get; set; }
        [Required(ErrorMessage = "Este campo es requerido, no debe estar vacio")]


        [EmailAddress(ErrorMessage ="Correo electronico invalido")]
        public string Email { get; set; }
    }
}
