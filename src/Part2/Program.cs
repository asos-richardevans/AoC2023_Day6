var input = File.ReadAllLines("./input.txt");
var timeLine = input[0].Split(':');
var time = int.Parse(timeLine[1].Trim().Replace(" ", string.Empty)); ;
var distanceLine = input[1].Split(':');
long distance = long.Parse(distanceLine[1].Trim().Replace(" ", string.Empty));
var lowestTimeHeld = long.MinValue;
for (long i = 0; i <= time / 2; i++)
{
    if (GetDistance(i,time - i) > distance)
    {
        lowestTimeHeld = i;
        break;
    }
}
Console.WriteLine(time - lowestTimeHeld + 1 - lowestTimeHeld);

long GetDistance(long buttonHeld, long timeRemaining)
{
    return buttonHeld * timeRemaining;
}