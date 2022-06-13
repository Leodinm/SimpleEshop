using System;
 using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(Application.PaginationFilter.PaginationFilter filter, string route);
    }
}
