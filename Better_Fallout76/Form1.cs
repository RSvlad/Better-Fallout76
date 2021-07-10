using System;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace Better_Fallout76
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        /* Intro */
        readonly string ini0 = ("# This INI File was made with Better Fallout76 by RSVlad\n# The INI File has been coppied to your clipboard!\n\n");
        /* Blood */ string ini1;
        /* Resolution Width */ string ini2;
        /* Resolution Height */ string ini3;
        /* Disable Radial Blur */ string ini4;
        /* Disable Rain */ string ini5;
        /* Disable Fog */ string ini6;
        /* Disable Anisotropy */ string ini7;
        /* Disable Volumetric Lighting */ string ini8;
        /* Disable Ambient Occlusion */ string ini9;
        /* Disable Depth of Field */ string ini10;
        /* Disable Motion Blur */ string ini11;
        /* Disable Reflections */ string ini12;
        /* Disable HiRez Water */ string ini13;
        /* Disable VSync */ string ini14;
        /* Disable Lens Flare */ string ini15;
        /* Disable Bokeh */ string ini16;
        /* Disable Water Reflection */ string ini17;
        /* Disable Water Depth */ string ini18;
        /* Disable Gamepad */ string ini19;
        /* Use better PipBoy menu */ string ini20;

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                ini1 = "[ScreenSplatter]\nbBloodSplatterEnabled=0\n";
          
            ini2 = ("iSize W=" + textBox1.Text.ToString() + "\n");
            ini3 = ("iSize H=" + textBox2.Text.ToString() + "\n");
          
            if (checkBox2.Checked)
                ini4 = "[ImageSpace]\nbDoRadialBlur=0\n";
          
            if (checkBox3.Checked)
                ini5 = "bPrecipitation=0\n";
          
            if (checkBox4.Checked)
                ini6 = "bFogEnabled=0\n";

            if (checkBox5.Checked)
                ini7 = "iMaxAnisotropy=0\n";

            if (checkBox6.Checked)
                ini8 = "bVolumetricLightingEnable=0\niVolumetricLightingTextureQuality=0\n";

            if (checkBox7.Checked)
                ini9 = "bSAOEnable=0\n";

            if (checkBox8.Checked)
                ini10 = "bDoDepthOfField=0\n";

            if (checkBox9.Checked)
                ini11 = "bMBEnable=0\n";

            if (checkBox10.Checked)
                ini12 = "[LightingShader]\nbScreenSpaceReflections=0\n";

            if (checkBox11.Checked)
                ini13 = "bUseWaterHiRes=0\n";

            if (checkBox12.Checked)
                ini14 = "iPresentInterval=0\n";

            if (checkBox13.Checked)
                ini15 = "bLensFlare=0\n";

            if (checkBox14.Checked)
                ini16 = "bScreenSpaceBokeh=0\n";

            if (checkBox15.Checked)
                ini17 = "bUseWaterReflections=0\n";

            if (checkBox16.Checked)
                ini18 = "bUseWaterDepth=0\n";

            if (checkBox17.Checked)
                ini19 = "[General]\nbGamepadEnable=0\n";

            if (checkBox18.Checked)
                ini20 = "[Pipboy]\nbQuickboyMode=1\n";

            string ini = ini0 + "# Paste this into your Fallout76Custom.ini file\n\n" + ini1 + "[Display]\n" + ini2 + ini3 + ini4 + ini14 + "[Weather]\n" + ini5 + ini6 + "\n# and change these in your Fallout76Prefs.ini file\n\n" + "[Display]\n" + ini7 + ini8 + ini9 + "[ImageSpace]\n" + ini10 + ini12 + ini13 + ini15 + ini16 + "[Water]\n" + ini11 + ini17 + ini18 + ini19 + ini20;
            Clipboard.SetText(ini);
            MessageBox.Show(ini);
        }
    }
}