using MoneyVeoMatrix.DTOs;
using MoneyVeoMatrix.Engines.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyVeoMatrix.Engines
{
    public class MatrixEngine : IMatrixEngine
    {
        private readonly ICsvEngine _csvEngine;

        public MatrixEngine(ICsvEngine csvEngine)
        {
            _csvEngine = csvEngine;
        }

        public async Task<MatrixDTO> GetMatrixFromCsvAsync()
        {
            var csvLines = await _csvEngine.ReadAsync("Matrix.csv");
            var lines = new List<List<int>>();

            foreach (string item in csvLines)
            {
                lines.Add(new List<int>(item.Split(',').Select(v => int.Parse(v))));
            }

            var result = new int[csvLines.Length, csvLines.Length];

            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Count; j++)
                {
                    result[i, j] = lines[i][j];
                }
            }

            return new MatrixDTO { Matrix = result };
        }

        public async Task<MatrixDTO> GetMatrixAsync()
        {
            var random = new Random();
            int size = random.Next(4, 15);
            var matrix = new int[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = random.Next(1, 99);

            return await Task.FromResult(new MatrixDTO { Matrix = matrix });
        }

        public async Task<MatrixDTO> GetRotatedMatrixAsync(MatrixDTO matrixDto) 
        {
            var matrix = matrixDto.Matrix;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] ^= matrix[j, i];
                        matrix[j, i] ^= matrix[i, j];
                        matrix[i, j] ^= matrix[j, i];
                    }
                }
            }

            for (int i = 0; i < (matrix.GetLength(0)) / 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[j, i] ^= matrix[j, matrix.GetLength(0) - 1 - i];
                    matrix[j, matrix.GetLength(0) - 1 - i] ^= matrix[j, i];
                    matrix[j, i] ^= matrix[j, matrix.GetLength(0) - 1 - i];
                }
            }

            return await Task.FromResult(matrixDto);
        }

        public async Task ExportMatrixToCsvAsync(MatrixDTO matrixDto)
        {
            int[,] matrix = matrixDto.Matrix;
            var contents = new List<string>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = new List<int>();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line.Add(matrix[i, j]);
                }

                contents.Add(string.Join(',', line));
            }

            await _csvEngine.WriteAsync("Matrix.csv", contents);
        }
    }
}
