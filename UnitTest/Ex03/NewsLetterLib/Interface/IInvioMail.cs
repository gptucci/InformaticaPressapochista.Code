using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetterLib.Interface
{
    public interface IInvioMail
    {
        bool SendEmail(string destinatario, string _TestoEmail);
    }
}
