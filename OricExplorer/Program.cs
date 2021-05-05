namespace OricExplorer
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // iteration over each file to update of the app folder, these files having been created by the app update procedure due to the presence of locked files
            string strExeFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            bool boolError = false;
            foreach (string strFile in Directory.GetFiles(strExeFolder, $"*{ConstantsAndEnums.UPDATE_EXTENSION}"))
            {
                string strNewFile = Path.Combine(strExeFolder, strFile);
                string strOldFile = Path.GetFileNameWithoutExtension(strNewFile);

                try
                {
                    // delete previous file
                    File.Delete(strOldFile);

                    // rename the file by removing the update extension
                    File.Move(strNewFile, strOldFile);
                }
                catch (Exception)
                {
                    boolError = true;
                }
            }
            if (boolError)
            {
                MessageBox.Show($"An error was encountered while finalizing the update: one or more '{ConstantsAndEnums.UPDATE_EXTENSION}' files could not be renamed.\r\n\r\nThe app may not work properly.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            Configuration.Init();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainForm());
        }
    }
}