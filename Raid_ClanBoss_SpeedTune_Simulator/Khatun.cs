

using System.Threading;
/**
* Example of the champion Khatun
*
* Ability 2: Fills the Turn Meters of all allies by 15% and places a 30% [Increase SPD] buff on all allies for 2 turns.
*/

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Khatun : Champion
    {
        public Khatun(float speed, string log_name = null) : base(speed, log_name)
        {
            A3_cooldown_max = 3;
            A3_cooldown_delay = 0;
            A3_cooldown = A3_cooldown_delay;
        }


        public override void PerformA2()
        {
            base.PerformA2();
            /**
            * Ability 2
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