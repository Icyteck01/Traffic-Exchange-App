using CommonDB;
using JHSEngine.Patterns.Mediator;
using Newtonsoft.Json;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfShark.Core.Constants;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.Network.Enums;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SurfShark
{
    public partial class UrlUtilityForm : JMediator
    {
        public UrlUtilityForm()
        {
            InitializeComponent();
            PopulateList();
            ToolTip toolTip1 = new ToolTip
            {

                // Set up the delays for the ToolTip.
                AutoPopDelay = 5000,
                InitialDelay = 100,
                ReshowDelay = 500,
                // Force the ToolTip text to be displayed whether or not the form is active.
                ShowAlways = true
            };

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button7, "Please enter the Name of the Website you wish to promote.");
            toolTip1.SetToolTip(this.button6, "Please enter the Address of the Website you wish you promote.");
            toolTip1.SetToolTip(this.button5, "Choose the traffic source, this will show up as the origin of the Traffic.\nYou can leave it blank for Direct/Anonymous visit.");
            toolTip1.SetToolTip(this.button4, "Specifiy the length of the visit in seconds.");
            //refInp.Enabled = false;
        }

        private bool CheckURLValid(string source)
        {
            Uri uriResult;
            bool test = Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
            bool test2 = Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;

            if (test)
            {
                return true;
            }
            if (test2)
            {
                return true;
            }

            return false;
        }

        private bool CheckUrlAlredyExists(string source, int index)
        {
            string clined = source.ToString().Trim().ToLower();
            foreach (SiteClass site in MainCache.Urs)
            {
                string url = site.Url.ToString().Trim().ToLower();
                if (clined.Equals(url) && site.UID != index)
                {
                    return true;
                }
            }
            return false;
        }

        public void PopulateList()
        {
            foreach (SiteClass site in MainCache.Urs)
            {
                listBox1.Rows.Add(site.WebsiteName);
            }
            region.Items.Clear();
            foreach(string c in Enum.GetNames(typeof(CountryList)) )
            {

                region.Items.Add(c);
            }
            Referral.Items.Clear();
            foreach (string c in Enum.GetNames(typeof(ReferralType)))
            {

                Referral.Items.Add(c);
            }

        }
        public string GetAlexa(string URL)
        {
            string AlexaRank = "N/A";
            WebRequest request = WebRequest.Create("http://data.alexa.com/data?cli=10&dat=snbamz&url=" + URL);
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Regex rankRegex = new Regex("<REACH RANK=\"(.*)\"/>");
                Match match = rankRegex.Match(line);
                if (match.Success)
                {
                    AlexaRank = match.Groups[1].Value.ToString();
                }
            }
            sr.Close();
            return AlexaRank;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int total_items = listBox1.Rows.Count;
                if (total_items < 5)
                {

                }
                else
                {
                    MessageBox.Show("Sorry you reached the maximum Urls for your membership!\nPlease Upgrade to Super Shark to have unlimited slots for life!");

                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }

        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                uint status = MainCache.Urs[selected].UID;

            }
            else
            {

                MessageBox.Show("Please select a site!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                if (ConfirmDelete() == true)
                {
                   // int selectedID = MainCache.Urs[selected].id;
                 //   NetworkManager.Send(NetworkConstants.REMOVE_SITE, new RemoveSite() { SiteId = (uint)selectedID });
                   // CoreSystem.main.NetSend("" + selectedID, NetworkConstants.REMOVE_SITE, NetworkCommands.cmd2);
                   // PopulateList();
                }


            } else {

                MessageBox.Show("Please select a site!");
            }

        }

        public static bool ConfirmDelete()
        {
            const string message = "Are you sure you want to delete this site?";
            const string caption = "Question:";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void UrlUtilityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (UrlUtilityForm.somthing_changed)
            {
                if (CloseCancel() == true)
                {
                    string data = JsonConvert.SerializeObject(MainCache.Urs);
                    string encoded = Encrypt.Encode(data);
                    LoginInfo li = new LoginInfo
                    {
                        password = encoded,
                        username = ""
                    };
                    var sz = JsonConvert.SerializeObject(li).ToString();
                 //   CoreSystem.main.NetSend(sz, NetworkConstants.ADD_SITE, NetworkCommands.cmd1);
                    MessageBox.Show("Changes saved!");
                    UrlUtilityForm.somthing_changed = false;
                }
            }

            MainComponent.Core.SendNotification(ProgramConst.EVENT_RESIZE);
           // CoreSystem.isUtilOpen = false;
            this.Hide();
            */
        }

        public static bool CloseCancel()
        {
            const string message = "Would you like to save changes?";
            const string caption = "Question:";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                string nameInpx = nameInp.Text;
                if (nameInpx.Length > 20)
                {
                    MessageBox.Show("Site name is too long, max can have 20 characters.");
                    return;
                }

                string websiteInpx = websiteInp.Text;
                if (websiteInpx.Length > 200)
                {
                    MessageBox.Show("Site URL is too long, max can have 200 characters.");
                    return;
                }

                if (!CheckURLValid(websiteInpx))
                {
                    MessageBox.Show("Site URL invalid please use somthing like this:http://example.com");
                    return;
                }
                /*
                if (selected >= 0)
                {
                    if (CheckUrlAlredyExists(websiteInpx, MainCache.Urs[selected].UID))
                    {
                        MessageBox.Show("This url already exists in your sites!");
                        return;

                    }
                 //   MainCache.Urs[selected].name = nameInpx;
                 //   MainCache.Urs[selected].url = websiteInpx;
                 //   MainCache.Urs[selected].refurl = refInpx;
                 //   MainCache.Urs[selected].time = (int)secondsDrop.Value;
                 //   somthing_changed = true;
                    listBox1.Rows.Clear();
                    PopulateList();
                   
                } */
            }

        }

        #region HELP
        private void Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter the Name of the Website you wish to promote.");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please enter the Address of the Website you wish you promote.");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose the traffic source, this will show up as the origin of the Traffic.\nYou can leave it blank for Direct/Anonymous visit.");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Specifiy the length of the visit in seconds.");
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can express a desire for a particular(country) region and we will do our best to show your site only to those region.");
        }
        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                Preview pv = new Preview();
                pv.Show();
                pv.Navigate_to(websiteInp.Text);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                MainCache.Urs[selected].Referral = (ReferralType)Referral.SelectedIndex;
            }
        }

        private void Region_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                MainCache.Urs[selected].Region = (CountryList)region.SelectedIndex;
            }
        }

        private void ListBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (listBox1.CurrentCell != null && listBox1.CurrentCell.RowIndex >= 0)
            {
                int selected = listBox1.CurrentCell.RowIndex;
                SiteClass site = MainCache.Urs[selected];
                if (site != null)
                {
                    nameInp.Text = site.WebsiteName;
                    websiteInp.Text = site.Url;
                    secondsDrop.Value = site.Time;
                    hitsLabel.Text = site.ViewCount.ToString();
                    btnPause.Text = site.IsActive ? "Start" : "Pause";
                    AlexaRankLabel.Text = GetAlexa(site.Url);
                    region.SelectedIndex = (int)site.Region;
                    Referral.SelectedIndex = (int)site.Referral;
                    labelStatus.Text = site.IsActive ? "Paused" : "Started";
                }
            }
        }
    }
}
