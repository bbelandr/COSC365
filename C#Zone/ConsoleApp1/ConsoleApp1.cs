// Benjamin Belandres, bbelandr, 4/8/2024
// Times:
    // SAMPLE CODE A
        // Standard:    1088  milliseconds
        // Parallel:    522 milliseconds
    // SAMPLE CODE B
        // Concurrent:  1090  milliseconds
        // Parallel:    1064 milliseconds


// /// SAMPLE CODE A - Parallel Programming
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.IO;
// using System.Linq;
// using System.Text;
// using System.Net;
// using System.Threading;
// using System.Threading.Tasks;
// namespace ParallelLoops
// {
//   class Program
//   {
//     static void Main(string[] args)
//     {
//       // Stopwatch object is defined here and used to measure the execution times of all loops.
//       Stopwatch sw = new Stopwatch();

//       // Standard for loop iteration
//       var numbers = Enumerable.Range(0, 10).ToList();

//       sw.Start();
//       foreach (int n in numbers) {
//         Thread.Sleep(100);
//         string converted = n.ToString();
//         // Console.WriteLine(converted);    // Just to see what is happening
//       }
//       Console.WriteLine($"Standard for loop takes {sw.ElapsedMilliseconds} milliseconds");
//       sw.Restart();
      
//       // Parallel For loop iteration
//       numbers = Enumerable.Range(0, 100).ToList();
//       sw.Start();
//       Parallel.ForEach(numbers, (n) => {
//         Thread.Sleep(100);
//         string converted = n.ToString();
//         // Console.WriteLine(converted);
//       });
//       Console.WriteLine($"Parallel For loop takes {sw.ElapsedMilliseconds} milliseconds");
//     }
//   }
// }
// Standard:    1088  milliseconds
// Parallel:    522 milliseconds
// The parallel version is faster because the tasks took long enough 
// to run that the overhead of starting the tasks in parallel was 
// less than the time saved by running the tasks.



// /// SAMPLE CODE B - Parallel Programming
// using System;
// using System.Collections.Generic;
// using System.Collections.Concurrent;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Diagnostics;
// class Program
// {
//     static void Main()
//     {
//         var numbers = Enumerable.Range(2, 10).ToList();
//         Stopwatch sw = new Stopwatch();
//         sw.Start();
//         var primeNumbersConcurrent = GetPrimeNumbersConcurrent(numbers);
//         Console.WriteLine($"Concurrent: {string.Join(",", primeNumbersConcurrent.Keys)}. Milliseconds = {sw.ElapsedMilliseconds}");
//         sw.Reset();
//         sw.Start();
//         var primeNumbersParallel = GetPrimeNumbersParallel(numbers);
//         Console.WriteLine($"Parallel: {string.Join(",", primeNumbersParallel.Keys)}. Milliseconds = {sw.ElapsedMilliseconds}");
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
//             Thread.Sleep(100);
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
//             Thread.Sleep(1000);
//             if (IsPrime(number))
//             {
//                 primes.TryAdd(number, Thread.CurrentThread.ManagedThreadId);
//             }
//         });
//         return primes.ToDictionary(kv => kv.Key, kv => kv.Value);
//     }
// }
// Concurrent Time = 1090  milliseconds
// Parallel Time = 1064 milliseconds
// The parallel version is faster because the tasks took long enough 
// to run that the overhead of starting the tasks in parallel was 
// less than the time saved by running the tasks.



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
//         // Linear
//         HeavyComputation("A");
//         HeavyComputation("B");
//         HeavyComputation("C");
//         HeavyComputation("D");
//         HeavyComputation("E");
//         Console.WriteLine("All: " + timer.ElapsedMilliseconds); 
//         timer.Reset();


//         // Parallel
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
// Linear Time = 141
// Parallel Time = 61
// The parallel version is faster because the tasks took long enough 
// to run that the overhead of starting the tasks in parallel was 
// less than the time saved by running the tasks.


/// SAMPLE CODE D - Asynchronous Programming
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
//         static async void Main(string[] args)
//         {
//             Stopwatch sw = new Stopwatch();
//             sw.Start();
//             Method1();
//             Method2();

            
//             Console.WriteLine("Total Time = " + sw.ElapsedMilliseconds);
//         }
//         public static async Task Method1()
//         {
//             Stopwatch sw = new Stopwatch();
//             sw.Start();
//             await Task.Run(()=>{
//                 for(int i = 0; i<100; i++)
//                 {
//                     Console.WriteLine("Method1 is running");
//                     Thread.Sleep(100);
//                     // Task.Delay(100).Wait();
//                 }
//             });
//             sw.Stop();
//             Console.WriteLine("Method1 Time = " + sw.ElapsedMilliseconds);
//         }
//         public static void Method2()
//         {
//             Stopwatch sw = new Stopwatch();
//             sw.Start();
//             for(int i = 0; i<25; i++)
//             {
//                 Console.WriteLine("Method2 is running");
//                 Thread.Sleep(100);
//                 // Task.Delay(100).Wait();
//             }
//             sw.Stop();
//             Console.WriteLine("Method2 Time = " + sw.ElapsedMilliseconds);

//         }
//     }
// }
// Method1 Time = 23
// Method2 Time = 2736
// Method1 is much faster because dividing the tasks into separate threads 
// eliminates the problem of having to wait for the completion of the first
// task before starting the second task.