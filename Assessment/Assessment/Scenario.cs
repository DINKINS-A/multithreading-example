using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assessment
{
    internal class Scenario
    {
        #region Private Fields

        private readonly DressingRooms m_rooms;
        private Task[] m_tasks;

        #endregion

        #region Public Fields
        public static int NumberOfCustomers = 0;
        public static volatile int TotalRoomUsageTime = 0;
        public static volatile int TotalWaitTime = 0;
        public static volatile int TotalNumberOfClothingItems = 0;

        public int TotalNumberOfRooms = 0;

        #endregion

        #region Constructors

        public Scenario(int initial_number_of_customers) 
        { 
            NumberOfCustomers = initial_number_of_customers;
            m_rooms = new DressingRooms();
            TotalNumberOfRooms = m_rooms.GetRoomCount();

            TotalRoomUsageTime = 0;
            TotalWaitTime = 0;
            TotalNumberOfClothingItems = 0;

            m_tasks = new Task[NumberOfCustomers];
        }

        public Scenario(int initial_rooms_available, int initial_number_of_customers)
        {
            NumberOfCustomers = initial_number_of_customers;
            m_rooms = new DressingRooms(initial_rooms_available);
            TotalNumberOfRooms = initial_rooms_available;

            TotalRoomUsageTime = 0;
            TotalWaitTime = 0;
            TotalNumberOfClothingItems = 0;

            m_tasks = new Task[NumberOfCustomers];
        }

        #endregion

        #region Methods

        public void Run()
        {

            // Simulate customers queing to use dressing rooms
            for (int customers_left = NumberOfCustomers; customers_left > 0; customers_left--)
            {
                Customer customer = new Customer();
                TotalNumberOfClothingItems += customer.ClothingItems;
                var task = Task.Factory.StartNew(() =>
                {
                    // Let a customer into a room
                    UseDressingRoom(customer.ClothingItems);
                });

                m_tasks[customers_left - 1] = task;
            }

            

            Task.WaitAll(m_tasks);

        }

        public static void UseDressingRoom(int item_count)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            // Wait for a dressing room to open
            DressingRooms.RequestRoom();

            // Record the wait time
            
            TotalWaitTime += (int)(stopwatch.ElapsedMilliseconds);

            
            stopwatch.Restart();

            // Simulate trying on clothes for 1-3 minutes 
            Console.WriteLine($"Next customer is using a room...");
            for (; item_count > 0; item_count--)
            {
                Thread.Sleep(new Random().Next(60000, 1800001));
            }
            Console.WriteLine($"A customer is done.");

            // Record how long the room was used.
            TotalRoomUsageTime += (int)(stopwatch.ElapsedMilliseconds / 1000); // convert to seconds

            // Simulate the room becoming available
            DressingRooms.VacateRoom();
        }

        #endregion
    }
}
