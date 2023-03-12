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
        public Warcaster(float speed, string log_name = null) : base(speed, log_name)
        {
            A3_cooldown_max = 4;
            A3_cooldown_delay = 2;
            A3_cooldown = A3_cooldown_delay + 2; // additional 2 for regenate skill
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