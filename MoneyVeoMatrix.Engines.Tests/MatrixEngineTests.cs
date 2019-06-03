using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyVeoMatrix.DTOs;
using MoneyVeoMatrix.Engines.Interfaces;
using System.Threading.Tasks;

namespace MoneyVeoMatrix.Engines.Tests
{
    [TestClass]
    public class MatrixEngineTests
    {
        private readonly ICsvEngine _csvEngine;
        private IMatrixEngine _matrixEngine;

        public MatrixEngineTests()
        {
            _csvEngine = new CsvEngine();
            _matrixEngine = new MatrixEngine(_csvEngine);
        }

        [TestMethod]
        public async Task GetMatrix_GetResult()
        {
            var result = await _matrixEngine.GetMatrixAsync();

            Assert.IsTrue(result.Matrix.Length > 0);
        }

        [TestMethod]
        public async Task GetRotateMatrix_GetResult()
        {
            var matrixDto = new MatrixDTO
            {
                Matrix = new int[,]
                {
                    { 2, 3, 4 },
                    { 59, 17, 45 },
                    { 25, 33, 42 }
                }
            };

            Assert.AreEqual(matrixDto.Matrix[0, 0], 2);
            var result = await _matrixEngine.GetRotatedMatrixAsync(matrixDto);

            Assert.IsTrue(result.Matrix.Length > 0);
            Assert.AreNotEqual(matrixDto.Matrix[0, 0], 2);
        }


        [TestMethod]
        public async Task ReadMatrix_GetResult()
        {
            var result = await _matrixEngine.GetMatrixFromCsvAsync();

            Assert.IsTrue(result.Matrix.Length > 0);
        }

        [TestMethod]
        public async Task ExportMatrix_GetResult()
        {
            var matrixDto = new MatrixDTO
            {
                Matrix = new int[,]
                {
                    { 2, 3, 4 },
                    { 59, 17, 45 },
                    { 25, 33, 42 }
                }
            };
            Assert.AreEqual(matrixDto.Matrix[0, 0], 2);

            await _matrixEngine.ExportMatrixToCsvAsync(matrixDto);

            Assert.IsTrue(matrixDto.Matrix.Length > 0);
            Assert.AreEqual(matrixDto.Matrix[0, 0], 2);
        }
    }
}
