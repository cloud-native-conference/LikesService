﻿namespace LikesApi.Controllers
{
    using LikesApi.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : ControllerBase
    {
        private readonly LikesService likesService;

        public ConferenceController(LikesService likesService)
        {
            this.likesService = likesService;
        }

        [HttpGet("{uniqueName}/likes/users")]
        public ActionResult<List<string>> GetUsersPerConference(string uniqueName)
        {
            var likes = likesService.GetUsersPerConference(uniqueName);

            if (likes == null)
            {
                return NotFound();
            }

            return likes;
        }

        [HttpGet("{uniqueName}/likes/users/count")]
        public ActionResult<int> GetUsersCountPerConference(string uniqueName)
        {
            var likes = likesService.GetUsersPerConference(uniqueName);

            if (likes == null)
            {
                return NotFound();
            }

            return likes.Count;
        }

        [HttpPost("{uniqueName}/likes")]
        public IActionResult RegisterNewLikeForUser(string uniqueName, [FromBody] string useruniqueName)
        {         
            likesService.AddNewLikeForConference(useruniqueName, uniqueName);

            return new OkObjectResult(uniqueName);
        }
    }
}
