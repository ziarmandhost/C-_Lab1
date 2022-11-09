using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_____lb1
{
  internal class User
  {
    public Tariff tariff;
    public string phoneNumber;

    public double balance = 0;

    public List<PhoneCall> callsHistory = new List<PhoneCall>();

    public User()
    {
      phoneNumber = "+380661530961";

      Console.WriteLine("Created user with number: " + phoneNumber);
    }

    public User(string num)
    {
      phoneNumber = num;
      Console.WriteLine("Created user with number: " + phoneNumber);
    }

    public void setTariff(TariffNames t)
    {
      Tariff plan = new Tariff(t);
      tariff = plan;

      Console.WriteLine("You set tariff: " + plan.name);
    }

    public double call(string _phoneNumber, int minutes)
    {
      if (tariff is null)
      {
        Console.WriteLine("Please, set tariff before call!");

        return 0;
      }

      PhoneCall pc;
      pc.phoneNumber = _phoneNumber;
      pc.minutes = minutes;
      callsHistory.Add(pc);

      double cost = minutes * tariff.costPerMinute;

      if (balance < cost)
      {
        Console.WriteLine("No money!");

        return 0;
      }
      else
      {
        balance -= cost;

        Console.WriteLine("You called " + _phoneNumber + ". You spoke " + minutes + " minutes.");
        return balance;
      }
    }

    public double topUpTheAccount(double sum)
    {
      balance += sum;

      Console.WriteLine("Account balance changed. Now its: " + balance);
      return balance;
    }

    public double getBalance() { return balance; }

    public List<Services> getServices()
    {
      if (tariff is null)
      {
        Console.WriteLine("Please, set tariff before call!");

        return new List<Services>();
      }

      return tariff.services;
    }

    public void printServices()
    {
      if (tariff is null)
      {
        Console.WriteLine("Please, add services before printing services!");
        return;
      }

      Console.WriteLine("Services: ");
      foreach (Services service in tariff.services)
      {
        Console.WriteLine("- " + tariff.getServiceNameFromEnum(service));
      }
    }

    public void addService(Services serv)
    {
      if (tariff is null)
      {
        Console.WriteLine("Please, set tariff before adding service!");
        return;
      }

      tariff.services.Add(serv);

      int costOfService = (int)serv;
      balance -= costOfService;

      if (balance < costOfService)
      {
        Console.WriteLine("No money!");
      }
      else
      {
        balance -= costOfService;
        Console.WriteLine("Service " + tariff.getServiceNameFromEnum(serv) + " was added to your tariff!");
      }
    }

    public void removeService(Services serv)
    {
      if (tariff is null)
      {
        Console.WriteLine("Please, set tariff before removing service!");
        return;
      }

      tariff.services.Remove(serv);
      Console.WriteLine("Service " + tariff.getServiceNameFromEnum(serv) + " was removed from your tariff!");
    }

    public List<PhoneCall> getCallHistory() { return callsHistory; }

    public void printCallHistory()
    {
      if (tariff is null)
      {
        Console.WriteLine("Please, set tariff before printing call history!");
        return;
      }

      Console.WriteLine("Call history: ");
      foreach (PhoneCall call in callsHistory)
      {
        Console.WriteLine("- spoke with " + call.phoneNumber + " per " + call.minutes + " minutes");
      }
    }
  }
}
