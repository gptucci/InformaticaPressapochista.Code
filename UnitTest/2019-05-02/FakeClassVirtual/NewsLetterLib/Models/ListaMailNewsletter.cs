using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizMathLib.Models
{
    [Table(nameof(ListaMailNewsletter))]
    public class ListaMailNewsletter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Mail { get; set; }
        public bool MailDaInviare { get; set; }
        public DateTime DataInvioUltimaMail { get; set; }
       
    }
}
