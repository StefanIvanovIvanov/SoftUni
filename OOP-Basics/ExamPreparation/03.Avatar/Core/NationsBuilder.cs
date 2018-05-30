using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NationsBuilder
{
    List<Bender> fireNation = new List<Bender>();
    List<Bender> waterNation = new List<Bender>();
    List<Bender> airNation = new List<Bender>();
    List<Bender> earthNation = new List<Bender>();

    List<Monument> fireMonuments = new List<Monument>();
    List<Monument> waterMonuments = new List<Monument>();
    List<Monument> airMonuments = new List<Monument>();
    List<Monument> earthMonuments = new List<Monument>();

    List<string>warRecords=new List<string>();


    public void AssignBender(List<string> benderArgs)
    {
        Bender bender = BenderFactory.Create(benderArgs);
        string type = benderArgs[1];

        if (type == "Air")
        {
            airNation.Add(bender);
        }
        else if (type == "Water")
        {
            waterNation.Add(bender);
        }
        else if (type == "Fire")
        {
            fireNation.Add(bender);
        }
        else if (type == "Earth")
        {
            earthNation.Add(bender);
        }
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        Monument monument = MonumentFactory.Create(monumentArgs);
        string type = monumentArgs[1];

        if (type == "Air")
        {
            airMonuments.Add(monument);
        }
        else if (type == "Water")
        {
            waterMonuments.Add(monument);
        }
        else if (type == "Fire")
        {
            fireMonuments.Add(monument);
        }
        else if (type == "Earth")
        {
            earthMonuments.Add(monument);
        }

    }
    public string GetStatus(string nationsType)
    {
        StringBuilder sb=new StringBuilder();

        switch (nationsType)
        {
            case "Air":
                sb.AppendLine("Air Nation");               
                if (airNation.Count == 0)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var bender in airNation)
                    {
                        sb.AppendLine(bender.ToString());
                    }               
                }
                if (airMonuments.Count == 0)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var monument in airMonuments)
                    {
                        sb.AppendLine(monument.ToString());
                    }
                }
                break;
            case "Fire":
                sb.AppendLine("Fire Nation");
                if (fireNation.Count == 0)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var bender in fireNation)
                    {                     
                        sb.AppendLine(bender.ToString());
                    }                   
                }
                if (fireMonuments.Count == 0)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var monument in fireMonuments)
                    {
                        sb.AppendLine(monument.ToString());
                    }
                }
                break;
            case "Water":
                sb.AppendLine("Water Nation");
                if (airNation.Count == 0)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var bender in waterNation)
                    {
                        sb.AppendLine(bender.ToString());
                    }      
                }
                if (waterMonuments.Count == 0)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var monument in waterMonuments)
                    {
                        sb.AppendLine(monument.ToString());
                    }
                }
                break;
            case "Earth":
                sb.AppendLine("Earth Nation");
                if (airNation.Count == 0)
                {
                    sb.AppendLine("Benders: None");
                }
                else
                {
                    sb.AppendLine("Benders:");
                    foreach (var bender in earthNation)
                    {
                        sb.AppendLine(bender.ToString());
                    }                  
                }
                if (earthMonuments.Count == 0)
                {
                    sb.AppendLine("Monuments: None");
                }
                else
                {
                    sb.AppendLine("Monuments:");
                    foreach (var monument in earthMonuments)
                    {
                        sb.AppendLine(monument.ToString());
                    }
                }
                break;
            default:
                throw new ArgumentException("No such nation");
                break;
        }
        return sb.ToString().Trim();
    }
    public void IssueWar(string nationsType)
    {
        warRecords.Add(nationsType);


        var airNationPower = this.airNation.Sum(b => b.TotalPower);
        var airMonumentsPower = this.airMonuments.Sum(m => m.Affinity);
        var tap = airNationPower + airNationPower * airMonumentsPower / 100;

        var waterNationPower = this.waterNation.Sum(b => b.TotalPower);
        var waterMonumentsPower = this.waterMonuments.Sum(m => m.Affinity);
        var twp = waterNationPower + waterNationPower * waterMonumentsPower / 100;

        var fireNationPower = this.fireNation.Sum(b => b.TotalPower);
        var fireMonumentsPower = this.fireMonuments.Sum(m => m.Affinity);
        var tfp = fireNationPower + fireNationPower * fireMonumentsPower / 100;

        var earthNationPower = this.earthNation.Sum(b => b.TotalPower);
        var earthMonumentsPower = this.earthMonuments.Sum(m => m.Affinity);
        var tep = earthNationPower + earthNationPower * earthMonumentsPower / 100;

        if (tap > twp && tap > tfp && tap > tep)
        {
            this.waterNation.Clear();
            this.waterMonuments.Clear();
            this.fireNation.Clear();
            this.fireMonuments.Clear();
            this.earthNation.Clear();
            this.earthMonuments.Clear();
        }
        else if (tap < twp && twp > tfp && twp > tep)
        {
            this.airNation.Clear();
            this.airMonuments.Clear();
            this.fireNation.Clear();
            this.fireMonuments.Clear();
            this.earthNation.Clear();
            this.earthMonuments.Clear();
        }
        else if (tfp > tap && tfp > twp && tfp > tep)
        {
            this.airNation.Clear();
            this.airMonuments.Clear();
            this.waterNation.Clear();
            this.waterMonuments.Clear();
            this.earthNation.Clear();
            this.earthMonuments.Clear();
        }
        else if (tep > tap && tep > twp && tep > tfp)
        {
            this.airNation.Clear();
            this.airMonuments.Clear();
            this.waterNation.Clear();
            this.waterMonuments.Clear();
            this.fireNation.Clear();
            this.fireMonuments.Clear();
        }

        //  double totalAirPower = airNation.Sum(p => p.TotalPower);
        //  double totalFirePower = fireNation.Sum(p => p.TotalPower);
        //  double totalWaterPower = waterNation.Sum(p => p.TotalPower);
        //  double totalEarthPower = earthNation.Sum(p => p.TotalPower);
        //
        //  double totalAirAffinity = airMonuments.Sum(a => a.Affinity);
        //  double totalFireAffinity = fireMonuments.Sum(a => a.Affinity);
        //  double totalWaterAffinity = waterMonuments.Sum(a => a.Affinity);
        //  double totalEarthAffinity = earthMonuments.Sum(a => a.Affinity);
        //
        //  double airBonus = totalAirPower+(totalAirAffinity / 100 * totalAirPower);
        // 
        //
        //  double finalAirPower = totalAirPower + ((totalAirPower / 100) * totalAirAffinity);
        //  double finalFirePower = totalFirePower + ((totalFirePower / 100) * totalFireAffinity);
        //  double finalWaterPower = totalWaterPower + ((totalWaterPower / 100) * totalWaterAffinity);
        //  double finalEarthPower = totalEarthPower + ((totalEarthPower / 100) * totalEarthAffinity);
        //
        //  double winner = Math.Max(finalAirPower, Math.Max(finalFirePower, Math.Max(finalWaterPower, finalEarthPower)));
        //
        //  if (winner == finalAirPower)
        //  {
        //      fireNation.Clear();
        //      fireMonuments.Clear();
        //      waterNation.Clear();
        //      waterMonuments.Clear();
        //      earthNation.Clear();
        //      earthMonuments.Clear();
        //  }else if (winner == finalFirePower)
        //  {
        //      airNation.Clear();
        //      airMonuments.Clear();
        //      waterNation.Clear();
        //      waterMonuments.Clear();
        //      earthNation.Clear();
        //      earthMonuments.Clear();
        //  }else if (winner == finalWaterPower)
        //  {
        //      airNation.Clear();
        //      airMonuments.Clear();
        //      fireNation.Clear();
        //      fireMonuments.Clear();
        //      earthNation.Clear();
        //      earthMonuments.Clear();
        //  }else if (winner == finalEarthPower)
        //  {
        //      airNation.Clear();
        //      airMonuments.Clear();
        //      fireNation.Clear();
        //      fireMonuments.Clear();
        //      waterNation.Clear();
        //      waterMonuments.Clear();
        //  }
        //  else
        //  {
        //      throw new ArgumentException("No winner");
        //  }
    }
    public string GetWarsRecord()
    {StringBuilder sb=new StringBuilder();
        int counter = 1;
        foreach (var nation in warRecords)
        {
            sb.AppendLine ($"War {counter++} issued by {nation}");
        }
        return sb.ToString();
    }

}

