using MoneyVeoMatrix.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyVeoMatrix.Engines.Interfaces
{
    public interface ICsvEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<string[]> ReadAsync(string path);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="matrixDTO"></param>
        /// <returns></returns>
        Task WriteAsync(string path, IEnumerable<string> contents);
    }
}
