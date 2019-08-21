﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E7_Gear_Optimizer
{
    public class Item
    {
        public string ID { get; }
        private ItemType type;
        private Set set;
        private Grade grade;
        private int iLvl;
        private int enhance;
        private Stat main;
        private Stat[] subStats;
        public SStats AllStats { get; set; }
        private float wss;
        public bool Locked { get; set; }
        public Hero Equipped { get; set; }

        public Item(string id, ItemType type, Set set, Grade grade, int iLvl, int enhance, Stat main, Stat[] subStats, Hero equipped, bool locked)
        {
            ID = id;
            this.type = type;
            this.set = set;
            this.grade = grade;
            this.iLvl = iLvl;
            this.enhance = enhance;
            this.main = main;
            this.subStats = subStats;
            Equipped = equipped;
            Locked = locked;
            calcWSS();

            AllStats = new SStats();
            AllStats.AddStatsValues(new[] { main });
            AllStats.AddStatsValues(subStats);
        }

        public Item() { }


        public ItemType Type { get => type; set => type = value; }
        public Set Set { get => set; set => set = value; }
        public Grade Grade { get => grade; set => grade = value; }
        public int ILvl
        {
            get => iLvl;
            set
            {
                if (value > 0)
                {
                    iLvl = value;
                }
            }
        }
        public int Enhance
        {
            get => enhance;
            set
            {
                if (value > -1 && value < 16)
                {
                    enhance = value;
                }
            }
        }
        public Stat Main { get => main; set => main = value; }
        public Stat[] SubStats { get => subStats; set => subStats = value; }

        public float WSS { get => wss; }

        public void calcWSS()
        {
            wss = 0;
            foreach (Stat s in subStats)
            {
                switch (s.Name)
                {
                    case Stats.ATKPercent:
                        wss += s.Value * 100;
                        break;
                    case Stats.Crit:
                        wss += s.Value * 1.5f * 100;
                        break;
                    case Stats.CritDmg:
                        wss += s.Value * 100;
                        break;
                    case Stats.DEFPercent:
                        wss += s.Value * 100;
                        break;
                    case Stats.EFF:
                        wss += s.Value * 100;
                        break;
                    case Stats.HPPercent:
                        wss += s.Value * 100;
                        break;
                    case Stats.RES:
                        wss += s.Value * 100;
                        break;
                    case Stats.SPD:
                        wss += s.Value * 2;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
