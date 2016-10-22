using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudbelldon.Facebook
{
    public interface IPhotoProvider
    {
        Task<IEnumerable<Photo>> GetPhotoLinks();
    }
}
