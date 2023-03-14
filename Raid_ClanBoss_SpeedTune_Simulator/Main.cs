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

            // TODO dont hardcode classes
            var champion1_delays = Warcaster.AVAILABLE_DELAYS;
            var champion2_delays = Apothecary.AVAILABLE_DELAYS;
            var champion3_delays = PrinceKymer.AVAILABLE_DELAYS;

            for (int champion_5_speed = champion_5_speed_range[0]; champion_5_speed <= champion_5_speed_range[1]; champion_5_speed += search_detail)
            {
                for (float champion_4_speed = champion_4_speed_range[0]; champion_4_speed <= champion_4_speed_range[1]; champion_4_speed += search_detail)
                {
                    for (float champion_3_speed = champion_3_speed_range[0]; champion_3_speed <= champion_3_speed_range[1]; champion_3_speed += search_detail)
                    {
                        for (float champion_2_speed = champion_2_speed_range[0]; champion_2_speed <= champion_2_speed_range[1]; champion_2_speed += search_detail)
                        {
                            for (float champion_1_speed = champion_1_speed_range[0]; champion_1_speed <= champion_1_speed_range[1]; champion_1_speed += search_detail)
                            {
                                for(int d1 = 0; d1 < champion1_delays.Length/3; d1++)
                                {

                                    for (int d2 = 0; d2 < champion2_delays.Length / 3; d2++)
                                    {

                                        for (int d3 = 0; d3 < champion3_delays.Length/3; d3++)
                                        {
                                            // TODO initialize champions
                                            champion1 = new Warcaster(champion_1_speed, A2_delay: champion1_delays[d1,0], A3_delay: champion1_delays[d1,1], A4_delay: champion1_delays[d1, 2] );
                                            champion2 = new Apothecary(champion_2_speed, A2_delay: champion2_delays[d2, 0], A3_delay: champion2_delays[d2, 1], A4_delay: champion2_delays[d2, 2]);
                                            champion3 = new PrinceKymer(champion_3_speed, A2_delay: champion3_delays[d3, 0], A3_delay: champion3_delays[d3, 1], A4_delay: champion3_delays[d3, 2]);
                                            champion4 = new Champion(champion_4_speed, "Skullcrusher");
                                            champion5 = new Champion(champion_5_speed, "Dracomorph");


                                            if (champion_1_speed + champion_2_speed + champion_3_speed + champion_4_speed + champion_5_speed > lowest_total_speeds) { continue; }
                                            /*
            if (champion_1_speed > lowest_biggest_speed ||
                champion_2_speed > lowest_biggest_speed ||
                champion_3_speed > lowest_biggest_speed ||
                champion_4_speed > lowest_biggest_speed ||
                champion_5_speed > lowest_biggest_speed 
                ) { return false; }
            */

                                            // Run ultra nightmare difficulty
                                            if (Run_Simulation("unm", champion1, champion2, champion3, champion4, champion5))
                                            {
                                                // If ultra nightmare was successful then run nightmare difficulty
                                                //if (Run_Simulation("nm", a, b, c, d, e))
                                                //{
                                                // if all tests were successful then log out message telling the speeds
                                                lowest_biggest_speed = Math.Max(Math.Max(Math.Max(Math.Max(champion_1_speed, champion_2_speed), champion_3_speed), champion_4_speed), champion_5_speed);
                                                lowest_total_speeds = champion_1_speed + champion_2_speed + champion_3_speed + champion_4_speed + champion_5_speed;
                                                lowest_total_speeds_message = "Fastest speed tuned team had speeds: " + champion_1_speed + ", " + champion_2_speed + ", " + champion_3_speed + ", " + champion_4_speed + ", " + champion_5_speed + "\n delays: d1=" + d1 + " d2=" + d2 + " d3=" +d3;
                                                Console.WriteLine(lowest_total_speeds_message);
                                                //}
                                            }
                                            if (i % 4000000 == 0)
                                            {
                                                TimeSpan elapsed_time = DateTime.Now - starting_time;
                                                Console.WriteLine(elapsed_time.TotalSeconds + "s.\t" + Math.Round(i / elapsed_time.TotalSeconds).ToString() + " iterations per second. \tCurrent speeds: " + champion_1_speed + ", " + champion_2_speed + ", " + champion_3_speed + ", " + champion_4_speed + ", " + champion_5_speed);
                                            }
                                            i++;
                                            //Console.WriteLine(Math.Round(100f / (champion_1_speed_range[1] - champion_1_speed_range[0] + 1) * (a + 1 - champion_1_speed_range[0])) + "% completed. (" + Math.Round(elapsed_time.TotalMinutes / (a + 1 - champion_1_speed_range[0]) * (champion_1_speed_range[1] - a)) + " mins left)");










                                        }
                                    }
                                }


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