

using System.Threading;
/**
* Example of the champion Apothecary
*
* Ability 3: Places a 30% Increase Speed buff on all allies for 2 turns. Fills the Turn Meter of all allies by 15%.
*/

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Apothecary : Champion
    {
        public static int[,] AVAILABLE_DELAYS =   {
                {9999, 0, 9999 },
                {9999, 1 , 9999},
                {9999, 2, 9999 },
                {9999, 3, 9999 },
            };

        public Apothecary(float speed, string log_name = null, int? A2_delay = null, int? A3_delay = null, int? A4_delay = null) : base(speed, log_name, A2_delay, A3_delay, A4_delay)
        {
            A3_cooldown_max = 3;
        }


        public override void PerformA3()
        {
            base.PerformA3();
            /**
            * Ability 3
            */
            // Places a 30 % Increase Speed buff on all allies for 2 turns
            // .Fills the Turn Meter of all allies by 15 %.
            // max_turn_meter = 1428.57;
            // 1428.57 / 100 * 15 = 214.2855

            Simulation.champion1.turn_meter += 214.2855f;
            Simulation.champion2.turn_meter += 214.2855f;
            Simulation.champion3.turn_meter += 214.2855f;
            Simulation.champion4.turn_meter += 214.2855f;
            Simulation.champion5.turn_meter += 214.2855f;

            Simulation.SpeedBuff(2);
        }
    }
}