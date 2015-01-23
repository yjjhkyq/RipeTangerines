using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.IO
{
    public class FileSystemSettings : ISettings
    {
        public string DirectoryName { get; set; }
    }
}
