using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using IC.Analyst.View.Forms.Properties;
using IC.DB.DataLayer;
using IC.DB.ICSQL;
using IC.DB.ICSQL.Interfaces;

namespace IC.Analyst.View.Forms
{
    /// <summary>
    /// Presents Analyst Form View
    /// 
    /// 2018/02/18 - Created, VTyagunov
    /// </summary>
    public partial class AnalystForm : Form
    {
        #region Variables

        /// <summary>Application Haeder text</summary>
        private string _appHead;
        /// <summary>DB Connection status</summary>
        private bool _isConnected;
        /// <summary>DB Connection string</summary>
        private string _connectionString;
        /// <summary>Batabase object</summary>
        private IDatabase _database;
        /// <summary>ProductLogs list</summary>
        private List<ProductLog> _productLogs;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public AnalystForm()
        {
            InitializeComponent();

            LocalizeAllText();
            _appHead = "IC: Analyst [{0}]";
            this.Text = string.Format(_appHead, "Disconnected");
            _isConnected = false;
            _connectionString = ConfigurationManager.ConnectionStrings["ICDBConnection"].
                ConnectionString;
            _database = new Database(_connectionString);
            tbConnectionString.Text = _connectionString;
            btnShowRange.Enabled = false;
        }

        #endregion

        #region Methods

        #region Events

        /// <summary>
        /// Use for fix data time range 'from' values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value > dtpTo.Value)
                dtpFrom.Value = dtpTo.Value;
        }

