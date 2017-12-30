using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using projetoCEDROWEBAPI.Models;

namespace projetoCEDROWEBAPI.Models
{
    public class Prato
    {
        [Key]
        public int IdPrato { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Preco { get; set; }
        public int RestauranteIdRef { get; set; }

        //Relação N - 1 com Restaurante
        public virtual Restaurante Restaurante { get; set; }
    }
}
