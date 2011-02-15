namespace FileJoiner
{
    partial class window
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(window));
            this.inputBox = new System.Windows.Forms.GroupBox();
            this.selectedFiles = new System.Windows.Forms.ListBox();
            this.outputBox = new System.Windows.Forms.GroupBox();
            this.filenameBox = new System.Windows.Forms.TextBox();
            this.processBox = new System.Windows.Forms.GroupBox();
            this.progressTotal = new System.Windows.Forms.ProgressBar();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelCurFile = new System.Windows.Forms.Label();
            this.progressCurFile = new System.Windows.Forms.ProgressBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.joinWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonSetOutput = new System.Windows.Forms.Button();
            this.buttonFileDelete = new System.Windows.Forms.Button();
            this.buttonFileDown = new System.Windows.Forms.Button();
            this.buttonFileUp = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.inputBox.SuspendLayout();
            this.outputBox.SuspendLayout();
            this.processBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Controls.Add(this.buttonFileDelete);
            this.inputBox.Controls.Add(this.buttonFileDown);
            this.inputBox.Controls.Add(this.buttonFileUp);
            this.inputBox.Controls.Add(this.selectedFiles);
            this.inputBox.Controls.Add(this.buttonAdd);
            resources.ApplyResources(this.inputBox, "inputBox");
            this.inputBox.Name = "inputBox";
            this.inputBox.TabStop = false;
            // 
            // selectedFiles
            // 
            this.selectedFiles.BackColor = System.Drawing.Color.White;
            this.selectedFiles.FormattingEnabled = true;
            resources.ApplyResources(this.selectedFiles, "selectedFiles");
            this.selectedFiles.Name = "selectedFiles";
            // 
            // outputBox
            // 
            this.outputBox.Controls.Add(this.buttonSetOutput);
            this.outputBox.Controls.Add(this.filenameBox);
            resources.ApplyResources(this.outputBox, "outputBox");
            this.outputBox.Name = "outputBox";
            this.outputBox.TabStop = false;
            // 
            // filenameBox
            // 
            resources.ApplyResources(this.filenameBox, "filenameBox");
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.TextChanged += new System.EventHandler(this.filenameBox_TextChanged);
            // 
            // processBox
            // 
            this.processBox.Controls.Add(this.progressTotal);
            this.processBox.Controls.Add(this.labelTotal);
            this.processBox.Controls.Add(this.labelCurFile);
            this.processBox.Controls.Add(this.progressCurFile);
            this.processBox.Controls.Add(this.buttonStart);
            resources.ApplyResources(this.processBox, "processBox");
            this.processBox.Name = "processBox";
            this.processBox.TabStop = false;
            // 
            // progressTotal
            // 
            resources.ApplyResources(this.progressTotal, "progressTotal");
            this.progressTotal.Name = "progressTotal";
            // 
            // labelTotal
            // 
            resources.ApplyResources(this.labelTotal, "labelTotal");
            this.labelTotal.Name = "labelTotal";
            // 
            // labelCurFile
            // 
            resources.ApplyResources(this.labelCurFile, "labelCurFile");
            this.labelCurFile.Name = "labelCurFile";
            // 
            // progressCurFile
            // 
            resources.ApplyResources(this.progressCurFile, "progressCurFile");
            this.progressCurFile.Name = "progressCurFile";
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // joinWorker
            // 
            this.joinWorker.WorkerReportsProgress = true;
            this.joinWorker.WorkerSupportsCancellation = true;
            this.joinWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.joinWorker_DoWork);
            this.joinWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.joinWorker_RunWorkerCompleted);
            this.joinWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.joinWorker_ProgressChanged);
            // 
            // buttonSetOutput
            // 
            this.buttonSetOutput.Image = global::FileJoiner.Properties.Resources.SAVE_16;
            resources.ApplyResources(this.buttonSetOutput, "buttonSetOutput");
            this.buttonSetOutput.Name = "buttonSetOutput";
            this.buttonSetOutput.UseVisualStyleBackColor = true;
            this.buttonSetOutput.Click += new System.EventHandler(this.buttonSetOutput_Click);
            // 
            // buttonFileDelete
            // 
            this.buttonFileDelete.Image = global::FileJoiner.Properties.Resources.TRASH_16;
            resources.ApplyResources(this.buttonFileDelete, "buttonFileDelete");
            this.buttonFileDelete.Name = "buttonFileDelete";
            this.buttonFileDelete.UseVisualStyleBackColor = true;
            this.buttonFileDelete.Click += new System.EventHandler(this.buttonFileDelete_Click);
            // 
            // buttonFileDown
            // 
            resources.ApplyResources(this.buttonFileDown, "buttonFileDown");
            this.buttonFileDown.Name = "buttonFileDown";
            this.buttonFileDown.UseVisualStyleBackColor = true;
            this.buttonFileDown.Click += new System.EventHandler(this.buttonFileDown_Click);
            // 
            // buttonFileUp
            // 
            this.buttonFileUp.Image = global::FileJoiner.Properties.Resources.arrow_up_16;
            resources.ApplyResources(this.buttonFileUp, "buttonFileUp");
            this.buttonFileUp.Name = "buttonFileUp";
            this.buttonFileUp.UseVisualStyleBackColor = true;
            this.buttonFileUp.Click += new System.EventHandler(this.buttonFileUp_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Image = global::FileJoiner.Properties.Resources.ADD_16;
            resources.ApplyResources(this.buttonAdd, "buttonAdd");
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // window
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.processBox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.inputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "window";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.inputBox.ResumeLayout(false);
            this.outputBox.ResumeLayout(false);
            this.outputBox.PerformLayout();
            this.processBox.ResumeLayout(false);
            this.processBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox inputBox;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ListBox selectedFiles;
        private System.Windows.Forms.Button buttonFileUp;
        private System.Windows.Forms.Button buttonFileDown;
        private System.Windows.Forms.Button buttonFileDelete;
        private System.Windows.Forms.GroupBox outputBox;
        private System.Windows.Forms.Button buttonSetOutput;
        private System.Windows.Forms.TextBox filenameBox;
        private System.Windows.Forms.GroupBox processBox;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelCurFile;
        private System.Windows.Forms.ProgressBar progressCurFile;
        private System.Windows.Forms.ProgressBar progressTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.ComponentModel.BackgroundWorker joinWorker;




    }
}

