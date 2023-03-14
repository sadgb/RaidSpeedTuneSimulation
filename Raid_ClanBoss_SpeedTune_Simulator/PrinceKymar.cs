/**
* Example of the champion Renegate
*
* Ability 2: doesnt matter
* Ability 3: Resets the cooldowns of all ally skills. Fills the Turn Meter of all allies except this Champion by 20%.
*/

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class PrinceKymer : Champion
    {
        public static int[,] AVAILABLE_DELAYS =   {
                {9999, 0, 9999 },
                {9999, 1, 9999 },
                {9999, 2, 9999 },
                {9999, 3, 9999 },
                {9999, 4, 9999 },
                {9999, 5, 9999 },
                {9999, 6, 9999 },
            };

        public PrinceKymer(float speed, string log_name = null, int? A2_delay = null, int? A3_delay = null, int? A4_delay = null  ) : base(speed, log_name, A2_delay, A3_delay, A4_delay)
        {
            A3_cooldown_max = 6;
        }

        public override void PerformA3()
        {
            base.PerformA3();
            /**
            * Decrease the cooldown of ally skills by 2
            */

            foreach (var c in Simulation.Champions())
            {
                if (c != this)
                {
                    c.LowerCoolDowns(20);
                    // Fills the Turn Meter of all allies by 20 %.
                    // max_turn_meter = 1428.57;
                    // 1428.57 / 100 * 20 = 285.714

                    c.turn_meter += 285.714f;
                }
            }
        }
    }
}