
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;

using Bruteforce;

namespace FFBruteforcer
{
    public partial class MainForm : Form
    {

        #region Fields

        private static string[] PassWordsList = null;
        private static readonly string PassWordsFile = ConfigurationManager.AppSettings.Get("DefaultPasswordsFile");

        #endregion

        #region Constructor

        public MainForm(string database = "")
        {
            InitializeComponent();
            // Load passwords database
            if (PassWordsList == null)
            {
                if (File.Exists(PassWordsFile))
                {
                    string words = File.ReadAllText(PassWordsFile);
                    PassWordsList = words.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                    Debug.WriteLine($"Loaded {PassWordsList.Length} passwords from " + PassWordsFile);
                }
            }
            // From args
            if (File.Exists(database))
            {
                textBoxKey4DbFile.Text = database;
            }
        }

        #endregion

        #region Browse database

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            // Select key4.db file
            using (OpenFileDialog GetFileDialog = new OpenFileDialog())
            {
                GetFileDialog.Filter = "Database Files|*.db";
                GetFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                GetFileDialog.Title = "Select key4.db file";

                if (GetFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxKey4DbFile.Text = GetFileDialog.FileName;
                }
            }
        }

        #endregion

        #region Open github
        
        private void labelAuthor_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/L1ghtM4n");
        }

        #endregion

        #region Start bruteforce

        private void buttonStartBruteforce_Click(object sender, EventArgs e)
        {
            // Check input
            if (string.IsNullOrEmpty(textBoxKey4DbFile.Text))
            {
                textBoxKey4DbFile.Focus();
                MessageBox.Show(this, "Please select a database file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Check if db exists
            if (!File.Exists(textBoxKey4DbFile.Text))
            {
                textBoxKey4DbFile.Clear();
                textBoxKey4DbFile.Focus();
                MessageBox.Show(this, "Database not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Load item2Byte and globalSalt from key4.db file
            byte[] item2Byte = null;
            byte[] globalSalt = null;
            using (SQLite key4db = new SQLite(textBoxKey4DbFile.Text))
            {
                if (key4db.ReadTable("metaData"))
                {
                    for (int i = 0; i < key4db.GetRowCount(); i++)
                    {
                        if (key4db.GetValue(i, "id").Equals("password"))
                        {
                            globalSalt = Encoding.Default.GetBytes(key4db.GetValue(i, 1));
                            item2Byte = Encoding.Default.GetBytes(key4db.GetValue(i, 2));
                            break;
                        }
                    }
                    if (item2Byte == null || globalSalt == null)
                    {
                        MessageBox.Show(this, "Failed to find globalSalt or item2Byte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(this, "Failed to read table metaData", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            mozillaPrivateKey checker;
            // Initialyze
            try
            {
                checker = new mozillaPrivateKey(globalSalt, item2Byte);
            } catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Check if master password is set
            if (checker.CheckPassword(string.Empty))
            {
                MessageBox.Show(this, "Master password not set!", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            // Check if passwords database loaded
            if (PassWordsList == null)
            {
                MessageBox.Show(this, "Passwords database not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Bruteforce master password
            for (int i = 0; i < PassWordsList.Length; i++)
            {
                Debug.WriteLine($"[{i + 1}/{PassWordsList.Length}] - {PassWordsList[i]}");
                // Success
                if (checker.CheckPassword(PassWordsList[i]))
                {
                    File.AppendAllText("Results.txt", $"{DateTime.Now} | Password: {PassWordsList[i]}\n");
                    MessageBox.Show(this, $"Master password found '{PassWordsList[i]}'", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            // Failed
            MessageBox.Show(this, $"Master password not found :(", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

    }
}
