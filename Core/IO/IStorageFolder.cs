using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.IO
{
    public interface IStorageFolder
    {
        string GetPath();
        string GetName();
        long GetSize();
        DateTime GetLastUpdated();
        IStorageFolder GetParent();
    }
}
