using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace OricExplorer
{
    public class OricExplorer
    {
        public enum SortMode { SORT_BY_NAME, SORT_BY_TYPE };
        public enum MediaType { OricTape, TapeFile, OricDisk, DiskFile, ROMFile, UnknownMedia };

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        public static void SaveFormPosition(System.Windows.Forms.Form form)
        {
            string skey;

            // Create registry key for form
            skey = "Software\\OricExplorer\\" + form.Name;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(skey, true);

            // The key doesn't exist; create it / open it
            if(key == null)
                key = Registry.CurrentUser.CreateSubKey(skey);

            if(form.WindowState == FormWindowState.Minimized)
            {
                // Form is minimised, don't save size and position values
            }
            else
            {
                key.SetValue("X", form.Location.X);
                key.SetValue("Y", form.Location.Y);
                key.SetValue("Width", form.Width);
                key.SetValue("Height", form.Height);

                if (form.Visible)
                {
                    key.SetValue("State", "True");
                }
                else
                {
                    key.SetValue("State", "False");
                }
            }
        }

        public static void GetFormPosition(System.Windows.Forms.Form form) 
		{
			string skey;
			
			// Create registry key for form
            skey = "Software\\OricExplorer\\" + form.Name;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(skey, true);

			// The key doesn't exist, exit
			if(key == null)
			{
				form.Show();
				return;
			}

			// Get window state
			if(key.GetValue("State") == null) 
			{
				form.Show();
			}
			else 
			{
				if ((string)key.GetValue("State") == "True") 
					form.Show();
				else
					form.Hide();
			}
			
			if (key.GetValue("X") != null && key.GetValue("Y") != null) 
			{
				form.Location = new Point((int)key.GetValue("X"),(int)key.GetValue("Y"));
			}

			if (key.GetValue("Width") != null) 
			{
				form.Width = (int)key.GetValue("Width");
			}

			if (key.GetValue("Height") != null) 
			{	
				form.Height = (int)key.GetValue("Height");
			}
		}
    }
}