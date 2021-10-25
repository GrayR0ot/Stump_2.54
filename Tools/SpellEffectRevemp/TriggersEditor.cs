using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SpellEffect.EffectInstances;
using Stump.Server.WorldServer.Game.Fights.Buffs;

namespace SpellEffect
{
    public partial class TriggersEditor : Form
    {
        private readonly EffectBase effectData;
        private MySqlConn mysqlCon;

        public TriggersEditor()
        {
            InitializeComponent();
        }

        public TriggersEditor(ref EffectBase _effectData, MySqlConn _mysqlconn)
        {
            InitializeComponent();
            mysqlCon = _mysqlconn;
            effectData = _effectData;
            ChangeTargetTB.Text = effectData.TriggersBuff.FirstOrDefault();
            CurrentValueTB.Text = effectData.TriggersBuff.FirstOrDefault();
            _effectData.ParseTriggersBuff();

            foreach (var effTarget in effectData.TriggersBuff)
                CurrentValueLB.Items.Add(effTarget);

            // AllEnumValuesLB
            var spellTargetType = Enum.GetNames(typeof(BuffTriggerType));
            for (var cnt = 0; cnt < spellTargetType.Length; cnt++)
                if (CurrentValueLB.Items.IndexOf(spellTargetType[cnt]) == -1)
                    AllEnumValuesLB.Items.Add(spellTargetType[cnt]);
        }

        public static byte[] FromHex(string hex)
        {
            var raw = new byte[hex.Length / 2];
            for (var i = 0; i < raw.Length; i++)
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            return raw;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            // recalcule
            var stt2 = "";
            var count = 0;
            foreach (var value in CurrentValueLB.Items)
                if (count == 0)
                {
                    stt2 = value.ToString();
                    count++;
                }
                else
                {
                    stt2 += "," + value;
                }

            effectData.TriggersBuff = new List<string> {stt2};
            var mask = stt2.Split(',');
            effectData.AddTriggers(mask);
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                Method1Panel.Enabled = true;
            else
                Method2Panel.Enabled = true;
        }

        private void LeftArrowPB_Click(object sender, EventArgs e)
        {
            if (AllEnumValuesLB.SelectedIndex != -1)
            {
                var selectedValue = AllEnumValuesLB.SelectedItem.ToString();
                CurrentValueLB.Items.Add(AllEnumValuesLB.SelectedItem);
                AllEnumValuesLB.Items.Remove(AllEnumValuesLB.SelectedItem);

                // recalcule
                var stt2 = "";
                var count = 0;
                foreach (var value in CurrentValueLB.Items)
                    if (count == 0)
                    {
                        stt2 = value.ToString();
                        count++;
                    }
                    else
                    {
                        stt2 += "," + value;
                    }

                CurrentValueTB.Text = stt2;
                effectData.Targets = new List<string> {stt2};

                AllEnumValuesLB.SelectedIndex = AllEnumValuesLB.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un élement dans la liste 'Avalaible Flags'");
            }
        }

        private void RightArrowPB_Click(object sender, EventArgs e)
        {
            if (CurrentValueLB.SelectedIndex != -1)
            {
                var selectedValue = CurrentValueLB.SelectedItem.ToString();
                AllEnumValuesLB.Items.Add(CurrentValueLB.SelectedItem);
                CurrentValueLB.Items.Remove(CurrentValueLB.SelectedItem);

                // recalcule
                var stt2 = "";
                var count = 0;
                foreach (var value in CurrentValueLB.Items)
                    if (count == 0)
                    {
                        stt2 = value.ToString();
                        count++;
                    }
                    else
                    {
                        stt2 += "," + value;
                    }

                CurrentValueTB.Text = stt2;
                effectData.Targets = new List<string> {stt2};

                CurrentValueLB.SelectedIndex = CurrentValueLB.Items.Count - 1;
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un élement dans la liste 'Current Flags'");
            }
        }

        private void EditBtn2_Click(object sender, EventArgs e)
        {
            CurrentValueLB.Items.Add(ChangeTargetTB.Text);
            var stt2 = "";
            var count = 0;
            foreach (var value in CurrentValueLB.Items)
                if (count == 0)
                {
                    stt2 = value.ToString();
                    count++;
                }
                else
                {
                    stt2 += "," + value;
                }

            effectData.Targets = new List<string> {stt2};
            var mask = stt2.Split(',');
            effectData.AddTriggers(mask);
            Close();
        }
    }
}