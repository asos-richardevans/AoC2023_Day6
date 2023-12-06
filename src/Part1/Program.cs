var input = File.ReadAllLines("./input.txt");
//input[0] = "Time:      7  15   30";
//input[1] = "Distance:  9  40  200";
var timeLine = input[0].Split(':');
var times = timeLine[1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray(); ;

var distanceLine = input[1].Split(':');
var distances =  distanceLine[1].Trim().Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToArray(); ;

var races = new List<(int, int)>();
for (int i = 0; i < times.Length; i++)
{
    races.Add((int.Parse(times[i]), int.Parse(distances[i])));
}

var marginOfErrors = new List<int>();
foreach (var race in races)
{
    var lowestTimeHeld = int.MinValue;
    for (int i = 0; i <= race.Item1/2; i++)
    {
        if (GetDistance(i, race.Item1 - i) > race.Item2)
        {
            lowestTimeHeld = i;
            break;
        }
    }
    marginOfErrors.Add(race.Item1 - lowestTimeHeld + 1 - lowestTimeHeld);
}

int GetDistance(int buttonHeld, int timeRemaining)
{
    return buttonHeld * timeRemaining;
}

Console.WriteLine(marginOfErrors.Aggregate(1, (acc, val) => acc * val));