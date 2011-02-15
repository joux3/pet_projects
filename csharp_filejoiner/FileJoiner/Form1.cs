using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileJoiner
{
    struct CurStatus
    {
        public int curFile;
        public int percentageCurFile;
        public int percentageTotal;
    }
    public partial class window : Form
    {
        // the backend of selected files, contains the full paths
        private List<String> inputFiles = new List<String>();

        // directory of the first selected file
        private String outputPath = "";

        private String outputFile = "";

        public window()
        {
            InitializeComponent();
            selectedFiles.Items.Clear();
        }

        private void updateView()
        {
            inputBox.Enabled = !joinWorker.IsBusy;
            outputBox.Enabled = inputBox.Enabled && inputFiles.Count > 1;
            processBox.Enabled = joinWorker.IsBusy || (outputBox.Enabled && filenameBox.Text.Length > 0);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // create an open file dialog
            OpenFileDialog dlgOpen = new OpenFileDialog();

            // set properties for the dialog
            dlgOpen.Title = "Select files to be added";
            dlgOpen.ShowReadOnly = true;
            dlgOpen.Multiselect = true;

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                foreach (String fileName in dlgOpen.FileNames)
                {
                    if (outputPath.Equals(""))
                        outputPath = Path.GetDirectoryName(fileName);
                    inputFiles.Add(fileName);
                    selectedFiles.Items.Add(Path.GetFileName(fileName));
                }
            }
            updateView();
        }

        private void buttonFileUp_Click(object sender, EventArgs e)
        {
            // don't move if already at the top
            if (selectedFiles.SelectedIndex < 1)
                return;

            int indexToMove = selectedFiles.SelectedIndex;
            String temp = (String)selectedFiles.Items[indexToMove];
            selectedFiles.Items.RemoveAt(indexToMove);
            selectedFiles.Items.Insert(indexToMove - 1, temp);
            selectedFiles.SetSelected(indexToMove - 1, true);

            temp = inputFiles[indexToMove];
            inputFiles.RemoveAt(indexToMove);
            inputFiles.Insert(indexToMove - 1, temp);
        }

        private void buttonFileDelete_Click(object sender, EventArgs e)
        {
            if (selectedFiles.SelectedIndex == -1)
                return;
            int indexToDelete = selectedFiles.SelectedIndex;
            selectedFiles.Items.RemoveAt(indexToDelete);
            inputFiles.RemoveAt(indexToDelete);
            updateView();
        }

        private void buttonFileDown_Click(object sender, EventArgs e)
        {
            // don't move down if it's already at the bottom
            if (selectedFiles.SelectedIndex > inputFiles.Count-2)
                return;

            int indexToMove = selectedFiles.SelectedIndex;
            String temp = (String)selectedFiles.Items[indexToMove];
            selectedFiles.Items.RemoveAt(indexToMove);
            selectedFiles.Items.Insert(indexToMove + 1, temp);
            selectedFiles.SetSelected(indexToMove + 1, true);

            temp = inputFiles[indexToMove];
            inputFiles.RemoveAt(indexToMove);
            inputFiles.Insert(indexToMove + 1, temp);
        }

        private void buttonSetOutput_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog();
            dlgSave.InitialDirectory = outputPath;
            dlgSave.Title = "Select output file";

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                filenameBox.Text = dlgSave.FileName;
            }
        }

        private void filenameBox_TextChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private const int BUFFER_SIZE = 16384;
        private void joinWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CurStatus curStatus;
            curStatus.curFile = 1;
            curStatus.percentageCurFile = 0;
            curStatus.percentageTotal = 0;
            joinWorker.ReportProgress(0, curStatus);
            long[] fileSizes = new long[inputFiles.Count];
            long outputSize = 0;
            long totalWrittenBytes = 0;
            // get the file sizes for each file
            for (int i = 0; i < inputFiles.Count; i++)
            {
                FileInfo curFile = new FileInfo(inputFiles[i]);
                fileSizes[i] = curFile.Length;
                outputSize += curFile.Length;
            }

            // open the output file
            FileStream fOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fOut);

            for (int i = 0; i < inputFiles.Count; i++)
            {
                if (joinWorker.CancellationPending)
                {
                    writer.Close();
                    return;
                }
                long curFileWrittenBytes = 0;
                curStatus.curFile = i + 1;
                curStatus.percentageCurFile = 0;
                curStatus.percentageTotal = (int)((float)totalWrittenBytes / (float)outputSize * 100);
                joinWorker.ReportProgress(0, curStatus);

                FileStream fIn = new FileStream(inputFiles[i], FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(fIn);

                byte[] buffer = new byte[BUFFER_SIZE];
                int readBytes = 0;
                while ((readBytes = reader.Read(buffer, 0, BUFFER_SIZE)) != 0)
                {              
                    writer.Write(buffer, 0, readBytes);
                    curFileWrittenBytes += readBytes;
                    totalWrittenBytes += readBytes;
                    curStatus.percentageCurFile = (int)((float)curFileWrittenBytes / (float)fileSizes[i] * 100);
                    curStatus.percentageTotal = (int)((float)totalWrittenBytes / (float)outputSize * 100);
                    joinWorker.ReportProgress(0, curStatus);
                    if (joinWorker.CancellationPending)
                    {
                        reader.Close();
                        writer.Close();
                        return;
                    }
                }

                reader.Close();
            }

            writer.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!joinWorker.IsBusy)
            {
                buttonStart.Text = "Stop";
                outputFile = filenameBox.Text;
                joinWorker.RunWorkerAsync();
                updateView();
            }
            else
            {
                joinWorker.CancelAsync();
                buttonStart.Text = "Start";         
            }
        }

        private void joinWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStart.Text = "Start";
            progressCurFile.Value = 0;
            progressTotal.Value = 0;
            labelCurFile.Text = "Current file";
            updateView();
        }

        private void joinWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            CurStatus update = (CurStatus)e.UserState;
            progressCurFile.Value = update.percentageCurFile;
            progressTotal.Value = update.percentageTotal;
            labelCurFile.Text = "Current file ("+update.curFile+"/"+inputFiles.Count+")";
        }
    }
}