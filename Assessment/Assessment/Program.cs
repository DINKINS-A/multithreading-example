using Assessment;

internal class Program
{

    private static void Main(string[] args)
    {
        scenario01();
        scenario02();
        scenario03();
    }

    private static void scenario01 ()
    {
        Scenario scenario01 = new(10, 10);
        scenario01.Run();
        Console.WriteLine($"""
                SCENARIO 01
                =============================================
                NUMBER OF ROOMS: {scenario01.TotalNumberOfRooms}

                TOTAL NUMBER OF CUSTOMERS: {Scenario.NumberOfCustomers}

                TOTAL NUMBER OF CLOTHING ITEMS: {Scenario.TotalNumberOfClothingItems}

                AVERAGE NUMBER OF CLOTHING ITEMS PER CUSTOMER: {Scenario.TotalNumberOfClothingItems / Scenario.NumberOfCustomers}

                TOTAL ROOM USAGE TIME: {Scenario.TotalRoomUsageTime}

                AVERAGE ROOM USAGE TIME PER CUSTOMER: {Scenario.TotalRoomUsageTime / 10}

                TOTAL TIME SPENT WAITING FOR A ROOM: {Scenario.TotalWaitTime}

                AVERAGE TIME SPENT WATING FOR A ROOM: {Scenario.TotalWaitTime / Scenario.NumberOfCustomers}
                """);
    }

    private static void scenario02()
    {
        Scenario scenario02 = new(10, 20);
        Console.WriteLine("SCENARIO 02");
        scenario02.Run();
        Console.WriteLine($"""
                SCENARIO 02
                =============================================
                NUMBER OF ROOMS: {scenario02.TotalNumberOfRooms}

                TOTAL NUMBER OF CUSTOMERS: {Scenario.NumberOfCustomers}

                TOTAL NUMBER OF CLOTHING ITEMS: {Scenario.TotalNumberOfClothingItems}

                AVERAGE NUMBER OF CLOTHING ITEMS PER CUSTOMER: {Scenario.TotalNumberOfClothingItems / Scenario.NumberOfCustomers}

                TOTAL ROOM USAGE TIME: {Scenario.TotalRoomUsageTime}

                AVERAGE ROOM USAGE TIME PER CUSTOMER: {Scenario.TotalRoomUsageTime / 10}

                TOTAL TIME SPENT WAITING FOR A ROOM: {Scenario.TotalWaitTime}

                AVERAGE TIME SPENT WATING FOR A ROOM: {Scenario.TotalWaitTime / Scenario.NumberOfCustomers}
                """);
    }

    private static void scenario03()
    {
        Scenario scenario03 = new(10, 30);
        Console.WriteLine("SCENARIO 03");
        scenario03.Run();
        Console.WriteLine($"""
                SCENARIO 03
                =============================================
                NUMBER OF ROOMS: {scenario03.TotalNumberOfRooms}

                TOTAL NUMBER OF CUSTOMERS: {Scenario.NumberOfCustomers}

                TOTAL NUMBER OF CLOTHING ITEMS: {Scenario.TotalNumberOfClothingItems}

                AVERAGE NUMBER OF CLOTHING ITEMS PER CUSTOMER: {Scenario.TotalNumberOfClothingItems / Scenario.NumberOfCustomers}

                TOTAL ROOM USAGE TIME: {Scenario.TotalRoomUsageTime}

                AVERAGE ROOM USAGE TIME PER CUSTOMER: {Scenario.TotalRoomUsageTime / 10}

                TOTAL TIME SPENT WAITING FOR A ROOM: {Scenario.TotalWaitTime}

                AVERAGE TIME SPENT WATING FOR A ROOM: {Scenario.TotalWaitTime / Scenario.NumberOfCustomers}
                """);
    }
}