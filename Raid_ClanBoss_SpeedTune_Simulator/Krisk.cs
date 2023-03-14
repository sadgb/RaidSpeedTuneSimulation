/**
* Example of the champion Krisk
*
* Ability 2: Extends all buffs by 1 turn (3 turn cooldown)
* Ability 3: Places increase speed buff on every ally for 2 turns (3 turn cooldown)
*/

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Krisk : Champion
    { 
        public Krisk(float speed, string log_name = null, int? A2_delay = null, int? A3_delay = null, int? A4_delay = null) : base(speed, log_name, A2_delay, A3_delay, A4_delay)
        {
            A2_cooldown_max = 3;
            A3_cooldown_max = 3;
        }

        public override void PerformA2()
        {
            base.PerformA2();
            /**
            * Extends all buffs by 1 turn
            */

            Simulation.ExtendBuffs(1);
        }



        public override void PerformA3()
        {
            base.PerformA3();
            /**
            * Places increase speed buff on every ally for 2 turns (does not place buff on himself)
            * This skill also places increase defence on this champion, but that is not important for the speed tune, so we can ignore it
            */

            // Get this champions current speed buff duration
            int current_speed_buff = increase_speed_duration;

            // Place speed buff on every ally
            Simulation.SpeedBuff(2);

            // Set this champions speed buff duration to the state it was before calling speed buff on everyone
            increase_speed_duration = current_speed_buff;
        }
    }
}