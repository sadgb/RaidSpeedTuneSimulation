/**
* Example of the champion Seeker
*
* Ability 2: Boost everyones turn meter by 30% and takes an extra turn (3 turn cooldown)
*/

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Seeker : Champion
    {
        public Seeker(float speed, string log_name = null) : base(speed, log_name)
        {
            A2_cooldown_max = 3;
            A2_cooldown_delay = 0;
            A2_cooldown = A2_cooldown_delay;
            A3_cooldown = A3_cooldown_delay;
            A4_cooldown = A4_cooldown_delay;
        }


        public override void PerformA2()
        {
            base.PerformA2();
            /**
            * Ability 2
            */

            // 30% turn meter boost
            // max_turn_meter = 1428.57;
            // 1428.57 / 100 * 30 = 428.571

            // Тут нам не важно что он и сам себя заливает тоже так как он сразу походит еще раз
            Simulation.champion1.turn_meter += 428.571f;
            Simulation.champion2.turn_meter += 428.571f;
            Simulation.champion3.turn_meter += 428.571f;
            Simulation.champion4.turn_meter += 428.571f;
            Simulation.champion5.turn_meter += 428.571f;
           
            LowerCoolDowns();
            // Take another turn
            Turn();
        }

        public override void Basic_Attack()
        {
            base.Basic_Attack();
            LowerCoolDowns();
        }


        public override void AfterTurn()
        {
            // do nothing - в этом ловце мы сами управляем кулдаунами
        }
    }
}