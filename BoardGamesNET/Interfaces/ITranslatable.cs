using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNET.Interfaces
{
    public interface ITranslatable
    {
        long LanguageReference { get; set; }

        event EventHandler<long> LanguageReferenceChangedEvent;
    }
}
