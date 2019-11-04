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
    public class GroupUsersController : ControllerBase
    {
        /// <summary>
        /// Declaration of Interfaces
        /// </summary>
        private readonly IGroupUsersService _groupUsersService;
        private readonly GroupUsersConverter _groupUsersConverter;

        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="groupsUsersService"></param>
        /// <param name="groupsUsersConverter"></param>
        public GroupUsersController(IGroupUsersService groupUsersService, GroupUsersConverter groupUsersConverter)
        {
            _groupUsersService = groupUsersService;
            _groupUsersConverter = groupUsersConverter;
        }

        /// <summary>
        /// Return All Records
        /// </summary>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var registros = _groupUsersService.GetAll();
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
                var _company = _groupUsersConverter.Parse(_groupUsersService.GetById(pId));
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
        /// <param name="groupUsersVo"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] GroupUsersVo groupUsersVo)
        {
            try
            {
                var groupEntity = _groupUsersConverter.Parse(groupUsersVo);

                if (groupEntity == null) return BadRequest();
                var ret = _groupUsersService.Add(groupEntity);

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
        /// <param name="groupUsersVo"></param>
        /// <returns></returns>
        [Authorize("Bearer")]
        [HttpPut]
        public IActionResult Put([FromBody] GroupUsersVo groupUsersVo)
        {
            try
            {
                var groupEntity = _groupUsersConverter.Parse(groupUsersVo);

                _groupUsersService.Update(groupEntity);
                return Ok(groupUsersVo);
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
                    var Atualizar = _groupUsersService.GetById(int.Parse(i));

                    if (Atualizar != null)
                    {
                        _groupUsersService.Remove(Atualizar);
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
