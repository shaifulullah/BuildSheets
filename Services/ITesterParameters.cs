using BuildSheets.Helpers;
using BuildSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildSheets.Services
{
    public interface ITesterParameters
    {
        IEnumerable<TesterParameter> Main(string name);
        IEnumerable<TesterParameter> GetAll();
        TesterParameter Details(string name, int revision);
        TesterParameter Create(AddTesterParameter model);
        TesterParameter Edit(string oldParameterName, string oldParameterValue, EditTesterParameter model);
        TesterParameter Add(EditTesterParameter model);
        TesterParameter Delete(EditTesterParameter model);
    }
}
