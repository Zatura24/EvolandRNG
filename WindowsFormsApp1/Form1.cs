using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.IO;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        private System.Timers.Timer aTimer;

        private Process game;

        private const int seedsArrayLength = 26;
        private IntPtr seedsPointer;
        private uint[] seedsArray = new uint[seedsArrayLength];
        private uint seedsCur = uint.MaxValue;

        public Form1()
        {
            InitializeComponent();

            game = Process.GetProcessesByName("Evoland")[0];

            seedsPointer = new DeepPointer("libhl.dll", 0x4914C, 0x7F4, 0x0, 0x18).Deref<IntPtr>(game);

            SaveButton.Click += SaveButton_Click;

            SetTimer();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var streamWriter = new StreamWriter("seeds.csv", append: true)) {
                streamWriter.WriteLine(String.Join(",", seedsArray.Select(x => x.ToString("X"))));
            }
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000/60);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Update();

            var cur = seedsArray[seedsArrayLength - 1] - 1;

            if (seedsCur != cur)
            {
                seedsCur = cur;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    //KefkaHealth.Text = "Current index: " + cur;

                    listSeeds.Items.Clear();
                    for (int i = 0; i < seedsArrayLength - 1; ++i)
                    {
                        listSeeds.Items.Add(seedsArray[i].ToString("X"));
                        if (i == cur)
                        {
                            listSeeds.Items[i].BackColor = SystemColors.Highlight;
                            listSeeds.Items[i].ForeColor = SystemColors.HighlightText;
                        }
                    }


                    nextDamageRoll.Text = "Next Damage Roll: " + DamageRoll();
                    var missValue = (Random.RndInt(seedsArray) & 0x3fffffff) % 0x64;
                    nextMissRnd.Text = $"Will miss?:\n ['Kobra Zero', {missValue < 0x1E}]";
                }));
            }
        }

        private void Update()
        {
            byte[] arrayBytes = new byte[seedsArrayLength * 0x4];
            if (!game.ReadBytes(seedsPointer, seedsArrayLength * 0x4, out arrayBytes)) throw new Exception();
            Buffer.BlockCopy(arrayBytes, 0, seedsArray, 0, arrayBytes.Length);
        }

        private uint DamageRoll()
        {
            double damage = Random.RndFloat(seedsArray);
            uint playerDamage = 8; // still need to find this value in memory
            uint enemyDefense = 0;
            damage *= 0.5;
            damage *= playerDamage;
            damage += playerDamage;
            damage -= enemyDefense;
            return (uint)Math.Round(damage);
        }
    }
}
