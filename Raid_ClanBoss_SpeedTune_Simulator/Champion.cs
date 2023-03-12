﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raid_ClanBoss_SpeedTune_Simulator
{
    public class Champion
    {
        public int unkillable_duration { get; set; }
        public int block_debuffs_duration { get; set; }
        public int increase_speed_duration { get; set; }
        public int decrease_speed_duration { get; set; }
        public int counter_attack_duration { get; set; }
        public int A2_cooldown { get; set; }
        public int A3_cooldown { get; set; }
        public int A4_cooldown { get; set; }
        public int A2_cooldown_max { get; set; }
        public int A2_cooldown_delay { get; set; }
        public int A3_cooldown_max { get; set; }
        public int A3_cooldown_delay { get; set; }
        public int A4_cooldown_max { get; set; }
        public int A4_cooldown_delay { get; set; }
        public int turns_per_cb_turn { get; set; }

        public float speed { get; set; }
        public float turn_meter { get; set; }
        public string log_name { get; set; }

        public Champion(float speed, String log_name = null)
        {
            unkillable_duration = 0;
            block_debuffs_duration = 0;
            increase_speed_duration = 0;
            decrease_speed_duration = 0;
            counter_attack_duration = 0;
            turn_meter = 0f;
            this.speed = speed;

            A2_cooldown_delay = 9999;
            A3_cooldown_delay = 9999;
            A4_cooldown_delay = 9999;
            A2_cooldown_max = 9999;
            A3_cooldown_max = 9999;
            A4_cooldown_max = 9999;

            A2_cooldown = A2_cooldown_delay;
            A3_cooldown = A3_cooldown_delay;
            A4_cooldown = A4_cooldown_delay;

            turns_per_cb_turn = 0;

            if (log_name != null)
            {

                this.log_name = log_name;
            } else
            {
                this.log_name = this.GetType().Name + "(" + this.speed + ")";
            }
        }

        public void ExtendBuffs(int duration)
        {
            // TODO we cant extend unkillable
            // if (unkillable_duration >= 1) { unkillable_duration = unkillable_duration + duration; }
            if (block_debuffs_duration >= 1) { block_debuffs_duration = block_debuffs_duration + duration; }
            if (increase_speed_duration >= 1) { increase_speed_duration = increase_speed_duration + duration; }
            if (counter_attack_duration >= 1) { counter_attack_duration = counter_attack_duration + duration; }
        }

        public void TickTurnMeter()
        {
            if (increase_speed_duration > 0 && decrease_speed_duration > 0)
            {
                turn_meter += speed * 1.15f;
            }
            else if (increase_speed_duration > 0 && decrease_speed_duration <= 0)
            {
                turn_meter += speed * 1.3f;
            }
            else if (increase_speed_duration <= 0 && decrease_speed_duration > 0)
            {
                turn_meter += speed * 0.85f;
            }
            else
            {
                turn_meter += speed;
            }
        }

        public void Cleanse()
        {
            decrease_speed_duration = 0;
        }

        public void BlockDebuffs(int duration)
        {
            if (block_debuffs_duration < duration) { block_debuffs_duration = duration; }
        }

        public void CounterAttack(int duration)
        {
            if (counter_attack_duration < duration) { counter_attack_duration = duration; }
        }

        public void SpeedBuff(int duration)
        {
            if (increase_speed_duration < duration) { increase_speed_duration = duration; }
        }

        public void Unkillable(int duration)
        {
            if (unkillable_duration < duration) { unkillable_duration = duration; }
        }
        public virtual void PerformA2()
        {
            Simulation.DebugLog(log_name + " A2.", 1);
            A2_cooldown = A2_cooldown_max;

        }

        public virtual void PerformA3()
        {
            Simulation.DebugLog(log_name + " A3.", 1);
            A3_cooldown = A3_cooldown_max;

        }

        public virtual void PerformA4()
        {
            Simulation.DebugLog(log_name + " A4.", 1);
            A4_cooldown = A4_cooldown_max;

        }


        public virtual void Basic_Attack()
        {
            Simulation.DebugLog(log_name + " A1.", 1);

        }

        public void Turn()
        {
            // Let simulation know this champion has taken a turn
            turns_per_cb_turn++;

            // Set turn meter back to 0
            turn_meter = 0;

            // Lower champions buffs by 1 turn
            unkillable_duration--;
            block_debuffs_duration--;
            increase_speed_duration--;
            decrease_speed_duration--;
            counter_attack_duration--;

            Simulation.DebugLog("Cooldowns: " + log_name + "A2_CD=" + A2_cooldown + " A3_CD=" + A3_cooldown, 0);
            UseSkill();
            Simulation.DebugLog("Cooldowns: " + log_name + "A2_CD=" + A2_cooldown + " A3_CD=" + A3_cooldown, 0);

            AfterTurn();
            Simulation.DebugLog("Cooldowns: " + log_name + "A2_CD=" + A2_cooldown + " A3_CD=" + A3_cooldown, 0);
        }

        public virtual void UseSkill() {
            // TODO priority
            if (A4_cooldown <= 0)
            {
                PerformA4();
            }
            else
            if (A3_cooldown <= 0)
            {
                PerformA3();
            }
            else if (A2_cooldown <= 0)
            {
                PerformA2();
            }
            else
            {
                Basic_Attack();
            }
        }

        public virtual void AfterTurn()
        {
            LowerCoolDowns();
        }

        public virtual void LowerCoolDowns(int duration = 1)
        {
            A2_cooldown -= duration;
            A3_cooldown -= duration;
            A4_cooldown -= duration;
        }
    }
}
