using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Common;

namespace AdventOfCode
{
    public partial class AdventOfCode : Form
    {
        public AdventOfCode()
        {
            InitializeComponent();
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            IPuzzle engine = DayProvider.GetPuzzle(int.Parse(cboDay.SelectedItem.ToString()), (rbOne.Checked) ? rbOne.Text : rbTwo.Text);
            lblResults.Text = engine.Solve();
        }

        private void AdventOfCode_Load(object sender, EventArgs e)
        {
            cboDay.DataSource = Enumerable.Range(1, 25).ToArray(); 
            cboDay.SelectedIndex = 0;
        }
    }
}
