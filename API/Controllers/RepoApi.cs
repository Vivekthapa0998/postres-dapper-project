using BL.Contracts;
using DL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoApi : ControllerBase
    {
        private readonly IBlRepository _blRepo;
        public RepoApi(IBlRepository blRepo)
        {
            _blRepo = blRepo;
        }

        [HttpGet]
        public IActionResult getallrepo()
        {
            var data = _blRepo.Getall();
            return Ok(data);
        }
        [HttpGet("{id}")]

        public IActionResult getrepobyid(int id)
        {
            var data = _blRepo.GetById(id);

            return Ok(data);
        }

        [HttpPost]
        public IActionResult insert(Repository r) 
        {
            _blRepo.Createrepo(r);
            return Ok();
        }
        [HttpPut]
        public IActionResult update(Repository r) 
        {
            _blRepo.Updaterepo(r);
            return Ok();
        }
        [HttpDelete]
        public IActionResult delete(int id) 
        {
            _blRepo.Deleterepo(id);
            return Ok();
        }
    }
}
