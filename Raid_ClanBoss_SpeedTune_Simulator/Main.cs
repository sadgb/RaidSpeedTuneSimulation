using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public static class Extensions
{
    public static IEnumerable<IEnumerable<T>> Split<T>(this T[] arr, int size)
    {
        for (var i = 0; i < arr.Length / size + 1; i++)
        {
            yield return arr.Skip(i * size).Take(size);
        }
    }
}

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public partial class Simulation
    {
        static void Main(string[] args)
        {
            DateTime starting_time = DateTime.Now;
            var i = 1;
            /*
            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });
            int[] arr = Enumerable.Range(1, 100).ToArray();
            */
            for (int e = champion_5_speed_range[0]; e <= champion_5_speed_range[1]; e += search_detail)
            {
                for (float d = champion_4_speed_range[0]; d <= champion_4_speed_range[1]; d += search_detail)
                {
                    for (float c = champion_3_speed_range[0]; c <= champion_3_speed_range[1]; c += search_detail)
                    {
                        for (float b = champion_2_speed_range[0]; b <= champion_2_speed_range[1]; b += search_detail)
                        {
                            for (float a = champion_1_speed_range[0]; a <= champion_1_speed_range[1]; a += search_detail)
                            {


                                // Run ultra nightmare difficulty
                                if (Run_Simulation("unm", a, b, c, d, e))
                                {
                                    // If ultra nightmare was successful then run nightmare difficulty
                                    //if (Run_Simulation("nm", a, b, c, d, e))
                                    //{
                                    // if all tests were successful then log out message telling the speeds
                                        lowest_biggest_speed = Math.Max(Math.Max(Math.Max(Math.Max(a, b), c), d), e);
                                        lowest_total_speeds = a + b + c + d + e;
                                        lowest_total_speeds_message = "Fastest speed tuned team had speeds: " + a + ", " + b + ", " + c + ", " + d + ", " + e;
                                        Console.WriteLine("Fastest speed tuned team found so far had speeds: " + a + ", " + b + ", " + c + ", " + d + ", " + e);
                                    //}
                                }
                                TimeSpan elapsed_time = DateTime.Now - starting_time;
                                if (i%1000000 == 0)
                                {
                                    Console.WriteLine(elapsed_time.TotalSeconds + "s.\t" + Math.Round(i/elapsed_time.TotalSeconds).ToString() + " iterations per second. \tCurrent speeds: " + a + ", " + b + ", " + c + ", " + d + ", " + e);
                                }
                                i++; 
                                //Console.WriteLine(Math.Round(100f / (champion_1_speed_range[1] - champion_1_speed_range[0] + 1) * (a + 1 - champion_1_speed_range[0])) + "% completed. (" + Math.Round(elapsed_time.TotalMinutes / (a + 1 - champion_1_speed_range[0]) * (champion_1_speed_range[1] - a)) + " mins left)");

                            }
                        }
                    }
                }

            }
            TimeSpan elapsed_time2 = DateTime.Now - starting_time;
            Console.WriteLine(elapsed_time2.TotalSeconds + "s.\t" + Math.Round(i / elapsed_time2.TotalSeconds).ToString() + " iterations per second.");

            Console.WriteLine("Simulation Completed");
            Console.WriteLine(lowest_total_speeds_message);
            Console.ReadKey();
        }
    }
}