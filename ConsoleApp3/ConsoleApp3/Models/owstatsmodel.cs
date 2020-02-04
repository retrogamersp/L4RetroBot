using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Models
{
    public class owstatsmodel
    {
        public Uri icon;
        public string name;
        public byte level;
        public Uri levelicon;
        public ushort prestige;
        public Uri prestigeicon;
        public ushort rating;
        public Uri ratingicon;
        public ulong gameswon;
        public struct quickPlayStats
        {
            public double eliminationsAvg;
            public ulong damageDoneAvg;
            public double deathsAvg;
            public double finalBlowsAvg;
            public ulong healingDoneAvg;
            public double objectiveKillsAvg;
            public string objectiveTimeAvg;
            public double soloKillsAvg;
            public struct games
            {
                public ulong played;
                public ulong won;
            }
            public struct awards
            {
               public ulong cards;
               public ulong medals;
               public ulong medalsBronze;
               public ulong medalsSilver;
               public ulong medalsGold;
            }
        }
        public struct competitiveStats
        {
            public double eliminationsAvg;
            public ulong damageDoneAvg;
            public double deathsAvg;
            public double finalBlowsAvg;
            public ulong healingDoneAvg;
            public double objectiveKillsAvg;
            public string objectiveTimeAvg;
            public double soloKillsAvg;
            public struct games
            {
                public ulong played;
                public ulong won;
            }
            public struct awards
            {
                public ulong cards;
                public ulong medals;
                public ulong medalsBronze;
                public ulong medalsSilver;
                public ulong medalsGold;
            }
        }

    }
}
