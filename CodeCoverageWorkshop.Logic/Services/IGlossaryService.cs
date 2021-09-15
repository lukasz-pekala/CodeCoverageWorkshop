using System.Collections.Generic;

namespace CodeCoverageWorkshop.Logic.Services
{
    public class GlossaryService : IGlossaryService
    {
        public IEnumerable<string> GetElements(GlossaryConsts glossaryName)
        {
            return new List<string>() { "brzydkiesłowo1", "zakazanyLogin" };
        }
    }

    public interface IGlossaryService
    {
        IEnumerable<string> GetElements(GlossaryConsts glossaryName);
    }
}