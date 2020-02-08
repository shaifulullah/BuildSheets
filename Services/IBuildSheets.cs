using BuildSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Services
{
    public interface IBuildSheets
    {
        IEnumerable<BuildSheet> Main(string name);
        BuildSheet Details(int? Id);
    }
}
