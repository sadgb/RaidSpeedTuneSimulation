using System;
using System.Runtime.Remoting.Activation;

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public partial class Simulation
    {
        static Random random = new Random();
        static string lowest_total_speeds_message = "No speed tuned speeds found";
        static bool running;
        static bool SpeedTuned;
        static float max_turn_meter = 1428.57f;
        static float clan_boss_speed = 190;
        static float clan_boss_turn_meter;
        static int clan_boss_turns_taken;


        public static Champion champion1;
        public static Champion champion2;
        public static Champion champion3;
        public static Champion champion4;
        public static Champion champion5;

        // level 0 - all moves and skills and buffs/debufs + CD
        // level 1 - all moves and skills and buffs/debufs + CD
        // level 1 - all moves and skill usages
        // level 4 - simulation faileds
        public static void DebugLog(String data, int level)
        {
            if (level >= log_level)
            {
                Console.WriteLine(data);
            }
        }



        public static bool Run_Simulation(string difficulty, float champion_1_speed, float champion_2_speed, float champion_3_speed, float champion_4_speed, float champion_5_speed)
        {
            if (champion_1_speed + champion_2_speed + champion_3_speed + champion_4_speed + champion_5_speed > lowest_total_speeds) { return false; }

            if (difficulty == "unm")
            {
                clan_boss_speed = 190;
            }
            else if (difficulty == "nm")
            {
                clan_boss_speed = 170;
            }
            else if(difficulty == "brutal")
            {
                clan_boss_speed = 160;
            }

            running = true;
            SpeedTuned = true;


            clan_boss_turn_meter = 0f;

            // TODO initialize champions
            champion1 = new Warcaster(champion_1_speed);
            champion2 = new Seeker(champion_2_speed);
            champion3 = new Renegate(champion_3_speed);
            champion4 = new Champion(champion_4_speed);
            champion5 = new Champion(champion_5_speed);


            clan_boss_turns_taken = 0;



            // Run simulation
            while (running)
            {
                // Add turn meter to champions and clan boss
                clan_boss_turn_meter += clan_boss_speed;
                champion1.TickTurnMeter();
                champion2.TickTurnMeter();
                champion3.TickTurnMeter();
                champion4.TickTurnMeter();
                champion5.TickTurnMeter();


                // Check turns
                if (clan_boss_turn_meter >= max_turn_meter || 
                    champion1.turn_meter >= max_turn_meter || 
                    champion2.turn_meter >= max_turn_meter || 
                    champion3.turn_meter >= max_turn_meter ||
                    champion4.turn_meter >= max_turn_meter ||
                    champion5.turn_meter >= max_turn_meter)
                {
                    if (champion1.turn_meter >= clan_boss_turn_meter && 
                        champion1.turn_meter >= champion2.turn_meter && 
                        champion1.turn_meter >= champion3.turn_meter && 
                        champion1.turn_meter >= champion4.turn_meter && 
                        champion1.turn_meter >= champion5.turn_meter)
                    {
                        champion1.Turn();
                    }
                    else if (champion2.turn_meter >= clan_boss_turn_meter && champion2.turn_meter >= champion1.turn_meter && champion2.turn_meter >= champion3.turn_meter && champion2.turn_meter >= champion4.turn_meter && champion2.turn_meter >= champion5.turn_meter)
                    {
                        champion2.Turn();
                    }
                    else if (champion3.turn_meter >= clan_boss_turn_meter && champion3.turn_meter >= champion1.turn_meter && champion3.turn_meter >= champion2.turn_meter && champion3.turn_meter >= champion4.turn_meter && champion3.turn_meter >= champion5.turn_meter)
                    {
                        champion3.Turn();
                    }
                    else if (champion4.turn_meter >= clan_boss_turn_meter && champion4.turn_meter >= champion1.turn_meter && champion4.turn_meter >= champion2.turn_meter && champion4.turn_meter >= champion3.turn_meter && champion4.turn_meter >= champion5.turn_meter)
                    {
                        champion4.Turn();
                    }
                    else if (champion5.turn_meter >= clan_boss_turn_meter && champion5.turn_meter >= champion1.turn_meter && champion5.turn_meter >= champion2.turn_meter && champion5.turn_meter >= champion3.turn_meter && champion5.turn_meter >= champion4.turn_meter)
                    {
                        champion5.Turn();
                    }
                    else if (clan_boss_turn_meter >= champion1.turn_meter && clan_boss_turn_meter >= champion2.turn_meter && clan_boss_turn_meter >= champion3.turn_meter && clan_boss_turn_meter >= champion4.turn_meter && clan_boss_turn_meter >= champion5.turn_meter)
                    {
                        clan_boss_turns_taken++;
                        clan_boss_turn_meter = 0;
                        ClanBoss();

                        if (enable_debuffs && (clan_boss_turns_taken - 2) % 3 == 0)
                        {
                            // TODO debuffs
                            /*
                            if (random.Next(0, 11) < 7 && champion_1_block_debuffs_duration <= 0)
                            {
                                champion_1_decrease_speed_duration = 2;
                            }
                            if (random.Next(0, 11) < 7 && champion_2_block_debuffs_duration <= 0)
                            {
                                champion_2_decrease_speed_duration = 2;
                            }
                            if (random.Next(0, 11) < 7 && champion_3_block_debuffs_duration <= 0)
                            {
                                champion_3_decrease_speed_duration = 2;
                            }
                            if (random.Next(0, 11) < 7 && champion_4_block_debuffs_duration <= 0)
                            {
                                champion_4_decrease_speed_duration = 2;
                            }
                            if (random.Next(0, 11) < 7 && champion_5_block_debuffs_duration <= 0)
                            {
                                champion_5_decrease_speed_duration = 2;
                            }*/
                        }

                        if (clan_boss_turns_taken % clan_boss_check_turns_at == 0)
                        {
                            if ((clan_boss_turns_taken - speed_tuned_after_cb_attack) > 0)
                            {
                                ClanBossCheckTurns();
                            }

                            champion1.turns_per_cb_turn = 0;
                            champion2.turns_per_cb_turn = 0;
                            champion3.turns_per_cb_turn = 0;
                            champion4.turns_per_cb_turn = 0;
                            champion5.turns_per_cb_turn = 0;
                        }
                    }
                }
            }

            return SpeedTuned;
        }

        public static Champion[] Champions()
        {
            Champion[] arr = { champion1, champion2, champion3, champion4, champion5 };
            return arr;
        }

        public static void Cleanse()
        {
            foreach (var i in Champions())
            {
                i.Cleanse();
            }
        }


        public static void Unkillable(int duration)
        {
            foreach (var i in Champions())
            {
                i.Unkillable(duration);
            }
        }


        public static void BlockDebuffs(int duration)
        {
            foreach (var i in Champions())
            {
                i.BlockDebuffs(duration);
            }
        }


        public static void CounterAttack(int duration)
        {
            foreach (var i in Champions())
            {
                i.CounterAttack(duration);
            }
        }


        public static void SpeedBuff(int duration)
        {
            foreach (var i in Champions())
            {
                i.SpeedBuff(duration);
            }
        }


        public static void ExtendBuffs(int duration)
        {
            foreach (var i in Champions())
            {
                i.ExtendBuffs(duration);
            }
        }
    }
}