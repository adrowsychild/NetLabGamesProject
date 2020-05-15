using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Net.Lab.Common.Implementations;
using Net.Lab.Common.Interfaces;
using Net.Lab.DAL.Exceptions;
using Net.Lab.DataContracts.Awards;

namespace Net.Lab.CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        private static IAwardsService awardsService;
        private readonly IMemoryCache cache;
        private string awardkey = "award";
        string allAwardsKey = "awards000";

        public AwardsController(IAwardsService awardsService, IMemoryCache cache)
        {
            this.cache = cache;
            if (AwardsController.awardsService == null)
                AwardsController.awardsService = awardsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Award>> GetAllAwards()
        {
            try
            {
                if (!cache.TryGetValue(allAwardsKey, out IEnumerable<Award> result))
                {
                    result = awardsService.GetAwards();
                    cache.Set(allAwardsKey, result);
                }
                return Ok(result);
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Award> GetAward(int id)
        {
            try
            {
                if (!cache.TryGetValue(awardkey + id, out Award result))
                {
                    result = awardsService.GetAward(id);
                    cache.Set(awardkey + id, result);
                }

                return Ok(result);
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateAward(Award award)
        {
            try
            {
                awardsService.CreateAward(award);
                ClearAllAwardsCache();
                return Created("", award);
            }
            catch (InvalidAwardException)
            {
                return BadRequest(award);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditAward(int id, Award award)
        {
            try
            {
                awardsService.EditAward(id, award);
                cache.Set(awardkey + id, award);
                ClearAllAwardsCache();
                return Ok();
            }
            catch (InvalidAwardException)
            {
                return BadRequest();
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAward(int id)
        {
            try
            {
                awardsService.DeleteAward(id);
                cache.Remove(awardkey + id);
                ClearAllAwardsCache();
                return Ok();
            }
            catch (AwardNotFoundException)
            {
                return NotFound();
            }
        }

        private void ClearAllAwardsCache()
        {
            cache.Remove(allAwardsKey);
        }
    }
}