using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SynapticsUnfuckerator2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,RegistryView.Registry64);
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey registryKey = hklm.OpenSubKey(@"SOFTWARE\Synaptics\SynTP\Defaults", true);
            foreach (string valueName in registryKey.GetValueNames())
            {
                if (valueName.ToLower().StartsWith("palmkms"))
                {
                    richTextBox1.Text = richTextBox1.Text + "\nDisabling: SOFTWARE\\Synaptics\\SynTP\\Defaults\\" + valueName;
                    registryKey.SetValue(valueName, (object)0);
                }
            }
            RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\PrecisionTouchPad", true);
            registryKey2.SetValue("AAPThreshold", (object)0);
            richTextBox1.Text = richTextBox1.Text + "\nDisabling: SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PrecisionTouchPad\\" + "AAPThreshold" + "\n Done!";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
