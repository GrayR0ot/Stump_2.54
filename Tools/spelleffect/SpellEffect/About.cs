using System.Diagnostics;
using System.Windows.Forms;

namespace SpellEffect
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/melharfi/SpellEffect");
        }
    }
}