using DonatekartModel;
using DonatekartRepo;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DonateKartBusiness
{
    public class DonateKartBAL : IDonateKartBAL
    {
        IConfiguration configuration;
        IDonateKartRepo donateKartRepo;
        public DonateKartBAL(IConfiguration iconfiguration, IDonateKartRepo idonateKartRepo)
        {
            configuration = iconfiguration;
            donateKartRepo = idonateKartRepo;
        }

        public List<ListOfCampaigns> getTotalcampaigns()
        {
           
            string result = donateKartRepo.getResponse("campaign");
            List<campaignResult> campaignResult = JsonConvert.DeserializeObject<List<campaignResult>>(result);
            List<ListOfCampaigns> listOfCampaigns = campaignResult.Select(e => new ListOfCampaigns
            {
                title = e.title,
                totalAmount = e.totalAmount,
                backersCount = e.backersCount,
                endDate = e.endDate
            }).ToList();
            
            return listOfCampaigns.OrderByDescending(e => e.totalAmount).ToList();
        }


        public List<campaignResult> getactivecampaigns()
        {
            string result = donateKartRepo.getResponse("campaign");
            List<campaignResult> campaignResult = JsonConvert.DeserializeObject<List<campaignResult>>(result);
           

            return campaignResult.Where(e=>e.endDate>=DateTime.Now && e.created<=DateTime.Now.AddDays(-30)).ToList();
        }


        public List<campaignResult> getclosedcampaigns()
        {
            string result = donateKartRepo.getResponse("campaign");
            List<campaignResult> campaignResult = JsonConvert.DeserializeObject<List<campaignResult>>(result);


            return campaignResult.Where(e => e.endDate < DateTime.Now || e.procuredAmount>=e.totalAmount).ToList();
        }




    }
}
