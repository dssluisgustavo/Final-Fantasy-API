using FF_Teste.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF_Teste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : Controller
    {
        public JobDataBase jobdatabase = new JobDataBase();

        [HttpGet]
        public ActionResult<List<Job>> GetJobs()
        {
            List<Job> jobs = jobdatabase.GetAllJobs();
            
            return Ok(jobs);
        }


        [HttpGet("{id}")]
        public ActionResult<Job> GetJobById(int id)
        {
            Job job = jobdatabase.GetById(id);
            
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJobsById(int id)
        {
            jobdatabase.DeleteById(id);

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateJob(Job jobtocreate)
        {
            jobdatabase.Create(jobtocreate);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateJob(int id, Job jobtoupdate)
        {
            jobdatabase.Update(id, jobtoupdate);

            return Ok();
        }

        [HttpGet("{jobid}/weapons")]
        public ActionResult <List<Weapon>>WeaponsListById(int jobid)
        {

            Job job = jobdatabase.GetById(jobid);

            return Ok(job.weaponlist);
        }

        [HttpGet("{jobid}/armors")]
        public ActionResult<List<Armor>> ArmorsListById(int jobid)
        {

            Job job = jobdatabase.GetById(jobid);

            return Ok(job.armorlist);
        }
    }

}

