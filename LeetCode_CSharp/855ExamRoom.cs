namespace LeetCode.CSharp;

public class ExamRoomC
{
    public void Test()
    {
        var room = new ExamRoom(10);
        Console.WriteLine($"new Seat is {room.Seat()}.");
        Console.WriteLine($"new Seat is {room.Seat()}.");
        Console.WriteLine($"new Seat is {room.Seat()}.");
        Console.WriteLine($"new Seat is {room.Seat()}.");
        Console.WriteLine($"4 now leave.");
        room.Leave(4);
        Console.WriteLine($"new Seat is {room.Seat()}.");
    }
}

public class ExamRoom
{
    /**
 * Your ExamRoom object will be instantiated and called as such:
 * ExamRoom obj = new ExamRoom(n);
 * int param_1 = obj.Seat();
 * obj.Leave(p);
 */

    public List<int> SeatList  = new();

    private int maxCap;

    public ExamRoom(int n)
    {
        maxCap = n;
    }

    /// <summary>
    /// This method will return the seat the new student should sit on.
    /// Underneath it's looking for the biggest gap between each students and return the mid.
    /// </summary>
    /// <returns></returns>
    public int Seat()
    {
        var newSeat = 0;
        if (SeatList.Count == 0)
        {
            SeatList.Add(newSeat);
            return newSeat;
        }

        if (SeatList.Count == 1)
        {
            newSeat =  SeatList.First() < maxCap / 2 ? maxCap - 1 : 0;
            SeatList.Add(newSeat);
            return newSeat;
        }


        int left = 0, right = 1, gap = 0, maxGap = 0;
        for (int i = 1; i < SeatList.Count; i++)
        {
            gap = SeatList[i] - SeatList[i - 1];
            if (maxGap < gap)
            {
                maxGap = gap;
                left = SeatList[i - 1];
                right = SeatList[i];
            }
        }
        

        newSeat = right - (maxGap / 2) - 1;

        SeatList.Add(newSeat);

        SeatList = SeatList.OrderBy(t => t).ToList();
        return newSeat;
    }

    public void Leave(int p)
    {
        SeatList = SeatList.Where(t => t != p).ToList();
    }
}