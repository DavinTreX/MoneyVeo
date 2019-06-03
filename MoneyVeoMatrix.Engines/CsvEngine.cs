using MoneyVeoMatrix.Engines.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MoneyVeoMatrix.Engines
{
    public class CsvEngine : ICsvEngine
    {
        public async Task<string[]> ReadAsync(string path)
        {
            return await File.ReadAllLinesAsync(path);
        }

        public async Task WriteAsync(string path, IEnumerable<string> contents)
        {
            await File.WriteAllLinesAsync(path, contents);
        }
    }
}
