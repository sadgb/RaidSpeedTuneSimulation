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
        public PrinceKymer(float speed, string log_name = null) : base(speed, log_name)
        {
            A3_cooldown_max = 6;
            A3_cooldown_delay = 2;
            A3_cooldown = A3_cooldown_delay;
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