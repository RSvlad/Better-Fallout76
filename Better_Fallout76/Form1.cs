using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Better_Fallout76
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Background Images
            Image photo1 = Properties.Resources.Photo_2020_12_23_130333;
            Image photo2 = Properties.Resources.Photo_2021_01_08_154948;
            Image photo3 = Properties.Resources.Photo_2021_02_01_192508;
            Image photo4 = Properties.Resources.Photo_2021_06_21_164219;
            Image photo5 = Properties.Resources.Photo_2021_06_27_155518;
            Image photo6 = Properties.Resources.Photo_2021_06_28_135608;
            Image photo7 = Properties.Resources.Photo_2021_06_28_171035;
            Image photo8 = Properties.Resources.Photo_2021_07_01_100839;
            Image photo9 = Properties.Resources.Photo_2021_07_01_142440;
            Image photo10 = Properties.Resources.Photo_2021_07_05_205438;
            Image photo11 = Properties.Resources.Photo_2021_07_07_133358;

            var images = new Image[11] { photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11 };
            Random rand = new Random();
            BackgroundImage = images[rand.Next(0, images.Length)];
        }

        private void Hide_UI_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                panel1.Enabled = false;
                panel1.Dock = DockStyle.Fill;
            }
            else
            {
                panel1.Visible = true;
                panel1.Enabled = true;
                panel1.Dock = DockStyle.None;
                panel1.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            }

            if (GenerateButton.Visible)
            {
                GenerateButton.Visible = false;
                GenerateButton.Enabled = false;
                GenerateButton.Dock = DockStyle.Fill;
            }
            else
            {
                GenerateButton.Visible = true;
                GenerateButton.Enabled = true;
                GenerateButton.Dock = DockStyle.None;
                GenerateButton.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            }

            if (Close.Visible)
            {
                Close.Visible = false;
                Close.Enabled = false;
                Close.Dock = DockStyle.Fill;
            }
            else
            {
                Close.Visible = true;
                Close.Enabled = true;
                Close.Dock = DockStyle.None;
                Close.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right;
            }
        }  // Hide Ui

        private void Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }  // Close the Program

        string filePathCustom;
        string filePathPrefs;

        private void Fallout76Custom_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.Filter = "ini files (*.ini)|*.ini";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathCustom = openFileDialog1.FileName;
            }
        }  // Select Fallout76Custom.ini

        private void Fallout76Prefs_Click_1(object sender, EventArgs e)
        {
            openFileDialog2.InitialDirectory = @"c:\";
            openFileDialog2.Filter = "ini files (*.ini)|*.ini";
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                filePathPrefs = openFileDialog2.FileName;
            }
        }  // Select Fallout76Prefs.ini

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            FileAttributes attributesCustom = File.GetAttributes(filePathCustom);
            FileAttributes attributesPrefs = File.GetAttributes(filePathPrefs);

            if ((attributesCustom & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(filePathCustom, attributesCustom & ~FileAttributes.ReadOnly);

            if ((attributesPrefs & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(filePathPrefs, attributesPrefs & ~FileAttributes.ReadOnly);

            string customs = File.ReadAllText(filePathCustom);

            using (StreamWriter w = new StreamWriter(filePathCustom, true))
            {
                bool b0 = customs.Contains("\n# This INI File was made with Better Fallout76 by RSVlad\n\n");
                if (b0 == false)
                {
                    w.Write("\n# This INI File was made with Better Fallout76 by RSVlad\n\n");
                }

                if (checkBox1.Checked)
                {
                    bool b1 = customs.Contains("[ScreenSplatter]\nbBloodSplatterEnabled=0\n");
                    if (b1 == false)
                    {
                        w.Write("[ScreenSplatter]\nbBloodSplatterEnabled=0\n");
                    }
                }
                else
                {
                    customs.Replace("[ScreenSplatter]\nbBloodSplatterEnabled=0\n", "");
                }

                bool bD = customs.Contains("[Display]\n");
                if (bD == false)
                {
                    w.Write("[Display]\n");
                }

                bool bW1 = customs.Contains("iSize W=" + textBox1.Text.ToString() + "\n");
                if (bW1 == false)
                {
                    customs = customs.Replace("iSize W=1280", "iSize W=" + textBox1.Text.ToString() + "\n");
                    customs = customs.Replace("iSize W=1920", "iSize W=" + textBox1.Text.ToString() + "\n");
                }

                bool bH1 = customs.Contains("iSize W=" + textBox2.Text.ToString() + "\n");
                if (bH1 == false)
                {
                    customs = customs.Replace("iSize H=720", "iSize H=" + textBox2.Text.ToString() + "\n");
                    customs = customs.Replace("iSize H=1080", "iSize H=" + textBox2.Text.ToString() + "\n");
                }

                if (checkBox2.Checked)
                {
                    bool b = customs.Contains("[ImageSpace]\nbDoRadialBlur=0\n");
                    if (b == false)
                    {
                        w.Write("[ImageSpace]\nbDoRadialBlur=0\n");
                    }
                }
                else
                {
                    customs.Replace("[ImageSpace]\nbDoRadialBlur=0\n", "");
                }

                bool W = customs.Contains("[Weather]\n");
                if (W == false)
                {
                    w.Write("[Weather]\n");
                }

                if (checkBox3.Checked)
                {
                    bool b = customs.Contains("bPrecipitation=0\n");
                    if (b == false)
                    {
                        w.Write("bPrecipitation=0\n");
                    }
                }
                else
                {
                    customs.Replace("bPrecipitation=0\n", "");
                }

                if (checkBox4.Checked)
                {
                    bool b = customs.Contains("bFogEnabled=0\n");
                    if (b == false)
                    {
                        w.Write("bFogEnabled=0\n");
                    }
                }
                else
                {
                    customs.Replace("bFogEnabled=0\n", "");
                }

                if (checkBox19.Checked)
                {
                    bool b = customs.Contains("[General]\nsIntroSequence=\nuMainMenuDelayBeforeAllowSkip=0\nbSkipSplash=1");
                    if (b == false)
                    {
                        w.Write("[General]\nsIntroSequence=\nuMainMenuDelayBeforeAllowSkip=0\nbSkipSplash=1");
                    }
                }
                else
                {
                    customs.Replace("[General]\nsIntroSequence=\nuMainMenuDelayBeforeAllowSkip=0\nbSkipSplash=1", "");
                }
                
                File.SetAttributes(filePathCustom, FileAttributes.ReadOnly);
            }

            string prefs = File.ReadAllText(filePathPrefs);

            if (checkBox5.Checked)
            {
                prefs = prefs.Replace("iMaxAnisotropy=1", "iMaxAnisotropy=0");
            }
            else
            {
                prefs = prefs.Replace("iMaxAnisotropy=0", "iMaxAnisotropy=1");
            }

            if (checkBox6.Checked)
            {
                prefs = prefs.Replace("bVolumetricLightingEnable=1", "bVolumetricLightingEnable=0");
                prefs = prefs.Replace("iVolumetricLightingTextureQuality=1", "iVolumetricLightingTextureQuality=0");
            }
            else
            {
                prefs = prefs.Replace("bVolumetricLightingEnable=0", "bVolumetricLightingEnable=1");
                prefs = prefs.Replace("iVolumetricLightingTextureQuality=0", "iVolumetricLightingTextureQuality=1");
            }

            if (checkBox7.Checked)
            {
                prefs = prefs.Replace("bSAOEnable=1", "bSAOEnable=0");
            }
            else
            {
                prefs = prefs.Replace("bSAOEnable=0", "bSAOEnable=1");
            }

            if (checkBox8.Checked)
            {
                prefs = prefs.Replace("bDoDepthOfField=1", "bDoDepthOfField=0");
            }
            else
            {
                prefs = prefs.Replace("bDoDepthOfField=0", "bDoDepthOfField=1");
            }

            if (checkBox9.Checked)
            {
                prefs = prefs.Replace("bMBEnable=1", "bMBEnable=0");
            }
            else
            {
                prefs = prefs.Replace("bMBEnable=0", "bMBEnable=1");
            }

            if (checkBox10.Checked)
            {
                prefs = prefs.Replace("bScreenSpaceReflections=1", "bScreenSpaceReflections=0");
            }
            else
            {
                prefs = prefs.Replace("bScreenSpaceReflections=0", "bScreenSpaceReflections=1");
            }

            if (checkBox11.Checked)
            {
                prefs = prefs.Replace("bUseWaterHiRes=1", "bUseWaterHiRes=0");
            }
            else
            {
                prefs = prefs.Replace("bUseWaterHiRes=0", "bUseWaterHiRes=1");
            }

            if (checkBox12.Checked)
            {
                prefs = prefs.Replace("iPresentInterval=1", "iPresentInterval=0");
            }
            else
            {
                prefs = prefs.Replace("iPresentInterval=0", "iPresentInterval=1");
            }

            if (checkBox13.Checked)
            {
                prefs = prefs.Replace("bLensFlare=1", "bLensFlare=0");
            }
            else
            {
                prefs = prefs.Replace("bLensFlare=0", "bLensFlare=1");
            }

            if (checkBox14.Checked)
            {
                prefs = prefs.Replace("bScreenSpaceBokeh=1", "bScreenSpaceBokeh=0");
            }
            else
            {
                prefs = prefs.Replace("bScreenSpaceBokeh=0", "bScreenSpaceBokeh=1");
            }

            if (checkBox15.Checked)
            {
                prefs = prefs.Replace("bUseWaterReflections=1", "bUseWaterReflections=0");
            }
            else
            {
                prefs = prefs.Replace("bUseWaterReflections=0", "bUseWaterReflections=1");
            }

            if (checkBox16.Checked)
            {
                prefs = prefs.Replace("bUseWaterDepth=1", "bUseWaterDepth=0");
            }
            else
            {
                prefs = prefs.Replace("bUseWaterDepth=0", "bUseWaterDepth=1");
            }

            if (checkBox17.Checked)
            {
                prefs = prefs.Replace("bGamepadEnable=1", "bGamepadEnable=0");
            }
            else
            {
                prefs = prefs.Replace("bGamepadEnable=0", "bGamepadEnable=1");
            }

            if (checkBox18.Checked)
            {
                prefs = prefs.Replace("bQuickboyMode=0", "bQuickboyMode=1");
            }
            else
            {
                prefs = prefs.Replace("bQuickboyMode=1", "bQuickboyMode=0");
            }

            if (checkBox20.Checked)
            {
                prefs = prefs.Replace("sAntiAliasing=TAA", "sAntiAliasing=Off");
            }
            else
            {
                prefs = prefs.Replace("sAntiAliasing=Off", "sAntiAliasing=TAA");
            }

            bool bW = prefs.Contains("iSize W=" + textBox1.Text.ToString());
            if (bW == false)
            {
                prefs = prefs.Replace("iSize W=1280", "iSize W=" + textBox1.Text.ToString());
                prefs = prefs.Replace("iSize W=1920", "iSize W=" + textBox1.Text.ToString());
            }

            bool bH = prefs.Contains("iSize W=" + textBox2.Text.ToString());
            if (bH == false)
            {
                prefs = prefs.Replace("iSize H=720", "iSize H=" + textBox2.Text.ToString());
                prefs = prefs.Replace("iSize H=1080", "iSize H=" + textBox2.Text.ToString());
            }

            File.WriteAllText(filePathPrefs, prefs);
            File.SetAttributes(filePathPrefs, FileAttributes.ReadOnly);
        }  // Apply the changes
    }
}