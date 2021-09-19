using DonateKartBusiness;
using DonatekartModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonateKartAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonateKartController : ControllerBase
    {
        IConfiguration configuration;
        IDonateKartBAL donateKartBAL;
        public DonateKartController(IConfiguration iconfiguration, IDonateKartBAL idonateKartBAL)
        {
            configuration = iconfiguration;
            donateKartBAL = idonateKartBAL;
        }


        [Route("GetCampaignList")]
        [HttpGet]
        public IActionResult GetCampaignList()
        {
            try
            {

                return Ok(donateKartBAL.getTotalcampaigns());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Route("Getactivecampaign")]
        [HttpGet]
        public IActionResult GetactiveCampaignList()
        {
            try
            {

                return Ok(donateKartBAL.getactivecampaigns());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Route("Getinactivecampaign")]
        [HttpGet]
        public IActionResult GetinactivecampaignList()
        {
            try
            {
                return Ok(donateKartBAL.getclosedcampaigns());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
