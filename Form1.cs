using Microsoft.Win32;

namespace SynapticsUnfuckerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Synaptics\\SynTP\\Defaults", true);
            foreach (string valueName in registryKey.GetValueNames())
            {
                if (valueName.ToLower().StartsWith("palmkms"))
                {
                    richTextBox1.Text = richTextBox1.Text + "Disabling: SOFTWARE\\Synaptics\\SynTP\\Defaults\\" + valueName + "\n";
                    Console.WriteLine(valueName + " " + registryKey.GetValue(valueName)?.ToString());
                    registryKey.SetValue(valueName, (object)0);
                    Console.WriteLine(valueName + " " + registryKey.GetValue(valueName)?.ToString());
                }
            }
            RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PrecisionTouchPad", true);
            registryKey2.SetValue("AAPThreshold", (object)0);
            richTextBox1.Text = richTextBox1.Text + "Disabling: SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\PrecisionTouchPad\\" + "AAPThreshold" + "\n Done!";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}