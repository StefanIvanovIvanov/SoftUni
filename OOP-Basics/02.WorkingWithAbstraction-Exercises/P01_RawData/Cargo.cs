using System;
using System.Collections.Generic;
using System.Text;


    public class Cargo
    {
        private int cargoWeigth;
        private string cargoType;

        public int CargoWeigth
        {
        get { return cargoWeigth; }
        set { cargoWeigth = value; }
        }

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

        public Cargo(int weigth, string type)
        {
            this.CargoWeigth = weigth;
            this.CargoType = type;
        }
}