        /// <summary>
        /// Use for fix data time range 'to' values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value < dtpFrom.Value)
                dtpTo.Value = dtpFrom.Value;
        }

        /// <summary>
        /// Use for start Connect Click event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        /// <summary>
        /// Use for start Show Range button click event actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowRange_Click(object sender, EventArgs e)
        {
            ShowRange();
        }

        /// <summary>
        /// Use for Set data from tree view Day Node to table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeViewEventArgs e)
        {
            SetDataToGridView();
        }

        #endregion

        /// <summary>
        /// Use for Localize all app text
        /// </summary>
        private void LocalizeAllText()
        {
            lblConnectionString.Text = Resources.lblConnectionString;
            lblDateRange.Text = Resources.lblDateRange;
            lblFrom.Text = Resources.lblFrom;
            lblTo.Text = Resources.lblTo;
            btnConnect.Text = Resources.btnConnect;
            btnShowRange.Text = Resources.btnShowRange;
            tpDiagram.Text = Resources.tpDiagram;
            tpTreeView.Text = Resources.tpTreeView;
        }

        /// <summary>
        /// Use for Connect to DB
        /// </summary>
        private void Connect()
        {
            try
            {
                if (!_isConnected)
                {
                    _database.OpenConnection();
                    UpdateConnectionStatus("Connected", "Disconnect", true, true);
                }
                else
                {
                    _database.CloseConnection();
                    UpdateConnectionStatus("Disconnected", "Connect", false, false);
                }
            }
            catch (Exception ex)
            {
                // Log...
                UpdateConnectionStatus("Disconnected", "Connect", false, false);
            }
        }

        /// <summary>
        /// Use for Show Range of Product Logs
        /// </summary>
        private void ShowRange()
        {
            _productLogs = GetProductLogsList();
            var tempDate = dtpFrom.Value.Date;
            var capacityTimespan = dtpTo.Value.Date - dtpFrom.Value.Date.AddDays(-1);
            var capacity = capacityTimespan.Days;
            var doubleList = new double[capacity];

            for (int i = 0; i < capacity; i++)
            {
                var count = _productLogs.Select(x => x.ScanDate).Count(x => x.Date == tempDate);
                doubleList[i] = count;
                tempDate = tempDate.AddDays(1.0);
            }

            icDiagram.UpdateColumnDataPoints(doubleList, dtpFrom.Value.Date);
            icDiagram.UpdateSplineDataPoints(doubleList, dtpFrom.Value.Date);

            SetTableViewData(_productLogs);
        }

        /// <summary>
        /// Use for Update Connection Status
        /// </summary>
        /// <param name="connectionStatus">Connection Status</param>
        /// <param name="btnConnectName">Name of button Connect</param>
        /// <param name="isEnableBtnShowRange">Enable status of button Show Range</param>
        /// <param name="isConnected">Connected status boolean</param>
        private void UpdateConnectionStatus(string connectionStatus, string btnConnectName,
            bool isEnableBtnShowRange, bool isConnected)
        {
            this.Text = string.Format(_appHead, connectionStatus);
            btnConnect.Text = btnConnectName;
            btnShowRange.Enabled = isEnableBtnShowRange;
            _isConnected = isConnected;
        }

        /// <summary>
        /// Use for Set Data to Table grid view from tree view Day Node
        /// </summary>
        private void SetDataToGridView()
        {
            var fullPath = tvDate.SelectedNode.FullPath;
            if (fullPath.Count(c => c == '\\') < 2)
                return;

            var dtStr = fullPath.Replace("\\", "-");
            var dt = Convert.ToDateTime(dtStr);
            var productLogs = _productLogs.Where(x => x.ScanDate.Date == dt);

            dgvProducts.Rows.Clear();
            var tempIDList = new Dictionary<ProductLog, int>();
            foreach (var productLog in productLogs)
            {
                if (tempIDList.Keys.Count(x => x.ProductID == productLog.ProductID) < 1)
                    tempIDList.Add(productLog, 1);
                else if (!tempIDList.Keys.Where(x => x.ProductID == productLog.ProductID).ToList().Exists(x => x.TerminalID == productLog.TerminalID))
                    tempIDList.Add(productLog, 1);
                else
                {
                    var key = tempIDList.Keys.First(x => x.ProductID == productLog.ProductID && x.TerminalID == productLog.TerminalID);
                    tempIDList[key]++;
                }
            }

            var temp = tempIDList.OrderBy(x => x.Key.ProductID);
            foreach (var item in temp)
                dgvProducts.Rows.Add(item.Key.ProductID, item.Key.TerminalID, item.Key.LanguageCode, item.Key.CurrencyCode, item.Value);
        }

        /// <summary>
        /// Use for Set table View data
        /// </summary>
        /// <param name="productLogs">Product Log object</param>
        private void SetTableViewData(List<ProductLog> productLogs)
        {
            foreach(var productLog in productLogs)
            {
                var year = productLog.ScanDate.Year;
                string month = productLog.ScanDate.ToString("MMMM", CultureInfo.InvariantCulture);
                int day = productLog.ScanDate.Day;
                
                if (!tvDate.Nodes.ContainsKey(year.ToString()))
                    tvDate.Nodes.Add(year.ToString(), year.ToString());

                if (!tvDate.Nodes[year.ToString()].Nodes.ContainsKey(month))
                    tvDate.Nodes[year.ToString()].Nodes.Add(month, month);

                if (!tvDate.Nodes[year.ToString()].Nodes[month].Nodes.ContainsKey(day.ToString()))
                    tvDate.Nodes[year.ToString()].Nodes[month].Nodes.Add(day.ToString(), day.ToString());
            }

            tvDate.AfterSelect += treeView1_NodeMouseClick;
        }

        /// <summary>
        /// Use for Get Product Logs list
        /// </summary>
        /// <returns></returns>
        private List<ProductLog> GetProductLogsList()
        {
            try
            {
                var dtpFromDT = dtpFrom.Value.ToString("yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
                var dtpToDT = dtpTo.Value.ToString("yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);

                var sqlQuery =
                    string.Format("SELECT * FROM [dbo].[ProductLog] WHERE convert(date,[ScanDate]) >= '{0}' AND convert(date,[ScanDate]) <= '{1}';",
                    dtpFromDT, dtpToDT);
                _database.BeginTransaction();
                var productLogs = _database.ExecuteList<ProductLog>(sqlQuery, CommandType.Text, 
                    new SqlParameter[0], ProductLogPopulator);
                _database.Commit();

                return productLogs;
            }
            catch(Exception ex)
            {
                throw;
                // Log...
            }
        }

        /// <summary>
        /// Use for populate ProductLog object
        /// </summary>
        /// <param name="reader">SqlDataReader object</param>
        /// <returns></returns>
        private ProductLog ProductLogPopulator(SqlDataReader reader)
        {
            var productLog = new ProductLog()
            {
                CurrencyCode = reader["CurrencyCode"] as string,
                LanguageCode = reader["LanguageCode"] as string,
                ProductID = (int)reader["ProductID"],
                ProductLogID = (int)reader["ProductLogID"],
                ScanDate = (DateTime)reader["ScanDate"],
                TerminalID = reader["TerminalID"] as string
            };

            return productLog;
        }

        #endregion
    }
}