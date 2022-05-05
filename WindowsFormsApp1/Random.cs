using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    

    class Random
    {
        private static readonly uint NSEEDS = 25;
        private static readonly uint MAX = 7;
        private static readonly uint[] mag01 = new uint[2] {
            0x0, 0x8ebfd028
        };

        public static uint RndInt(uint[] seeds)
        {
            uint y;
            uint pos = seeds[NSEEDS]++;

            if (pos >= NSEEDS)
            {
                uint kk;
                for (kk = 0; kk < NSEEDS - MAX; kk++)
                {
                    seeds[kk] = seeds[kk + MAX] ^ (seeds[kk] >> 1) ^ mag01[seeds[kk] % 2];
                }
                for(;kk<NSEEDS;kk++)
                {
                    seeds[kk] = seeds[kk + (MAX - NSEEDS)] ^ (seeds[kk] >> 1) ^ mag01[seeds[kk] % 2];
                }
                seeds[25] = 1;
                pos = 0;
            }

            y = seeds[pos];
            y ^= (y << 7) & 0x2b5b2500;
            y ^= (y << 15) & 0xdb8b0000;
            y ^= (y >> 16);
            return y;
        }
        public static double RndFloat(uint[] seeds)
        {
            var big = 4294967296.0;
            return ((RndInt(seeds) / big + RndInt(seeds)) / big + RndInt(seeds)) / big;
        }
    }
}
