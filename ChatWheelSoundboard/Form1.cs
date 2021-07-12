
using NHotkey;
using NHotkey.WindowsForms;
using NAudio;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;

namespace ChatWheelSoundboard
{
    public partial class Form1 : Form
    {
        //IWavePlayer waveOutDevice;
        int maxDevices;        
        const int currentPlaybackDevice = -1;
        readonly string soundsPath = Path.Combine(Application.StartupPath, "sounds");

        public Form1()
        {
            
            InitializeComponent();

            //mic setting ui
            maxDevices = WaveOut.DeviceCount;
            List<string> _devicesIn = new List<string>();
            for (int i = 0; i < maxDevices; i++)
            {
                var caps = WaveOut.GetCapabilities(i);
                _devicesIn.Add(caps.ProductName);
            }
            inputListBox.DataSource = _devicesIn;
            inputListBox.SetSelected(Properties.Settings.Default.mic, true);
            this.inputListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);

            //hotkey setting ui            
            LoadSoundDict();

            //hotkey listen
            HotkeyManager.Current.AddOrReplace("num0", Keys.NumPad0, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num1", Keys.NumPad1, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num2", Keys.NumPad2, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num3", Keys.NumPad3, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num4", Keys.NumPad4, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num5", Keys.NumPad5, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num6", Keys.NumPad6, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num7", Keys.NumPad7, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num8", Keys.NumPad8, OnSoundTrigger);
            HotkeyManager.Current.AddOrReplace("num9", Keys.NumPad9, OnSoundTrigger);                       
        }


        private void OnSoundTrigger(object sender, HotkeyEventArgs e)
        {
            string sound = (string)Properties.Settings.Default[e.Name];
            if (String.IsNullOrWhiteSpace(sound))
            {
                return;
            }

            string soundFile = Path.Combine("sounds", $"{sound}.wav");
            if (!File.Exists(soundFile))
            {
                return;
            }

            new Thread(() =>
            {
                WaveFileReader audioFileReader;
                WaveFileReader audioFileReader2;
                WaveOut waveOutDevice;
                waveOutDevice = new WaveOut();
                waveOutDevice.DeviceNumber = Properties.Settings.Default.mic;

                WaveOut playbackDevice;
                playbackDevice = new WaveOut();
                playbackDevice.DeviceNumber = currentPlaybackDevice;

                audioFileReader = new WaveFileReader(soundFile);
                audioFileReader2 = new WaveFileReader(soundFile);

                waveOutDevice.Init(audioFileReader);
                playbackDevice.Init(audioFileReader2);

                waveOutDevice.Play();
                playbackDevice.Play();
                while (waveOutDevice.PlaybackState == PlaybackState.Playing || playbackDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
                audioFileReader.Dispose();
                waveOutDevice.Dispose();
                playbackDevice.Dispose();

            }
            ).Start();

            e.Handled = true;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMic = ((ListBox) sender).SelectedIndex;
            Properties.Settings.Default.mic = selectedMic;
            Properties.Settings.Default.Save();
        }

        private void num0ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num0ddb.SelectedValue.ToString();
            Properties.Settings.Default.num0 = sound;
            Properties.Settings.Default.Save();
        }
        private void num1ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num1ddb.SelectedValue.ToString();
            Properties.Settings.Default.num1 = sound;
            Properties.Settings.Default.Save();
        }

        private void num2ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num2ddb.SelectedValue.ToString();
            Properties.Settings.Default.num2 = sound;
            Properties.Settings.Default.Save();
        }

        private void num3ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num3ddb.SelectedValue.ToString();
            Properties.Settings.Default.num3 = sound;
            Properties.Settings.Default.Save();
        }

        private void num4ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num4ddb.SelectedValue.ToString();
            Properties.Settings.Default.num4 = sound;
            Properties.Settings.Default.Save();
        }

        private void num5ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num5ddb.SelectedValue.ToString();
            Properties.Settings.Default.num5 = sound;
            Properties.Settings.Default.Save();
        }

        private void num6ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num6ddb.SelectedValue.ToString();
            Properties.Settings.Default.num6 = sound;
            Properties.Settings.Default.Save();
        }

        private void num7ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num7ddb.SelectedValue.ToString();
            Properties.Settings.Default.num7 = sound;
            Properties.Settings.Default.Save();
        }

        private void num8ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num8ddb.SelectedValue.ToString();
            Properties.Settings.Default.num8 = sound;
            Properties.Settings.Default.Save();
        }

        private void num9ddb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string sound = num9ddb.SelectedValue.ToString();
            Properties.Settings.Default.num9 = sound;
            Properties.Settings.Default.Save();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/derdanielb");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           
            System.Diagnostics.Process.Start("explorer", soundsPath);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadSoundDict();
        }

        private void LoadSoundDict()
        {
            string[] wavs = Directory.GetFiles(soundsPath, "*.wav", SearchOption.TopDirectoryOnly)
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .ToArray();

            ComboBox[] combos = new ComboBox[10] { num0ddb, num1ddb, num2ddb, num3ddb, num4ddb, num5ddb, num6ddb, num7ddb, num8ddb, num9ddb };
            for (int i = 0; i < 10; i++)
            {
                combos[i].DataSource = wavs.ToArray();

                string key = $"num{i}";
                string setting = (string)Properties.Settings.Default[key];
                if (String.IsNullOrWhiteSpace(setting))
                {
                    continue;
                }
                if (!wavs.Contains(setting))
                {
                    combos[i].SelectedIndex = -1;
                    continue;
                }

                combos[i].SelectedItem = setting;
            }         
        }
    }
}
