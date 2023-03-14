/**
* Example of the champion Renegate
*
* Ability 2: doesnt matter
* Ability 3: Decrease the cooldown of ally skills by 2 ( 7-6-5 turns cooldown )
*/

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Renegate : Champion
    { 
        public Renegate(float speed, string log_name = null, int? A2_delay = null, int? A3_delay = null, int? A4_delay = null) : base(speed, log_name, A2_delay, A3_delay, A4_delay)
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
                    c.LowerCoolDowns(2);
                }
            }
        }
    }
}