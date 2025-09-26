using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assessment
{
    internal class Scenario
    {
        #region Private Fields

        private readonly DressingRooms m_rooms;
        private Task[] m_tasks;
        private readonly int m_number_of_customers;
        private long m_total_room_usage_time;
        private long m_total_wait_time;
        private int m_total_number_of_clothing_items;

        #endregion

        #region Public Fields
        public int NumberOfCustomers {
            get
            {
                return m_number_of_customers;
            }
        }
        public long TotalRoomUsageTime
        {
            get
            {
                return m_total_room_usage_time;
            }
        }
        public long TotalWaitTime {
            get { 
                return m_total_wait_time;
            }
        }
        public int TotalNumberOfClothingItems {
            get {
                return m_total_number_of_clothing_items;
            }
        }

        public int TotalNumberOfRooms { get; private set; }

        #endregion

        #region Constructors

        public Scenario(int initial_number_of_customers) 
        { 
            m_number_of_customers = initial_number_of_customers;
            m_rooms = new DressingRooms();
            TotalNumberOfRooms = m_rooms.GetRoomCount();

            m_total_room_usage_time = 0;
            m_total_wait_time = 0;
            m_total_number_of_clothing_items = 0;

            m_tasks = new Task[NumberOfCustomers];
        }

        public Scenario(int initial_rooms_available, int initial_number_of_customers)
        {
            m_number_of_customers = initial_number_of_customers;
            m_rooms = new DressingRooms(initial_rooms_available);
            TotalNumberOfRooms = initial_rooms_available;

            m_total_room_usage_time = 0;
            m_total_wait_time = 0;
            m_total_number_of_clothing_items = 0;

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
                m_total_number_of_clothing_items += customer.ClothingItems;
                m_tasks[customers_left - 1] = Task.Run(() =>
                {
                    Console.WriteLine($"Customer {Task.CurrentId} is waiting for a room.");
                    // Let a customer into a room
                    UseDressingRoom(customer.ClothingItems);
                });
            }

            Task.WaitAll(m_tasks);

        }

        public void UseDressingRoom(int item_count)
        {
            Stopwatch wait_timer = Stopwatch.StartNew();
            // Wait for a dressing room to open
            DressingRooms.RequestRoom();
            wait_timer.Stop();
            Interlocked.Add(ref m_total_wait_time, wait_timer.ElapsedMilliseconds);
            
            // Record the wait time
            Console.WriteLine($"Customer {Task.CurrentId} enters a room.");


            // Simulate trying on clothes for 1-3 minutes
            Stopwatch usage_timer = Stopwatch.StartNew();
            for (; item_count > 0; item_count--)
            {
                Thread.Sleep(new Random().Next(6000, 18001)); // Using 6-18 seconds to simulate 60-180 seconds
            }
            usage_timer.Stop();
            Interlocked.Add(ref m_total_room_usage_time, usage_timer.ElapsedMilliseconds);
            Console.WriteLine($"Customer {Task.CurrentId} is done.");

            // Simulate the room becoming available
            DressingRooms.VacateRoom();
        }

        #endregion
    }
}
