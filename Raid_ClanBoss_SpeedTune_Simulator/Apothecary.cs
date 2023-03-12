

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
        public Apothecary(float speed, string log_name = null) : base(speed, log_name)
        {
            A3_cooldown_max = 3;
            A3_cooldown_delay = 0;
            A3_cooldown = A3_cooldown_delay;
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