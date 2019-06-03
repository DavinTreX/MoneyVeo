using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoneyVeoMatrix.DTOs;
using MoneyVeoMatrix.Engines.Interfaces;

namespace MoneyVeoMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatrixController : ControllerBase
    {
        private readonly IMatrixEngine _matrixEngine;

        public MatrixController(IMatrixEngine matrixEngine)
        {
            _matrixEngine = matrixEngine;
        }

        [HttpGet(Name = "GetMatrixFromCsv")]
        public async Task<IActionResult> GetFromCsvAsync()
        {
            return Ok(await _matrixEngine.GetMatrixFromCsvAsync());
        }

        [HttpPost]
        public async Task<IActionResult> ExportToCsvAsync(MatrixDTO matrixDto)
        {
            await _matrixEngine.ExportMatrixToCsvAsync(matrixDto);
            return Created("GetMatrixFromCsv", matrixDto);
        }

        [HttpGet("{generate}")]
        public async Task<IActionResult> GetGeneratedAsync()
        {
            return Ok(await _matrixEngine.GetMatrixAsync());
        }

        [HttpPost("{rotate}")]
        public async Task<IActionResult> RotateAsync(MatrixDTO matrixDto)
        {
            return Ok(await _matrixEngine.GetRotatedMatrixAsync(matrixDto));
        }
    }
}