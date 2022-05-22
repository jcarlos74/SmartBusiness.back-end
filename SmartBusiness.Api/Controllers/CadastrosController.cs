using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SmartBusiness.Api.Dtos.Cadastros;
using SmartBusiness.AppServices.Cadastro;
using SmartBusiness.Domain.Entities.Cadastros;
using SmartBusiness.Domain.Entities.CtAcesso;
using SmartBusiness.Identity.Models;
using SmartBusiness.Infra;
using SmartBusiness.Infra.DataGrid.PrimeNG.Table.Models;
using SmartBusiness.Infra.Repositories.Interfaces;

namespace SmartBusiness.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastrosController : SmartControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationTenant _tenant;
        private readonly ISiltCidadeService _userService;

        public CadastrosController(IMapper mapper, ApplicationTenant tenant)
        {
            _mapper = mapper;
            _tenant = tenant;
            //_userService = userService;

        }


        [HttpPost("lista-cidades")]
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResult<List<VwListaCidades>>>> ListaCidades([FromBody]FilterModel loadOptions, [FromServices] IBaseRepository<VwListaCidades> cidadeRepository)
        {
            
            //List<VwListaCidades> lista = null;

            try
            {
                int totalResultsCount = 0;

            //    var searchInfo = this.GetSearchInfo(loadOptions);

                var lista = cidadeRepository.PagedList(loadOptions, out totalResultsCount); // List(x=>x.IdUf == 12);
                
                return Ok(new ApiResult<List<VwListaCidades>>()
                {
                    Success = true,
                    Data = lista.ToList(),
                    TotalRows = totalResultsCount
                });

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ErrorToClient<bool>());
            }

        }



        [HttpGet("carrega-cidades")]
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResult<List<VwListaCidades>>>> CarregaCidades([FromServices] IBaseRepository<VwListaCidades> cidadeRepository)
        {
            
            try
            {
                var lista = cidadeRepository.ListAll(); 

                return Ok(new ApiResult<List<VwListaCidades>>()
                {
                    Success = true,
                    Data = lista.ToList(),
                    TotalRows = lista.Count
                });

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ErrorToClient<bool>());
            }

        }

        [HttpGet("lista-departamentos")]
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResult<List<CadDepartamento>>>> ListaDepartamentos([FromServices] IBaseRepository<CadDepartamento> deptoRepository)
        {

            try
            {
                int totalResultsCount = 0;

                var lista = deptoRepository.List(x => x.IdTenant == this._tenant.IdTenant);

                return Ok(new ApiResult<List<CadDepartamento>>()
                {
                    Success = true,
                    Data = lista.ToList(),
                    TotalRows = lista.Count
                });

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ErrorToClient<bool>());
            }

        }

        [HttpGet("lista-cargos")]
        [Authorize("Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResult<List<CadCargo>>>> ListaCargos([FromServices] IBaseRepository<CadCargo> deptoRepository)
        {

            try
            {
                int totalResultsCount = 0;

                var lista = deptoRepository.List(x => x.IdTenant == this._tenant.IdTenant);

                return Ok(new ApiResult<List<CadCargo>>()
                {
                    Success = true,
                    Data = lista.ToList(),
                    TotalRows = lista.Count
                });

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ErrorToClient<bool>());
            }

        }

        [HttpPost("grava-departamento")]
        [Authorize("Bearer")]
        public async Task<ActionResult<ApiResult<int?>>> GravaDepartamento([FromBody]Departamento depto, [FromServices] IBaseRepository<CadDepartamento> deptoRepository)
        {
            int? idDepto = null;

            if (depto != null)
            {
                var cadDepto = new CadDepartamento()
                {
                    IdTenant = _tenant.IdTenant,
                    NomeDepartamento = depto.NomeDepartamento.ToUpper()
                };
                
                idDepto = deptoRepository.Insert(cadDepto);
            }

            return Ok(new ApiResult<int?>()
            {
                Success = true,
                Data = idDepto,
                TotalRows = 1
            });
        }
    }
}
