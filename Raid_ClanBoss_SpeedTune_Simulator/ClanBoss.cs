using System;

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public partial class Simulation
    {
        public static void ClanBossCheckTurns()
        {
            /* Check how many turns champions have taken compared to clan boss (how often this is called depends on your settings in config file) */
            // Make sure every champion takes atleast 2 turns for every clan boss turn
            /*
            if (champion1.turns_per_cb_turn < 2 ||
                champion2.turns_per_cb_turn < 2 ||
                champion3.turns_per_cb_turn < 2 ||
                champion4.turns_per_cb_turn < 2 ||
                champion5.turns_per_cb_turn < 2
            )
            {
                SpeedTuned = false;
                running = false;
            }
            */


            //if (clan_boss_turns_taken % 3 == 0)
            //{
            //    /* Turn before stun */
            //    if (champion_1_turns_per_cb_turn != 1 ||
            //        champion_2_turns_per_cb_turn != 1 ||
            //        champion_3_turns_per_cb_turn != 1 ||
            //        champion_4_turns_per_cb_turn != 1 ||
            //        champion_5_turns_per_cb_turn != 1
            //    )
            //    {
            //        SpeedTuned = false;
            //        running = false;
            //    }
            //}
            //else if ((clan_boss_turns_taken - 2) % 3 == 0)
            //{
            //    /* Turn before second Aoe */
            //    if (champion_1_turns_per_cb_turn != 1 ||
            //        champion_2_turns_per_cb_turn != 1 ||
            //        champion_3_turns_per_cb_turn != 1 ||
            //        champion_4_turns_per_cb_turn != 1 ||
            //        champion_5_turns_per_cb_turn != 1
            //    )
            //    {
            //        SpeedTuned = false;
            //        running = false;
            //    }
            //}
            //else
            //{
            //    /* Turn before first aoe */
            //    if (champion_1_turns_per_cb_turn != 1 ||
            //        champion_2_turns_per_cb_turn != 1 ||
            //        champion_3_turns_per_cb_turn != 1 ||
            //        champion_4_turns_per_cb_turn != 1 ||
            //        champion_5_turns_per_cb_turn != 1
            //    )
            //    {
            //        SpeedTuned = false;
            //        running = false;
            //    }
            //}
        }


        public static void ClanBoss()
        {
            if (Simulation.log_level <= 1)
            {
                if (clan_boss_turns_taken % 3 == 1)
                {
                    DebugLog("Clann boss (" + clan_boss_turns_taken + ") AoE 1\n", 1);
                }
                else if (clan_boss_turns_taken % 3 == 2)
                {
                    DebugLog("Clann boss (" + clan_boss_turns_taken + ") AoE 2\n", 1);
                }
                else
                {
                    DebugLog("Clann boss (" + clan_boss_turns_taken + ") STUN\n=================================\n\n", 1);
                }
            }



            // Should work starting after first stun
            if (clan_boss_turns_taken < 3)
            {
                return;
            }

            // Custom Checks for valid runs (called every clan boss turn)
            // ====================================================================================

            if (clan_boss_turns_taken % 3 == 1 || clan_boss_turns_taken % 3 == 2)
            {
                // first AOE or second AoE
                foreach (var c in Champions())
                {
                    // all champions should be under block damage buff
                    if (c.unkillable_duration <= 0) { MarkCurrentRunAsFailed(); }
                }
            }
            // ====================================================================================
          
            if(clan_boss_turns_taken >= 50)
            {
                running = false;
            }
        }

        public static void MarkCurrentRunAsFailed()
        {
            if (Simulation.log_level <= 4) {
                DebugLog("Failed at clan boss turn " + clan_boss_turns_taken, 4);
            }

          SpeedTuned = false;
          running = false;
        }
    }
}