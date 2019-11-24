using System.Windows.Forms;

namespace IC.Client.View.BarcodeReaderEmuForms
{
    /// <summary>
    /// Presents BarCode reader emulator form
    /// 
    /// 2016/12/12 - Created, VTyagunov
    /// </summary>
    public partial class BarCodeReaderEmuForm : Form
    {
        /// <summary>BarCode read handler</summary>
        public delegate void BarCodeReadHandler(string barCodeValue);
        /// <summary>BarCode read event</summary>
        public event BarCodeReadHandler BarCodeReadEvent;

        /// <summary>
        /// Constructor
        /// </summary>
        public BarCodeReaderEmuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Use for read BarCode event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadBarCode_Click(object sender, System.EventArgs e)
        {
            var barCodeValue = BarCodeTextBox.Text;
            BarCodeReadEvent?.Invoke(barCodeValue);
        }

        /// <summary>
        /// Use for check BarCode text box change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarCodeTextBox_TextChanged(object sender, System.EventArgs e)
        {
            if ((string.IsNullOrEmpty(BarCodeTextBox.Text)) || 
                (string.IsNullOrWhiteSpace(BarCodeTextBox.Text)))
                btnReadBarCode.Enabled = false;
            else btnReadBarCode.Enabled = true;
        }
    }
}