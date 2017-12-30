using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using projetoCEDROWEBAPI.Models;

namespace projetoCEDROWEBAPI.Models
{
    public class Restaurante
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }

        //Relação 1 - N com Prato
        public ICollection<Prato> Pratos { get; set; }
    }
}
