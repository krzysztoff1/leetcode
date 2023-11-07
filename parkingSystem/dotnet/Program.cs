namespace ParkingSystem
{
    class ParkingSystem
    {
        private int big;
        private int medium;
        private int small;

        public ParkingSystem(int _big, int _medium, int _small)
        {
            big = _big;
            medium = _medium;
            small = _small;
        }

        public bool AddCar(int carType)
        {
            switch (carType)
            {
                case 1:
                    {
                        if (big > 0)
                        {
                            big--;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                        break;
                    }
                case 2:
                    {
                        if (medium > 0)
                        {
                            medium--;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                        break;
                    }
                case 3:
                    {
                        if (small > 0)
                        {
                            small--;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                        break;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }

    class Test
    {
        public static void Main()
        {
            Console.WriteLine("Hello");

            ParkingSystem obj = new ParkingSystem(1, 1, 0);

            Console.WriteLine($"1: {obj.AddCar(1)}");
            Console.WriteLine($"1: {obj.AddCar(2)}");
            Console.WriteLine($"1: {obj.AddCar(3)}");
            Console.WriteLine($"1: {obj.AddCar(1)}");
        }
    }
}
