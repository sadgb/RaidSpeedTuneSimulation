

using System;
/**
* Example of the champion Warcaster
*
* Ability 2: dont use
* Ability 3: Places block damage on all allies (4 turn cooldown)
*/
namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Warcaster : Champion
    {
        public static int[,] AVAILABLE_DELAYS =          {
                {9999, 0, 9999 },
                {9999, 1, 9999 },
                {9999, 2, 9999 },
                {9999, 3, 9999 },
                {9999, 4, 9999 },
                {9999, 5, 9999 },
                {9999, 6, 9999 },
                {9999, 7, 9999 },
            };

        public Warcaster(float speed, string log_name = null, int? A2_delay = null, int? A3_delay = null, int? A4_delay = null) : base(speed, log_name, A2_delay, A3_delay, A4_delay)
        {
            A3_cooldown_max = 4;
        }

        public override void PerformA3()
        {
            base.PerformA3();
            /**
            * Places block damage on all allies
            */

            Simulation.Unkillable(1);
        }
    }
}