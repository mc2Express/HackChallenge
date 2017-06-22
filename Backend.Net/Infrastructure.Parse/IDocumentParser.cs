using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessDomain;

namespace Infrastructure.Parse
{
    public interface IDocumentParser<out T> where T : IDomainObject
    {
        T Parse(string documentPath);
    }
}
