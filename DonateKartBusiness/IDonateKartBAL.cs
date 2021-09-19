using DonatekartModel;
using System.Collections.Generic;

namespace DonateKartBusiness
{
    public interface IDonateKartBAL
    {
        List<ListOfCampaigns> getTotalcampaigns();
        List<campaignResult> getactivecampaigns();
        List<campaignResult> getclosedcampaigns();
    }
}