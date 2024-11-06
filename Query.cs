using System;

namespace Scraper
{
    internal class Query
    {
        public int ID
        {
            get;
            set;
        }

        public string OurTypes
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }

        public string Types
        {
            get;
            set;
        }

        public string Vehicle
        {
            get;
            set;
        }

        public Query(string rawVehicle, int passengers)
        {
            int num;
            int num1;
            string str;
            Console.WriteLine(rawVehicle);
            VehicleMatcher vehicleMatcher = new VehicleMatcher();
            if (vehicleMatcher.Vehicles.ContainsKey(rawVehicle))
            {
                this.Vehicle = rawVehicle;
                if (vehicleMatcher.Vehicles.TryGetValue(rawVehicle, out num1))
                {
                    this.ID = num1;
                }
                if (vehicleMatcher.Pricing.TryGetValue(this.ID, out num))
                {
                    this.Price = (double)num;
                }
                if (vehicleMatcher.Types.TryGetValue(this.ID, out str))
                {
                    this.Types = str;
                }
                string[] strArrays = this.Types.Split(new char[] { '-' });
                if (strArrays[0] == "x")
                {
                    if (passengers < 4)
                    {
                        this.OurTypes = "Sedan";
                    }
                }
                if (strArrays[1] == "x")
                {
                    if ((passengers > 6 ? 0 : Convert.ToInt32(passengers > 4)) != 0)
                    {
                        this.OurTypes = "SUV";
                    }
                }
                if (strArrays[2] == "x")
                {
                    if ((passengers > 10 ? 0 : Convert.ToInt32(passengers > 6)) != 0)
                    {
                        this.OurTypes = "Stretch Limo";
                    }
                }
                if (strArrays[3] == "x")
                {
                    if ((passengers > 20 ? 0 : Convert.ToInt32(passengers > 10)) != 0)
                    {
                        this.OurTypes = "Stretch SUV";
                    }
                }
                if (strArrays[4] == "x")
                {
                    if ((passengers > 50 ? 0 : Convert.ToInt32(passengers > 4)) != 0)
                    {
                        this.OurTypes = "Party Bus";
                    }
                }
                if (strArrays[5] == "x")
                {
                    if ((passengers > 12 ? 0 : Convert.ToInt32(passengers > 1)) != 0)
                    {
                        this.OurTypes = "Van";
                    }
                }
                if (strArrays[6] == "x")
                {
                    if ((passengers > 61 ? 0 : Convert.ToInt32(passengers > 50)) != 0)
                    {
                        this.OurTypes = "Motor Coach";
                    }
                }
                if (strArrays[7] == "x")
                {
                    if ((passengers > 40 ? 0 : Convert.ToInt32(passengers > 1)) != 0)
                    {
                        this.OurTypes = "Mini Bus";
                    }
                }
                if (strArrays[8] == "x")
                {
                    if ((passengers > 20 ? 0 : Convert.ToInt32(passengers > 1)) != 0)
                    {
                        this.OurTypes = "Entertainer Sleeper";
                    }
                }
                if (strArrays[9] == "x")
                {
                    if ((passengers > 61 ? 0 : Convert.ToInt32(passengers > 50)) != 0)
                    {
                        this.OurTypes = "Executive Coach";
                    }
                }
                if (strArrays[10] == "x")
                {
                    if ((passengers > 73 ? 0 : Convert.ToInt32(passengers > 1)) != 0)
                    {
                        this.OurTypes = "School Bus";
                    }
                }
                if (strArrays[11] == "x")
                {
                    if ((passengers > 30 ? 0 : Convert.ToInt32(passengers > 1)) != 0)
                    {
                        this.OurTypes = "Trolley";
                    }
                }
                if (strArrays[12] == "x")
                {
                    if ((passengers > 80 ? 0 : Convert.ToInt32(passengers > 1)) != 0)
                    {
                        this.OurTypes = "Double Decker";
                    }
                }
                if (strArrays[13] == "x")
                {
                    if (passengers <= 2)
                    {
                        this.OurTypes = "Vintage / Antique";
                    }
                }
                if (strArrays[14] == "x")
                {
                    this.OurTypes = "Other";
                }
            }
            else if (rawVehicle.Contains("Any Vehicle"))
            {
                this.Vehicle = rawVehicle;
                Console.WriteLine(this.Vehicle);
                if ((passengers > 13 ? 0 : Convert.ToInt32(passengers > 10)) != 0)
                {
                    this.Price = 125;
                }
                else if (passengers <= 18)
                {
                    this.Price = 135;
                }
                else if (passengers <= 23)
                {
                    this.Price = 150;
                }
                else if (passengers <= 60)
                {
                    this.Price = 175;
                }
                else if (passengers > 60)
                {
                    this.Price = 200;
                }
            }
        }
    }
}