using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace 获取壁纸
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (textBox1.Text != null)
            {
                folderBrowserDialog.SelectedPath = textBox1.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void CopyToFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (textBox2.Text != null)
            {
                folderBrowserDialog.SelectedPath = textBox2.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void Copy_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(textBox2.Text))
            {
                Directory.CreateDirectory(textBox2.Text);
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(textBox1.Text);

            //开始复制线程

            CopyFileInThread copyFileInThread = new CopyFileInThread(directoryInfo, textBox2.Text, doneCounts, copyCounts, AllCounts);

            Thread CopyThread = new Thread(copyFileInThread.DOAll);
            CopyThread.IsBackground = true;
            CopyThread.Start();

        }
    }

    public class CopyFileInThread
    {
        private DirectoryInfo MaindirectoryInfo;
        private TextBox AllCoutns, DoneCouts, copyCounts;
        private String destinDirect;
        private Action<String> AllCoutnsDelegate, DoneCoutsDelegate, copyCountsDelegate;

        public CopyFileInThread(DirectoryInfo directoryInfo, string destinDirect, TextBox doneCouts, TextBox copyCounts, TextBox allCoutns)
        {
            MaindirectoryInfo = directoryInfo;
            this.destinDirect = destinDirect;
            DoneCouts = doneCouts;
            this.copyCounts = copyCounts;
            AllCoutns = allCoutns;
           AllCoutnsDelegate = delegate (string n) { AllCoutns.Text = n; };
           DoneCoutsDelegate = delegate (string n) { DoneCouts.Text = n; };
            copyCountsDelegate = delegate (string n) { copyCounts.Text = n; };
        }

        public void DOAll()
        {
            AllCoutns.Invoke(AllCoutnsDelegate, new object[] { "0" });
            DoneCouts.Invoke(DoneCoutsDelegate, new object[] { "0" });
            copyCounts.Invoke(copyCountsDelegate, new object[] { "0" });

          
            var fileInfos = getAllFiles(MaindirectoryInfo);
            AllCoutns.Invoke(AllCoutnsDelegate, new object[] { fileInfos.Count().ToString() });
            DoCopy(fileInfos);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            DialogResult result = MessageBox.Show("已完成", "提示", buttons, icon);
        }

        private IEnumerable<FileInfo> getAllFiles(DirectoryInfo root)
        {
            var fileInfos = root.GetFiles("*.*", SearchOption.AllDirectories)
                .Where(info => info.Name.ToLower().EndsWith("jpg") | info.Name.ToLower().EndsWith("jpeg") | info.Name.ToLower().EndsWith("jpe")
                    | info.Name.ToLower().EndsWith("bmp") | info.Name.ToLower().EndsWith("png") | info.Name.ToLower().EndsWith("img") | info.Name.ToLower().EndsWith("jff"));
            return fileInfos;
        }

        private void DoCopy(IEnumerable<FileInfo> fileNames)
        {
            int Width = 0, Height = 0, Done = 0, copy = 0;

            //用于发生文件名冲突时生成随机的后缀
            Random random = new Random();

            foreach (FileInfo fi in fileNames)
            {
                Done++;
                //DoneCouts.Text = Done.ToString();
                DoneCouts.Invoke(DoneCoutsDelegate, new object[] { Done.ToString() });

                //排除小于150K或者大于50M的文件
                if (fi.Length < 150 * 1024 && fi.Length > 50 * 1024 * 1024)
                {
                    continue;
                }
                //if (fi.Length > 1.5 * 1024 * 1024)
                //{
                //    continue;
                //}
                System.Diagnostics.Debug.WriteLine("now:" + fi.DirectoryName + fi.Name);
                Image imgPhoto = null;
                try
                {
                    imgPhoto = Image.FromFile(fi.DirectoryName + @"\" + fi.Name);
                    Width = imgPhoto.Width;
                    Height = imgPhoto.Height;
                }
                catch (Exception)
                {
                }
                finally
                {
                    if (imgPhoto != null)
                    {
                        imgPhoto.Dispose();
                    }
                }



                if (Width > (Height * 1.32) && Width >= 1300 && Height >= 900)
                {

                    if (fi.DirectoryName != null && destinDirect != null)
                    {
                        string sourceFile = Path.Combine(fi.DirectoryName, fi.Name);
                        string destFile = Path.Combine(destinDirect, fi.Name);
                        try
                        {
                            File.Copy(sourceFile, destFile);
                            System.Diagnostics.Debug.WriteLine("copy:" + fi.DirectoryName + fi.Name);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                File.Copy(sourceFile, Path.Combine(destinDirect, fi.Name.Substring(0, fi.Name.LastIndexOf("."))
                                    + "-" + random.Next(int.MaxValue).ToString()) + fi.Name.Substring(fi.Name.LastIndexOf(".")));
                                System.Diagnostics.Debug.WriteLine("copy:" + fi.DirectoryName + fi.Name);
                            }
                            catch (Exception)
                            {
                                System.Diagnostics.Debug.WriteLine("copyError:" + fi.DirectoryName + fi.Name);
                            }

                        }
                        copy++;
                      
                        copyCounts.Invoke(copyCountsDelegate, new object[] { copy.ToString() });
                    }

                }

                //if (Width < 1300 || Height < 900)
                //{
                //    if (fi.DirectoryName != null && destinDirect != null)
                //    {
                //        string sourceFile = Path.Combine(fi.DirectoryName, fi.Name);
                //        string destFile = Path.Combine(destinDirect, fi.Name);
                //        try
                //        {
                //            File.Move(sourceFile, destFile);
                //            System.Diagnostics.Debug.WriteLine("Move:" + fi.DirectoryName + fi.Name);
                //        }
                //        catch (Exception)
                //        {
                //            try
                //            {
                //                File.Move(sourceFile, Path.Combine(destinDirect, fi.Length + "-" + fi.Name));
                //                System.Diagnostics.Debug.WriteLine("Move:" + fi.DirectoryName + fi.Name);
                //            }
                //            catch (Exception)
                //            {
                //                System.Diagnostics.Debug.WriteLine("MoveError:" + fi.DirectoryName + fi.Name);
                //            }

                //        }
                //        copy++;
                //       copyCounts.Invoke(copyCountsDelegate, new object[] { copy.ToString() });
                //    }
                //}

            }

        }
    }
}
