namespace ConsoleApp1;

public class IsPalindromeSln
{
    // See https://aka.ms/new-console-template for more information
    public void Main()
    {
        Console.WriteLine("Hello, World!");

        Int32 input = 123343321;
        var output = IsPalindrome(input);
        Console.WriteLine($"Is {input} palindrome? {output}.");
    }

    public static bool IsPalindrome(Int32 x)
    {
        if (x < 0)
            return false;
        if (x % 10 == 0 && x != 0)
            return false; // all cases like 10, 120, 200, etc.

        // Using Queue is good However, it's not efficient.
        // var reserve = BuildReserve(x);
        // return reverse == x;

        var reverse = 0;
        while (x > reverse)
        {
            reverse = reverse * 10 + x % 10;
            x /= 10;
            Console.WriteLine($"x now is {x}.");
        }

        // Due to we only need to make sure the 2nd half is same as the 1st half, don't need to reverse whole number.
        // Therefore, for the odd number length Int, we need to divide it by 10 cuz middle number always palindrome.
        return reverse == x || x == reverse / 10;
    }


    int BuildReserve(int inputInt)
    {
        var queue = new Queue<int>();
        var clone = inputInt;

        while (clone != 0)
        {
            var num = clone % 10;
            clone = clone / 10;
            queue.Enqueue(num);
        }


        var result = 0;
        while (queue.TryDequeue(out var num))
        {
            result = result * 10 + num;
        }

        return result;
    }


// below is another even faster solution. 
// bool IsPalindrome(int x) {
//         
//     if((x < Math.Pow(-2,31)) || (x > (Math.Pow(2,31)-1)))
//         return false;
//             
//     if(x < 0)
//         return false;
//         
//             
//     int[] digits = digitArr(x);
//         
//     int left = 0;
//     int mid = 0;
//     int right = digits.Length - 1;
//         
//     if (digits.Length % 2 == 0){
//         for(int i = 0; i <= digits.Length / 2 - 1; i ++){
//             if(digits[i] != digits[right-i]){
//                 return false;
//             }
//         }  
//     }
//     else{
//         for(int i = 0; i <= digits.Length / 2; i ++){
//             if(digits[i] != digits[right-i]){
//                 return false;
//             }
//         }
//     }
//         
//     return true;
// }
//     
// static int[] digitArr(int n)
// {
//     if (n == 0) return new int[1] { 0 };
//
//     var digits = new List<int>();
//
//     for (; n != 0; n /= 10)
//         digits.Add(n % 10);
//
//     var arr = digits.ToArray();
//     Array.Reverse(arr);
//     return arr;
// }
}