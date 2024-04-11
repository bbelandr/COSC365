/// SAMPLE CODE A - Parallel Programming
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
namespace ParallelLoops
{
  class Program
  {
    static void Main(string[] args)
    {
      // Stopwatch object is defined here and used to measure the execution times of all loops.
      Stopwatch sw = new Stopwatch();

      // Standard for loop iteration
      sw.Start();
      for (int n = 0; n < 10; n++)
      {
        string converted = n.ToString();
      }
      Console.WriteLine($"Standard for loop takes {sw.ElapsedMilliseconds} milliseconds");
      // Parallel For loop iteration
      sw.Restart();
      Parallel.For(0, 100, n=> {
        string converted = n.ToString();
      });
      Console.WriteLine($"Parallel For loop takes {sw.ElapsedMilliseconds} milliseconds");
    }
  }
}



// /// SAMPLE CODE B - Parallel Programming
// using System;
// using System.Collections.Generic;
// using System.Collections.Concurrent;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// class Program
// {
//     static void Main()
//     {
//         var numbers = Enumerable.Range(2, 10).ToList();
//         var primeNumbersConcurrent = GetPrimeNumbersConcurrent(numbers);
//         Console.WriteLine($"Concurrent: {string.Join(",", primeNumbersConcurrent.Keys)}");
//         var primeNumbersParallel = GetPrimeNumbersParallel(numbers);
//         Console.WriteLine($"Parallel: {string.Join(",", primeNumbersParallel.Keys)}");
//     }
//     private static bool IsPrime(int number)
//     {
//         if (number <= 1) return false;
//         if (number == 2) return true;
//         if (number % 2 == 0) return false;
//         int boundary = (int)Math.Floor(Math.Sqrt(number));
//         for (int i = 3; i <= boundary; i += 2)
//         {
//             if (number % i == 0) return false;
//         }
//         return true;
//     }
//     private static Dictionary<int, int> GetPrimeNumbersConcurrent(IList<int> numbers)
//     {
//         var primes = new Dictionary<int, int>();
//         foreach (var number in numbers)
//         {
//             if (IsPrime(number))
//             {
//                 primes.Add(number, Thread.CurrentThread.ManagedThreadId);
//             }
//         }
//         return primes;
//     }
//     private static Dictionary<int, int> GetPrimeNumbersParallel(IList<int> numbers)
//     {
//         var primes = new ConcurrentDictionary<int, int>();
//         Parallel.ForEach(numbers, number =>
//         {
//             if (IsPrime(number))
//             {
//                 primes.TryAdd(number, Thread.CurrentThread.ManagedThreadId);
//             }
//         });
//         return primes.ToDictionary(kv => kv.Key, kv => kv.Value);
//     }
// }


// /// SAMPLE CODE C - Parallel Programming
// using System;
// using System.Diagnostics;
// using System.Threading.Tasks;
// class Program
// {
//     public static int HeavyComputation(string name)
//     {
//         Console.WriteLine("Start: " + name);
//         var timer = new Stopwatch();
//         timer.Start();
//         var result = 0;
//         for (var i = 0; i < 10_000_000; i++)
//         {
//             var a = ((i + 1_500) / (i + 30)) * (i + 10);
//             result += (a % 10) - 120;
//         }
//         timer.Stop();
//         Console.WriteLine("End: " + name + ' ' + timer.ElapsedMilliseconds);
//         return result;
//     }
//     // static void Main()
//     // {
//     //     var timer = new Stopwatch();
//     //     timer.Start();
//     //     // Start all heavy computations concurrently
//     //     HeavyComputation("A");
//     //     HeavyComputation("B");
//     //     HeavyComputation("C");
//     //     HeavyComputation("D");
//     //     HeavyComputation("E");
//     //     // // Wait for all tasks to complete
//     //     // await Task.WhenAll(taskA, taskB, taskC, taskD, taskE);
//     //     timer.Stop();
//     //     Console.WriteLine("All: " + timer.ElapsedMilliseconds); //All >= A + B + C + D + E.
//     // }

//     static void Main()
//     {
//         var timer = new Stopwatch();
//         timer.Start();
//         Parallel.Invoke(
//             () => HeavyComputation("A"),
//             () => HeavyComputation("B"),
//             () => HeavyComputation("C"),
//             () => HeavyComputation("D"),
//             () => HeavyComputation("E")
//         );
//         timer.Stop();
//         Console.WriteLine("All: " + timer.ElapsedMilliseconds);
//     }
// }


// /// SAMPLE CODE D - Asynchronous Programming
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Diagnostics;
// namespace AsyncProgramming
// {
//     class AsyncAwait
//     {
//         static void Main(string[] args)
//         {
//             Method1();
//             Method2();
//         }
//         public static async Task Method1()
//         {
//             await Task.Run(()=>{
//                 for(int i = 0; i<100; i++)
//                 {
//                     Console.WriteLine("Method1 is running");
//                     Task.Delay(100).Wait();
//                 }
//             });
//         }
//         public static void Method2()
//         {
//             for(int i = 0; i<25; i++)
//                 {
//                     Console.WriteLine("Method2 is running");
//                     Task.Delay(100).Wait();
//                 }
//         }
//     }
// }