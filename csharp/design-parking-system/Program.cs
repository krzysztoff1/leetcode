namespace ParkingSystem
{
    class ParkingSystem
    {
        private int[] cars;
        public ParkingSystem(int big, int medium, int small)
        {
            cars = new int[] { big, medium, small };
        }

        public bool AddCar(int carType)
        {
            if (cars[carType - 1] > 0)
            {
                cars[carType - 1]--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Test
    {
        public static void Main()
        {
            ParkingSystem obj = new ParkingSystem(1, 1, 0);

            Console.WriteLine($"1: {obj.AddCar(1)}");
            Console.WriteLine($"1: {obj.AddCar(2)}");
            Console.WriteLine($"1: {obj.AddCar(3)}");
            Console.WriteLine($"1: {obj.AddCar(1)}");
        }
    }
}
