using System.Windows.Forms;

namespace IC.Client.View.Components.Tests
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            icLabel1.Text = "IC.Client.View.Components.Tests + e.Graphics.ScaleTransform(1.05f, 1.05f);";
        }
    }
}