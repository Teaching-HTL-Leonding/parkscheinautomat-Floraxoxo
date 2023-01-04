int minutes = 0, hours = 0;
decimal money = 0, donation = 0;
string coins = "";

void PrintWelcome()
{
    Console.WriteLine("Welcome to ParkingSimulator!");
    Console.WriteLine("This program will calculate your parking time depending on the money you spend");
    Console.WriteLine("But there are also some rules:");
    Console.WriteLine("You have to park at least 30min and maximum 1h and 30min");
    Console.WriteLine("You are also only allowed to enter [5] Cents, [10] Cents, [20] Cents, [50] Cents, [1] Euro & [2] Euro");
    Console.WriteLine("If you enter [d] or [D] your check will be printed");
}
void EnterCoins()
{
    Console.WriteLine("Please enter the amount of coins you want to spend");
    coins = Console.ReadLine()!.ToLower();
}
void AddParkingTime()
{
    if (hours < 1 && minutes < 30)
    {
        switch (coins)
        {
            case "5":
                minutes += 3;
                money += 0.05m;
                break;
            case "10":
                minutes += 6;
                money += 0.10m;
                break;
            case "20":
                minutes += 12;
                money += 0.20m;
                break;
            case "50":
                minutes += 30;
                money += 0.50m;
                break;
            case "1":
                hours++;
                money++;
                break;
            case "2":
                hours++;
                minutes += 30; donation += 0.3m;
                money += 1.3m;
                break;
            default:
                break;
        }
    }
    else
    {
        hours = 1; minutes = 30;
        money -= 1.3m; donation += money;
        money = 1.3m;
    }
}
void PrintParkingTime()
{
    if (minutes >= 60)
    {
        hours++;
        minutes -= 60;
    }
    Console.WriteLine($"Parking time: {hours}:{minutes} hours");
}
void PrintDonation()
{
    if (money == 1.3m || coins == "d")
    {
        donation += (money - 1.30m);
        Console.WriteLine($"You are allowed to park: {hours}:{minutes} you donated: {donation}");
    }
}

PrintWelcome();
do
{
    EnterCoins();
    AddParkingTime();
    PrintParkingTime();
    if (minutes >= 30 || hours >= 1)
    {
        PrintDonation();
        return;
    }
} while (coins != "d");