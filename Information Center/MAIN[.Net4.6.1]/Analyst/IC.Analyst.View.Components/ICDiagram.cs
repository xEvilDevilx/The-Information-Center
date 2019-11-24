using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IC.Analyst.View.Components
{
    /// <summary>
    /// Presents IC Diagramm User Control functionality
    /// 
    /// 2018/02/14 - Created, VTyagunov
    /// </summary>
    public partial class ICDiagram : UserControl
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ICDiagram()
        {
            InitializeComponent();

            Diagram.Series[0].Points.Clear();
            Diagram.Series[1].Points.Clear();
        }

        #endregion

        #region Methods

        #region Event Handler

        /// <summary>
        /// Alignment Load Event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlignmentLoadEvent(object sender, EventArgs e)
        {
            AlignmentCombo.SelectedIndex = 0;
            ChangeAlignment();
        }

        /// <summary>
        /// Palette Load Event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaletteLoadEvent(object sender, EventArgs e)
        {
            foreach (var value in Enum.GetValues(typeof(ChartColorPalette)))
                cbPalette.Items.Add(value);

            cbPalette.SelectedIndex = (int)ChartColorPalette.Berry;
            ChangePalette();
        }

        /// <summary>
        /// Alignment Selected Index Changed event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBAlignmentSelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeAlignment();
        }

        /// <summary>
        /// Palette Selected Index Changed event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBPaletteSelectedIndexChanged(object sender, EventArgs e)
        {
            ChangePalette();
        }

        /// <summary>
        /// Diagram 1 Checked Changed event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBDiagram1CheckedChanged(object sender, EventArgs e)
        {
            UpdateDiagramSettings();
        }

        /// <summary>
        /// Diagram 2 Checked Changed event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBDiagram2CheckedChanged(object sender, EventArgs e)
        {
            UpdateDiagramSettings();
        }

        #endregion
        
        /// <summary>
        /// Use for Change Palette
        /// </summary>
        private void ChangePalette()
        {
            Diagram.Palette = (ChartColorPalette)cbPalette.SelectedIndex;
        }

        /// <summary>
        /// Use for Update Column data points
        /// </summary>
        /// <param name="points">Doubke points array</param>
        /// <param name="xValueDT">X Value data time</param>
        public void UpdateColumnDataPoints(double[] points, DateTime xValueDT)
        {
            var dt = xValueDT;
            Diagram.Series[0].Points.Clear();
            Diagram.Series[0].XValueType = ChartValueType.DateTime;            
            Diagram.Series[0].Points.AddXY(dt, points[0]);
            
            for (int i = 1; i < points.Length; i++)
            {
                dt = dt.AddDays(1);
                Diagram.Series[0].Points.AddXY(dt, points[i]);
            }
        }

        /// <summary>
        /// Use for Update Spline data points
        /// </summary>
        /// <param name="points">Doubke points array</param>
        /// <param name="xValueDT">X Value data time</param>
        public void UpdateSplineDataPoints(double[] points, DateTime xValueDT)
        {
            var dt = xValueDT;
            Diagram.Series[1].Points.Clear();
            Diagram.Series[1].XValueType = ChartValueType.DateTime;
            Diagram.Series[1].Points.AddXY(dt, points[0]);

            for (int i = 1; i < points.Length; i++)
            {
                dt = dt.AddDays(1);
                Diagram.Series[1].Points.AddXY(dt, points[i]);
            }
        }

        /// <summary>
        /// Use for Change Alignment
        /// </summary>
        private void ChangeAlignment()
        {
            if (AlignmentCombo.SelectedItem == null)
                return;
            
            if (AlignmentCombo.GetItemText(AlignmentCombo.SelectedItem) == "Vertically")
            {
                Diagram.ChartAreas["Chart Area 2"].AlignmentOrientation = AreaAlignmentOrientations.Vertical;

                Diagram.ChartAreas["Default"].AxisX.LabelStyle.Enabled = false;
                Diagram.ChartAreas["Default"].AxisX.MajorTickMark.Enabled = false;

                Diagram.ChartAreas["Chart Area 2"].AxisY.LabelStyle.Enabled = true;
                Diagram.ChartAreas["Chart Area 2"].AxisY.MajorTickMark.Enabled = true;

                Diagram.ChartAreas["Chart Area 2"].AxisY.Enabled = AxisEnabled.True;

                Diagram.ChartAreas["Chart Area 2"].AxisY2.Enabled = AxisEnabled.False;

                Diagram.ChartAreas["Default"].AxisY.LabelStyle.IsEndLabelVisible = false;
                Diagram.ChartAreas["Chart Area 2"].AxisY.LabelStyle.IsEndLabelVisible = false;

                Diagram.ChartAreas["Default"].Position.X = 5;
                Diagram.ChartAreas["Default"].Position.Y = 10;
                Diagram.ChartAreas["Default"].Position.Width = 85;
                Diagram.ChartAreas["Default"].Position.Height = 40;

                Diagram.ChartAreas["Chart Area 2"].Position.X = 5;
                Diagram.ChartAreas["Chart Area 2"].Position.Y = 50;
                Diagram.ChartAreas["Chart Area 2"].Position.Width = 85;
                Diagram.ChartAreas["Chart Area 2"].Position.Height = 40;
            }
            else
            {
                Diagram.ChartAreas["Chart Area 2"].AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

                Diagram.ChartAreas["Chart Area 2"].AxisY.LabelStyle.Enabled = false;
                Diagram.ChartAreas["Chart Area 2"].AxisY.MajorTickMark.Enabled = false;

                Diagram.ChartAreas["Default"].AxisX.LabelStyle.Enabled = true;

                Diagram.ChartAreas["Chart Area 2"].AxisY2.Enabled = AxisEnabled.True;

                Diagram.ChartAreas["Default"].AxisY.Maximum = 10;
                Diagram.ChartAreas["Chart Area 2"].AxisY.Maximum = 10;

                Diagram.ChartAreas["Default"].AxisX.LabelStyle.IsEndLabelVisible = false;
                Diagram.ChartAreas["Default"].AxisY.LabelStyle.IsEndLabelVisible = true;
                Diagram.ChartAreas["Chart Area 2"].AxisX.LabelStyle.IsEndLabelVisible = false;

                Diagram.ChartAreas["Default"].Position.X = 5;
                Diagram.ChartAreas["Default"].Position.Y = 10;
                Diagram.ChartAreas["Default"].Position.Width = 45;
                Diagram.ChartAreas["Default"].Position.Height = 80;

                Diagram.ChartAreas["Chart Area 2"].Position.X = 50;
                Diagram.ChartAreas["Chart Area 2"].Position.Y = 10;
                Diagram.ChartAreas["Chart Area 2"].Position.Width = 45;
                Diagram.ChartAreas["Chart Area 2"].Position.Height = 80;
            }
        }

        /// <summary>
        /// Use for Update Diagram Settings
        /// </summary>
        private void UpdateDiagramSettings()
        {
            if ((cbShowDiagram2.Checked) && (cbShowDiagram1.Checked))
            {
                this.AlignmentCombo.Enabled = true;
                Diagram.ChartAreas["Default"].Visible = true;
                Diagram.ChartAreas["Chart Area 2"].Visible = true;
                this.ChangeAlignment();
            }
            else if ((!cbShowDiagram2.Checked) && (cbShowDiagram1.Checked))
            {
                this.AlignmentCombo.Enabled = false;

                Diagram.ChartAreas["Chart Area 2"].Visible = false;

                Diagram.ChartAreas["Default"].Visible = true;
                Diagram.ChartAreas["Default"].Position.Auto = true;
                Diagram.ChartAreas["Default"].InnerPlotPosition.Auto = true;

                Diagram.ChartAreas["Default"].AxisX.LabelStyle.Enabled = true;
                Diagram.ChartAreas["Default"].AxisX.MajorTickMark.Enabled = true;
            }
            else if ((cbShowDiagram2.Checked) && (!cbShowDiagram1.Checked))
            {
                this.AlignmentCombo.Enabled = false;

                Diagram.ChartAreas["Default"].Visible = false;

                Diagram.ChartAreas["Chart Area 2"].Visible = true;
                Diagram.ChartAreas["Chart Area 2"].Position.Auto = true;
                Diagram.ChartAreas["Chart Area 2"].InnerPlotPosition.Auto = true;
            }
            else if ((!cbShowDiagram2.Checked) && (!cbShowDiagram1.Checked))
            {
                this.AlignmentCombo.Enabled = false;

                Diagram.ChartAreas["Default"].Visible = false;
                Diagram.ChartAreas["Chart Area 2"].Visible = false;
            }
        }

        #endregion
    }
}