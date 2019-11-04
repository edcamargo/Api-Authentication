using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Authentication.DataVo.Converters;
using Authentication.DataVo.ValueObjects;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GroupsController : ControllerBase
    {
        /// <summary>
        /// Declaration of Interfaces
        /// </summary>
        private readonly IGroupsService _groupsService;
        private readonly GroupsConverter _groupsConverter;

        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="groupsService"></param>
        /// <param name="groupsConverter"></param>
        public GroupsController(IGroupsService groupsService, GroupsConverter groupsConverter)
        {
            _groupsService = groupsService;
            _groupsConverter = groupsConverter;
        }

        [Authorize("Bearer")]
        [HttpGet("CompanyId/{CompanyId}/Page/{page}/Length/{length}")]
        public ActionResult<IEnumerable<string>> Get(int CompanyId, int page, int length)
        {
            try
            {
                var registros = _groupsService.GetAll(CompanyId, 0, page, length);
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

        [Authorize("Bearer")]
        [HttpGet("{pId}")]
        public ActionResult<string> Get(int pId)
        {
            try
            {
                var _company = _groupsConverter.Parse(_groupsService.GetById(pId));
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

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] GroupsVo groupsVo)
        {
            try
            {
                var groupsEntity = _groupsConverter.Parse(groupsVo);

                if (groupsEntity == null) return BadRequest();
                var ret = _groupsService.Add(groupsEntity);

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

        [Authorize("Bearer")]
        [HttpPut]
        public IActionResult Put([FromBody] GroupsVo groupsVo)
        {
            try
            {
                var groupsEntity = _groupsConverter.Parse(groupsVo);

                _groupsService.Update(groupsEntity);
                return Ok(groupsVo);
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

        [Authorize("Bearer")]
        [HttpDelete]
        public IActionResult Delete([FromUri] string[] pId)
        {
            try
            {
                foreach (var i in pId)
                {
                    var Atualizar = _groupsService.GetById(int.Parse(i));

                    if (Atualizar != null)
                    {
                        _groupsService.Remove(Atualizar);
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
