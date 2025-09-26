using Assessment;
using System.Diagnostics;

internal class Program
{

    private static SemaphoreSlim semaphore = new SemaphoreSlim(0, 3);
    private static int padding;

    private static void Main(string[] args)
    {

        scenario01();
        scenario02();
        scenario03();

    }

    private static void scenario01 ()
    {
        Scenario scenario01 = new(10,10); // Create a scenario with 10 customers
        long total_time = 0;
        var stopwatch = Stopwatch.StartNew();
        scenario01.Run();
        stopwatch.Stop();
        total_time = stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"""
                SCENARIO 01
                =============================================
                SCENARIO RUN TIME {total_time} ms

                NUMBER OF ROOMS: {scenario01.TotalNumberOfRooms}

                TOTAL NUMBER OF CUSTOMERS: {scenario01.NumberOfCustomers}

                TOTAL NUMBER OF CLOTHING ITEMS: {scenario01.TotalNumberOfClothingItems}

                AVERAGE NUMBER OF CLOTHING ITEMS PER CUSTOMER: {scenario01.TotalNumberOfClothingItems / scenario01.NumberOfCustomers}

                TOTAL ROOM USAGE TIME: {scenario01.TotalRoomUsageTime} ms

                AVERAGE ROOM USAGE TIME PER CUSTOMER: {scenario01.TotalRoomUsageTime / scenario01.NumberOfCustomers} ms

                TOTAL TIME SPENT WAITING FOR A ROOM: {scenario01.TotalWaitTime} ms

                AVERAGE TIME SPENT WATING FOR A ROOM: {scenario01.TotalWaitTime / scenario01.NumberOfCustomers} ms
                """);
    }

    private static void scenario02()
    {
        Scenario scenario02 = new(10, 20); // Create a scenario with 20 customers
        long total_time = 0;
        var stopwatch = Stopwatch.StartNew();
        scenario02.Run();
        stopwatch.Stop();
        total_time = stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"""
                SCENARIO 02
                =============================================
                SCENARIO RUN TIME {total_time} ms

                NUMBER OF ROOMS: {scenario02.TotalNumberOfRooms}

                TOTAL NUMBER OF CUSTOMERS: {scenario02.NumberOfCustomers}

                TOTAL NUMBER OF CLOTHING ITEMS: {scenario02.TotalNumberOfClothingItems}

                AVERAGE NUMBER OF CLOTHING ITEMS PER CUSTOMER: {scenario02.TotalNumberOfClothingItems / scenario02.NumberOfCustomers} ms

                TOTAL ROOM USAGE TIME: {scenario02.TotalRoomUsageTime} ms

                AVERAGE ROOM USAGE TIME PER CUSTOMER: {scenario02.TotalRoomUsageTime / scenario02.NumberOfCustomers} ms

                TOTAL TIME SPENT WAITING FOR A ROOM: {scenario02.TotalWaitTime} ms

                AVERAGE TIME SPENT WATING FOR A ROOM: {scenario02.TotalWaitTime / scenario02.NumberOfCustomers} ms
                """);
    }

    private static void scenario03()
    {
        Scenario scenario03 = new(10, 30); // Create a scenario with 30 customers
        long total_time = 0;
        var stopwatch = Stopwatch.StartNew();
        scenario03.Run();
        stopwatch.Stop();
        total_time = stopwatch.ElapsedMilliseconds;
        Console.WriteLine($"""
                SCENARIO 03
                =============================================
                SCENARIO RUN TIME {total_time} ms

                NUMBER OF ROOMS: {scenario03.TotalNumberOfRooms}

                TOTAL NUMBER OF CUSTOMERS: {scenario03.NumberOfCustomers}

                TOTAL NUMBER OF CLOTHING ITEMS: {scenario03.TotalNumberOfClothingItems}

                AVERAGE NUMBER OF CLOTHING ITEMS PER CUSTOMER: {scenario03.TotalNumberOfClothingItems / scenario03.NumberOfCustomers}

                TOTAL ROOM USAGE TIME: {scenario03.TotalRoomUsageTime} ms

                AVERAGE ROOM USAGE TIME PER CUSTOMER: {scenario03.TotalRoomUsageTime / scenario03.NumberOfCustomers} ms

                TOTAL TIME SPENT WAITING FOR A ROOM: {scenario03.TotalWaitTime} ms

                AVERAGE TIME SPENT WATING FOR A ROOM: {scenario03.TotalWaitTime / scenario03.NumberOfCustomers} ms
                """);
    }
}