using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_____lb1
{
  enum TariffNames
  {
    Vodafone_SuperNet_Turbo = 100, // in $
    Vodafone_Joice = 50,
    Vodafone_Device_S = 35,
    Vodafone_Device_L = 15
  }

  enum Services
  {
    TV_in_phone = 4, // in $
    Hide_your_phone_number = 2,
    International_calls_and_SMS = 10
  }

  struct PhoneCall
  {
    public string phoneNumber;
    public int minutes;
  }

  internal class Tariff
  {
    public string name;
    public double costPerMinute;

    public List<Services> services = new List<Services>();

    public Tariff()
    {
      name = getNameFromEnum(TariffNames.Vodafone_Device_S);
      costPerMinute = (int)TariffNames.Vodafone_Device_S;
    }

    public Tariff(TariffNames t)
    {
      name = getNameFromEnum(t);
      costPerMinute = (int)t;
    }

    private string getNameFromEnum(TariffNames t)
    {
      switch (t)
      {
        case TariffNames.Vodafone_SuperNet_Turbo:
          return "Vodafone_SuperNet_Turbo";
        case TariffNames.Vodafone_Joice:
          return "Vodafone_Joice";
        case TariffNames.Vodafone_Device_S:
          return "Vodafone_Device_S";
        case TariffNames.Vodafone_Device_L:
          return "Vodafone_Device_L";
        default:
          return "Vodafone_Device_S";
      }
    }

    public string getServiceNameFromEnum(Services t)
    {
      switch (t)
      {
        case Services.TV_in_phone:
          return "TV_in_phone";
        case Services.Hide_your_phone_number:
          return "Hide_your_phone_number";
        case Services.International_calls_and_SMS:
          return "International_calls_and_SMS";
        default:
          return "International_calls_and_SMS";
      }
    }
  }
}
