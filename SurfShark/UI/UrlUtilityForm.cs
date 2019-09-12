using JHSEngine.Interfaces;
using JHSEngine.Patterns.Mediator;
using SurfShark.Core;
using SurfSharkServer.Communication.Packets.Data;
using SurfSharkServer.Network.Enums;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SurfShark.Core.Constants.ProgramConst;

namespace SurfShark
{
    public partial class UrlUtilityForm : JMediator
    {
        private bool Block = false;
        public UrlUtilityForm()
        {
            InitializeComponent();
        }

        private bool CheckURLValid(string source)
        {
            bool test = Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
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

        private bool CheckUrlAlredyExists(string source)
        {
            string newUrl = source.ToString().Trim().ToLower();
            foreach (SiteClass site in SitesManager.Sites)
            {
                string OldUrl = site.Url.ToString().Trim().ToLower();
                if (newUrl.Equals(OldUrl))
                {
                    return true;
                }
            }
            return false;
        }

        public void InitializeEditor()
        {
            Block = true;
            int index = 0;
            if (SitesDataGrid.CurrentCell != null && SitesDataGrid.CurrentCell.RowIndex >= 0)
            {
                index = SitesDataGrid.CurrentCell.RowIndex;
            }
            SitesDataGrid.Rows.Clear();

            foreach (SiteClass site in SitesManager.Sites)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(SitesDataGrid);
                row.Cells[0].Value = site.WebsiteName;
                row.Tag = site.SiteIndex;
                SitesDataGrid.Rows.Add(row);
            }
            if (index >= SitesDataGrid.Rows.Count)
                index = SitesDataGrid.Rows.Count - 1;

            if (index > 0)
            {
                SitesDataGrid.Rows[index].Selected = true;
                SitesDataGrid.CurrentCell = SitesDataGrid.Rows[index].Cells[0];
            }

            region.Items.Clear();

            foreach (string c in Enum.GetNames(typeof(CountryList)))
                region.Items.Add(c);

            Referral.Items.Clear();

            foreach (string c in Enum.GetNames(typeof(ReferralType)))
                Referral.Items.Add(c);

            Block = false;
            ListBox1_SelectionChanged(null,null);
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
            if (Block) return;
            try
            {
                int total_items = SitesDataGrid.Rows.Count;
                if (total_items < MainCache.MaxSlots)
                {
                    SitesManager.AddNew();
                    InitializeEditor();
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
            if (Block) return;
            if (SitesDataGrid.CurrentCell != null && SitesDataGrid.CurrentCell.RowIndex >= 0)
            {
                int selected = (int)SitesDataGrid.Rows[SitesDataGrid.CurrentCell.RowIndex].Tag;
                SiteClass site = SitesManager.GetByIndex(selected);
                if (site != null)
                {
                    site.IsActive = site.IsActive ? false : true;
                    if (site.operation != UpdateOperation.ADD_NEW)
                        site.operation = UpdateOperation.CHANGED;

                    SitesManager.UpdateSite(site);
                }

            }
            else
            {

                MessageBox.Show("Please select a site!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Block) return;
            if (SitesDataGrid.CurrentCell != null && SitesDataGrid.CurrentCell.RowIndex >= 0)
            {
                int selected = (int)SitesDataGrid.Rows[SitesDataGrid.CurrentCell.RowIndex].Tag;
                if (ConfirmDelete() == true)
                {
                    SiteClass site = SitesManager.GetByIndex(selected);
                    if (site != null)
                    {
                        if (site.operation == UpdateOperation.ADD_NEW)
                        {
                            SitesManager.Delete(site);
                        }
                        else
                        {
                            site.operation = UpdateOperation.DELETE;
                            SitesManager.UpdateSite(site);
                        }
                    }
                    InitializeEditor();
                }
            }
            else
            {

                MessageBox.Show("Please select a site!");
            }

        }

        public static bool ConfirmDelete()
        {
            const string message = "Are you sure you want to delete this site?";
            const string caption = "Question:";
            var result = MessageBox.Show(message, caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                return true;
            else
                return false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Block) return;
            if (SitesDataGrid.CurrentCell != null && SitesDataGrid.CurrentCell.RowIndex >= 0)
            {
                int selected = (int)SitesDataGrid.Rows[SitesDataGrid.CurrentCell.RowIndex].Tag;
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
                SiteClass site = SitesManager.GetByIndex(selected);
                if (site != null)
                {
                    site.WebsiteName = nameInpx;
                    site.Url = websiteInpx;
                    site.Time = (uint)secondsDrop.Value;
                    site.Region = (CountryList)region.SelectedIndex;
                    site.Referral = (ReferralType)Referral.SelectedIndex;
                    if (site.operation != UpdateOperation.ADD_NEW)
                        site.operation = UpdateOperation.CHANGED;

                    SitesManager.UpdateSite(site);
                    InitializeEditor();
                }
            }

        }

        #region HELP
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
            if (Block) return;
            if (SitesDataGrid.CurrentCell != null && SitesDataGrid.CurrentCell.RowIndex >= 0)
            {
                Preview pv = new Preview();
                pv.Show();
                pv.Navigate_to(websiteInp.Text);
            }
        }

        private void ListBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (Block) return;
            if (SitesDataGrid.CurrentCell != null && SitesDataGrid.CurrentCell.RowIndex >= 0)
            {
                 int selected = (int)SitesDataGrid.Rows[SitesDataGrid.CurrentCell.RowIndex].Tag;
                SiteClass site = SitesManager.GetByIndex(selected);
                if (site != null)
                {
                    nameInp.Text = site.WebsiteName;
                    websiteInp.Text = site.Url;
                    secondsDrop.Value = site.Time;
                    hitsLabel.Text = site.ViewCount.ToString();
                    btnPause.Text = site.IsActive ? "Start" : "Pause";
                    AlexaRankLabel.Text = GetAlexa(site.Url);
                    region.SelectedIndex =  (int)site.Region >= 255 ? 0 : (int)site.Region;
                    Referral.SelectedIndex = (int)site.Referral >= 255 ? 0 : (int)site.Referral;
                    labelStatus.Text = site.IsActive ? "Paused" : "Started";
                }
            }
        }

        private void UrlUtilityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MainComponent.Core.SendNotification(DO_UPDATE_SITES);
            MainComponent.Core.SendNotification(SHOW_URL_EDITOR);
        }

        public override string[] ListNotificationInterests()
        {
            return new string[] { LOAD_URL_EDITOR };
        }

        public override void HandleNotification(INotification notification)
        {
            switch(notification.Name)
            {
                case LOAD_URL_EDITOR:
                        InitializeEditor();
                    break;
            }
        }
    }
}
