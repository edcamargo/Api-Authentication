using System;
using System.Collections.Generic;
using System.Web.Http;
using Authentication.DataVo.Converters;
using Authentication.DataVo.ValueObjects;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CompanyController : ControllerBase
    {
        /// <summary>
        /// Declaration of Interfaces
        /// </summary>
        private readonly ICompanyService _companyService;
        private readonly CompanyConverter _companyConverter;

        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="companyService"></param>
        /// <param name="companyConverter"></param>
        public CompanyController(ICompanyService companyService, CompanyConverter companyConverter)
        {
            _companyService = companyService;
            _companyConverter = companyConverter;
        }

        /// <summary>
        /// Return All Records
        /// </summary>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                // var registros = _companyService.GetAll(pIdEmpresa, page, length);
                var registros = _companyService.GetAll();
                return new OkObjectResult(registros);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Return Records By Id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpGet("{pId}")]
        public ActionResult<string> Get(int pId)
        {
            try
            {
                var _company = _companyConverter.Parse(_companyService.GetById(pId));
                return new OkObjectResult(_company);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Add Record
        /// </summary>
        /// <param name="CompanyVo"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] CompanyVo companyVo)
        {
            try
            {
                var companyEntity = _companyConverter.Parse(companyVo);

                if (companyEntity == null) return BadRequest();
                var ret = _companyService.Add(companyEntity);

                return Ok(ret);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        /// <summary>
        /// Change Record
        /// </summary>
        /// <param name="CompanyVo"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpPut]
        public IActionResult Put([FromBody] CompanyVo companyVo)
        {
            try
            {
                var companyEntity = _companyConverter.Parse(companyVo);

                _companyService.Update(companyEntity);
                return Ok(companyVo);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        /// <summary>
        /// Delete Records By Id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpDelete]
        public IActionResult Delete([FromUri] string[] pId)
        {
            try
            {
                foreach (var i in pId)
                {
                    var Atualizar = _companyService.GetById(int.Parse(i));

                    if (Atualizar != null)
                    {
                        _companyService.Remove(Atualizar);
                    }
                }

                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
