namespace IC.Client.View.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timer1 = new System.Windows.Forms.Timer();
            this.barcodeReader = new Barcode.Barcode();
            this.imgBackground = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // barcodeReader
            // 
            this.barcodeReader.BufferSize = 7905;
            this.barcodeReader.DecoderParameters.CODABAR = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.CODABARParams.ClsiEditing = false;
            this.barcodeReader.DecoderParameters.CODABARParams.NotisEditing = false;
            this.barcodeReader.DecoderParameters.CODABARParams.Redundancy = true;
            this.barcodeReader.DecoderParameters.CODE128 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.CODE128Params.EAN128 = true;
            this.barcodeReader.DecoderParameters.CODE128Params.ISBT128 = true;
            this.barcodeReader.DecoderParameters.CODE128Params.Other128 = true;
            this.barcodeReader.DecoderParameters.CODE128Params.Redundancy = false;
            this.barcodeReader.DecoderParameters.CODE39 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.CODE39Params.Code32Prefix = false;
            this.barcodeReader.DecoderParameters.CODE39Params.Concatenation = false;
            this.barcodeReader.DecoderParameters.CODE39Params.ConvertToCode32 = false;
            this.barcodeReader.DecoderParameters.CODE39Params.FullAscii = false;
            this.barcodeReader.DecoderParameters.CODE39Params.Redundancy = false;
            this.barcodeReader.DecoderParameters.CODE39Params.ReportCheckDigit = false;
            this.barcodeReader.DecoderParameters.CODE39Params.VerifyCheckDigit = false;
            this.barcodeReader.DecoderParameters.CODE93 = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.DecoderParameters.CODE93Params.Redundancy = false;
            this.barcodeReader.DecoderParameters.D2OF5 = Barcode.DisabledEnabled.Disabled;
            this.barcodeReader.DecoderParameters.D2OF5Params.Redundancy = true;
            this.barcodeReader.DecoderParameters.EAN13 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.EAN8 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.EAN8Params.ConvertToEAN13 = false;
            this.barcodeReader.DecoderParameters.I2OF5 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.I2OF5Params.CheckDigitScheme = Symbol.Barcode.I2OF5.CheckDigitSchemes.None;
            this.barcodeReader.DecoderParameters.I2OF5Params.ConvertToEAN13 = false;
            this.barcodeReader.DecoderParameters.I2OF5Params.Redundancy = true;
            this.barcodeReader.DecoderParameters.I2OF5Params.ReportCheckDigit = false;
            this.barcodeReader.DecoderParameters.KOREAN_3OF5 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.MSI = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.MSIParams.CheckDigitCount = Symbol.Barcode.MSI.CheckDigitCounts.One;
            this.barcodeReader.DecoderParameters.MSIParams.CheckDigitScheme = Symbol.Barcode.MSI.CheckDigitSchemes.Mod_11_10;
            this.barcodeReader.DecoderParameters.MSIParams.Redundancy = true;
            this.barcodeReader.DecoderParameters.MSIParams.ReportCheckDigit = false;
            this.barcodeReader.DecoderParameters.UPCA = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.UPCAParams.Preamble = Symbol.Barcode.UPC.Preambles.System;
            this.barcodeReader.DecoderParameters.UPCAParams.ReportCheckDigit = true;
            this.barcodeReader.DecoderParameters.UPCE0 = Barcode.DisabledEnabled.Enabled;
            this.barcodeReader.DecoderParameters.UPCE0Params.ConvertToUPCA = false;
            this.barcodeReader.DecoderParameters.UPCE0Params.Preamble = Symbol.Barcode.UPC.Preambles.None;
            this.barcodeReader.DecoderParameters.UPCE0Params.ReportCheckDigit = false;
            this.barcodeReader.DeviceName = null;
            this.barcodeReader.EnableScanner = false;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ContactSpecific.InitialScanTime = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ContactSpecific.PulseDelay = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ContactSpecific.QuietZoneRatio = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.AimDuration = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.AimMode = Barcode.AIM_MODE.AIM_MODE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.AimType = Barcode.AIM_TYPE.AIM_TYPE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.BeamTimer = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.DPMMode = Barcode.DPM_MODE.DPM_MODE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusMode = Barcode.FOCUS_MODE.FOCUS_MODE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.FocusPosition = Barcode.FOCUS_POSITION.FOCUS_POSITION_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.IlluminationMode = Barcode.ILLUMINATION_MODE.ILLUMINATION_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCaptureTimeout = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.ImageCompressionTimeout = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.Inverse1DMode = Barcode.INVERSE1D_MODE.INVERSE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.LinearSecurityLevel = Barcode.LINEAR_SECURITY_LEVEL.SECURITY_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistMode = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.PicklistModeEx = Barcode.PICKLIST_MODE.PICKLIST_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.PointerTimer = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.PoorQuality1DMode = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedback = Barcode.VIEWFINDER_FEEDBACK.VIEWFINDER_FEEDBACK_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFFeedbackTime = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFMode = Barcode.VIEWFINDER_MODE.VIEWFINDER_MODE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Bottom = 0;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Left = 0;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Right = 0;
            this.barcodeReader.ReaderParameters.ReaderSpecific.ImagerSpecific.VFPosition.Top = 0;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.AimDuration = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.AimMode = Barcode.AIM_MODE.AIM_MODE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.AimType = Barcode.AIM_TYPE.AIM_TYPE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.BeamTimer = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.BidirRedundancy = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.ControlScanLed = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.DBPMode = Barcode.DBP_MODE.DBP_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.KlasseEinsEnable = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.LinearSecurityLevel = Barcode.LINEAR_SECURITY_LEVEL.SECURITY_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.NarrowBeam = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.PointerTimer = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.RasterHeight = -1;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.RasterMode = Barcode.RASTER_MODE.RASTER_MODE_UNDEFINED;
            this.barcodeReader.ReaderParameters.ReaderSpecific.LaserSpecific.ScanLedLogicLevel = Barcode.DisabledEnabled.Undefined;
            this.barcodeReader.ScanParameters.BeepFrequency = 2670;
            this.barcodeReader.ScanParameters.BeepTime = 200;
            this.barcodeReader.ScanParameters.CodeIdType = Barcode.CodeIdTypes.None;
            this.barcodeReader.ScanParameters.LedTime = 3000;
            this.barcodeReader.ScanParameters.ScanType = Barcode.ScanTypes.Foreground;
            this.barcodeReader.ScanParameters.WaveFile = "";
            this.barcodeReader.OnRead += new Barcode.Barcode.ScannerReadEventHandler(this.BarcodeReader_OnRead);
            // 
            // imgBackground
            // 
            this.imgBackground.Location = new System.Drawing.Point(0, 0);
            this.imgBackground.Name = "imgBackground";
            this.imgBackground.Size = new System.Drawing.Size(800, 480);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.ControlBox = false;
            this.Controls.Add(this.imgBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Information Center";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Barcode.Barcode barcodeReader;
        private System.Windows.Forms.PictureBox imgBackground;
    }
}

