using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_____lb1
{
  internal class Program
  {
    static void Main(string[] args)
    {
      User David = new User("+380993857855");

      David.setTariff(TariffNames.Vodafone_SuperNet_Turbo);

      double balance = David.topUpTheAccount(500);

      double costOfCall = David.call("+380661530961", 2);

      David.addService(Services.TV_in_phone);
      David.addService(Services.Hide_your_phone_number);
      David.addService(Services.International_calls_and_SMS);

      David.removeService(Services.TV_in_phone);

      double balanceFromGetter = David.getBalance();

      List<Services> myServices = David.getServices();

      David.printServices();

      David.printCallHistory();
    }
  }
}
