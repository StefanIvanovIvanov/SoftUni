using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class HarvesterConstroller:IHarvesterController
    {

        private IHarvesterFactory factory;
        private List<IHarvester> harvesters;
        private IEnergyRepository energyRepository;
    public HarvesterConstroller(IEnergyRepository energyRepository)
    {
        this.energyRepository = energyRepository;
        this.factory = new HarvesterFactory();
        this.harvesters=new List<IHarvester>();
    }



        public string Register(IList<string> args)
        {
            var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

            return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
        }

        public string Produce()
        {
            throw new NotImplementedException();
        }

        public double OreProduced { get; }
        public string ChangeMode(string mode)
    {
        int persents = 100;
        switch (mode)
        {
            case "Energy":
                persents = 20;
                break;
            case "Half":
                persents = 50;
                break;
        }

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var h in this.harvesters)
        {
            try
            {
                var harvester = (Harvester)h;
                harvester.ChangeMode(persents);
                h.Broke();
            }
            catch (Exception)
            {
                reminder.Add(h);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }
    }

