using MoneyVeoMatrix.DTOs;
using System.Threading.Tasks;

namespace MoneyVeoMatrix.Engines.Interfaces
{
    public interface IMatrixEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<MatrixDTO> GetMatrixFromCsvAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrixDto"></param>
        /// <returns></returns>
        Task ExportMatrixToCsvAsync(MatrixDTO matrixDto);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<MatrixDTO> GetMatrixAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrixDto"></param>
        /// <returns></returns>
        Task<MatrixDTO> GetRotatedMatrixAsync(MatrixDTO matrixDto);
    }
}
