using JHSEngine.Patterns.Mediator;
using JHUI.Forms;
using Newtonsoft.Json;
using SurfShark.Communication.Packets;
using SurfShark.Core;
using SurfShark.Core.Constants;
using SurfShark.program;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SurfShark
{
    public partial class UrlUtilityForm : JMediator
    {
        public static UrlUtilityForm LoginDialogInstance;
        public static bool somthing_changed = false;

        public UrlUtilityForm()
        {
            LoginDialogInstance = this;
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
            refInp.Enabled = false;
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
            foreach (SiteClass site in ProgramVars.siteClasses)
            {
                string url = site.url.ToString().Trim().ToLower();
                if (clined.Equals(url) && site.id != index)
                {
                    return true;
                }
            }
            return false;
        }
        private string CleanStr(string strToCheck)
        {
            string newx;
            string[] allowed = new string[] { "=", ".", "-", "_", ",", " ", "[", "]", ":", "+", "|", "!", "%", "&", "@", "/", "*", "?", "#", "'" };
            for (int i = 0; i < allowed.Length; i++)
            {
                strToCheck = strToCheck.Replace(allowed[i].ToString(), "");
            }
            newx = strToCheck;
            return newx;
        }

        private bool IsNumeric(string strToCheck)
        {

            Regex rg = new Regex(@"^[0-9]*$");
            return rg.IsMatch(CleanStr(strToCheck));
        }

        private bool IsAllowed(string strToCheck)
        {

            Regex rg = new Regex(@"^[a-zA-Z0-9]*$");
            return rg.IsMatch(CleanStr(strToCheck));
        }

        public void PopulateList()
        {
            foreach (SiteClass site in ProgramVars.siteClasses)
            {
                listBox1.Items.Add(site.name);
            }
            if (ProgramVars.regions != null)
            {
                region.Items.Clear();
                for (int i = 0; i < ProgramVars.regions.Length; i++)
                {

                    region.Items.Add(ProgramVars.regions[i].ToString());
                }
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

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected >= 0)
            {
                SiteClass site = ProgramVars.siteClasses[selected];
                if (site != null)
                {
                    nameInp.Text = site.name;
                    websiteInp.Text = site.url;
                    refInp.Text = site.refurl;
                    secondsDrop.Value = site.time;
                    hitsLabel.Text = site.click;
                    btnPause.Text = site.state == 0 ? "Start" : "Pause";
                    label9.Text = GetAlexa(site.url);
                    if (int.Parse(site.refurl) == 0 || int.Parse(site.refurl) == 1)
                    {
                        comboBox1.SelectedIndex = int.Parse(site.refurl);
                    }
                    else
                    {
                        comboBox1.SelectedIndex = comboBox1.Items.Count;
                        refInp.Enabled = true;
                    }
                    int index = region.FindString(site.region, -1);
                    if (index != -1)
                    {
                        region.SelectedIndex = index;
                    }
                    else
                    {
                        ProgramVars.siteClasses[selected].region = "International";
                    }
                    label7.Text = ProgramVars.siteClasses[selected].state == 0 ? "Paused" : "Started";

                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int total_items = listBox1.Items.Count;
                int canHave = ProgramVars.type == 0 ? 5 : 30;
                if (total_items < canHave)
                {
                    SiteClass site = new SiteClass();
                   // site.uid = CoreSystem.userID;
                    site.name = "New Site";
                    site.url = "http://www.exemple.com/";
                    site.refurl = "0";
                    site.time = 10;
                    site.click = "0";
                    site.state = 0;
                    ProgramVars.siteClasses.Add(site);
                    listBox1.Items.Add(site.name);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    MessageBox.Show("Your site is added.\nPlease edit the details!");
                    UrlUtilityForm.somthing_changed = true;
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
            int selected = listBox1.SelectedIndex;
            if (selected >= 0)
            {
                int status = ProgramVars.siteClasses[selected].state;
                ProgramVars.siteClasses[selected].state = status == 0 ? 1 : 0;
                btnPause.Text = ProgramVars.siteClasses[selected].state == 0 ? "Start" : "Pause";
                label7.Text = ProgramVars.siteClasses[selected].state == 0 ? "Paused" : "Started";
                UrlUtilityForm.somthing_changed = true;
            }
            else
            {

                MessageBox.Show("Please select a site!");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected >= 0) {
                if (ConfirmDelete() == true)
                {
                    int selectedID = ProgramVars.siteClasses[selected].id;
                    NetworkManager.Send(NetworkConstants.REMOVE_SITE, new RemoveSite() { SiteId = (uint)selectedID });
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
            if (UrlUtilityForm.somthing_changed)
            {
                if (CloseCancel() == true)
                {
                    string data = JsonConvert.SerializeObject(ProgramVars.siteClasses);
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

            int selectedx = listBox1.SelectedIndex;
            if (selectedx >= 0)
            {
                string nameInpx = nameInp.Text;
                if (nameInpx.Length > 20)
                {
                    MessageBox.Show("Site name is too long, max can have 20 characters.");
                    return;
                }
                if (!IsAllowed(nameInpx))
                {
                    MessageBox.Show("Name contains Incorrect Input!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                    return;
                }
                string refInpx = refInp.Text;
                if (refInpx.Length > 200)
                {
                    MessageBox.Show("Referral url is too long, max can have 200 characters.");
                    return;
                }
                if (!IsAllowed(refInpx))
                {
                    MessageBox.Show("Referral url contains Incorrect Input!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                    return;
                }

                string secondsDropx = "" + secondsDrop.Value;
                if (!IsNumeric(secondsDropx))
                {
                    return;
                }

                string websiteInpx = websiteInp.Text;
                if (websiteInpx.Length > 200)
                {
                    MessageBox.Show("Site URL is too long, max can have 200 characters.");
                    return;
                }
                if (!IsAllowed(websiteInpx))
                {
                    MessageBox.Show("Site URL contains Incorrect Input!\nAllowed characters are: A-Z 0-9 [ ] : - + | ! , . % & @ / * _ ? # \'");
                    return;
                }
                if (!CheckURLValid(websiteInpx))
                {
                    MessageBox.Show("Site URL invalid please use somthing like this:http://example.com");
                    return;

                }
                int selected = listBox1.SelectedIndex;
                if (selected >= 0)
                {
                    if (CheckUrlAlredyExists(websiteInpx, ProgramVars.siteClasses[selected].id))
                    {
                        MessageBox.Show("This url already exists in your sites!");
                        return;

                    }
                    ProgramVars.siteClasses[selected].name = nameInpx;
                    ProgramVars.siteClasses[selected].url = websiteInpx;
                    ProgramVars.siteClasses[selected].refurl = refInpx;
                    ProgramVars.siteClasses[selected].time = (int)secondsDrop.Value;
                    somthing_changed = true;
                    listBox1.Items.Clear();
                    PopulateList();
                }
            }

        }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected >= 0)
            {
                Preview pv = new Preview();
                pv.Show();
                pv.Navigate_to(websiteInp.Text);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected >= 0)
            {
                if (comboBox1.SelectedIndex == (comboBox1.Items.Count - 1))
                {
                    refInp.Enabled = true;
                    refInp.Text = "Enter your url here.";
                }
                else
                {
                    if (ProgramVars.siteClasses != null)
                    {
                        ProgramVars.siteClasses[selected].refurl = comboBox1.SelectedIndex.ToString();
                        refInp.Text = "";
                        refInp.Enabled = false;
                        refInp.Text = ProgramVars.siteClasses[selected].refurl;
                    }


                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can express a desire for a particular(country) region and we will do our best to show your site only to those region.");
        }

        private void Region_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selected = listBox1.SelectedIndex;
            if (selected >= 0)
            {
                ProgramVars.siteClasses[selected].region = region.Items[region.SelectedIndex].ToString();
            }
        }
    }
}
