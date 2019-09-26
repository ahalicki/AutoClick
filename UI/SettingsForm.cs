using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoClick
{
    public partial class SettingsForm : Form
    {
        #region Constructors

        public SettingsForm()
        {
            InitializeComponent();

            ReadConfigSettings();
            InitializeControls();

            AcceptButton = btnStart;
        }

        #endregion

        #region Public Properties 

        /// <summary>
        /// Gets a value indicating whether the app should continue or 
        /// was canceled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if continue; otherwise, <c>false</c>.
        /// </value>
        public bool Confirmed { get; private set; }

        /// <summary>
        /// Gets the type of the click.
        /// </summary>
        /// <value>
        /// The type of the click.
        /// </value>
        public ClickType ClickType {get; private set;} = ClickType.Single;

        /// <summary>
        /// Gets the click location.
        /// </summary>
        /// <value>
        /// The click location.
        /// </value>
        public Point ClickLocation { get; private set; } = new Point(100, 100);

        /// <summary>
        /// Gets the number of minutes to wait before clicking again.
        /// </summary>
        /// <value>
        /// The number of minutes to wait.
        /// </value>
        public double WaitMinutes { get; private set; } = 1;

        #endregion

        #region Private Methods

        private void ReadConfigSettings()
        {
            // Initialize any settings from the config file if present.
            try
            {
                var timeSetting = ConfigurationManager.AppSettings["WaitTime"];
                if (timeSetting != null && double.TryParse(timeSetting, out double result))
                {
                    WaitMinutes = result;
                }

                var clickSetting = ConfigurationManager.AppSettings["ClickType"];
                if (clickSetting != null && Enum.TryParse(clickSetting, out ClickType clickType))
                {
                    ClickType = clickType;
                }

                var locationSetting = ConfigurationManager.AppSettings["Location"];
                if(locationSetting == null)
                {
                    return;
                }

                var xyCoordinates = locationSetting.Split(new char[] { ',' });
                if(xyCoordinates.Length != 2)
                {
                    MessageBox.Show("Invalid value read from the config file.\nExpected coordinates in the form \"x,y\"");
                    return;
                }

                ClickLocation = new Point(Convert.ToInt32(xyCoordinates[0]), 
                                          Convert.ToInt32(xyCoordinates[1]));
            }
            catch
            {
                // If we can't read from the config, we can
                // just run with the default values and optionally
                // log it here.
            }
        }

        private void InitializeControls()
        {
            cboClickType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClickType.DataSource = Enum.GetValues(typeof(ClickType));
            cboClickType.SelectedItem = ClickType;

            txtXCoord.Text = ClickLocation.X.ToString();
            txtYCoord.Text = ClickLocation.Y.ToString();

            this.txtClickMins.Text = WaitMinutes.ToString();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (ValidateSettings())
            {
                Confirmed = true;
                this.Close();
            }
        }

        private bool ValidateSettings()
        {
            if(!int.TryParse(txtXCoord.Text, out int x))
            {
                MessageBox.Show(this, "Please enter a valid x-coordinate (integer).", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!int.TryParse(txtYCoord.Text, out int y))
            {
                MessageBox.Show(this, "Please enter a valid y-coordinate (integer).", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!double.TryParse(txtClickMins.Text, out double time))
            {
                MessageBox.Show(this, "Please enter a valid wait time (numeric).", "Invalid entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            ClickLocation = new Point(x, y);
            WaitMinutes = time;

            return true;
        }

        #endregion
    }
}
