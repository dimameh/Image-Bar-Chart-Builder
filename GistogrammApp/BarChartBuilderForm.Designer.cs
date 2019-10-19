namespace BarChartBuilder
{
    partial class BarChartBuilderForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BarChartPictureBox = new System.Windows.Forms.PictureBox();
            this.BrowseImageButton = new System.Windows.Forms.Button();
            this.ImageNameLabel = new System.Windows.Forms.Label();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.BarChartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BarChartPictureBox
            // 
            this.BarChartPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BarChartPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BarChartPictureBox.Location = new System.Drawing.Point(12, 12);
            this.BarChartPictureBox.Name = "BarChartPictureBox";
            this.BarChartPictureBox.Size = new System.Drawing.Size(346, 317);
            this.BarChartPictureBox.TabIndex = 0;
            this.BarChartPictureBox.TabStop = false;
            // 
            // BrowseImageButton
            // 
            this.BrowseImageButton.Location = new System.Drawing.Point(12, 335);
            this.BrowseImageButton.Name = "BrowseImageButton";
            this.BrowseImageButton.Size = new System.Drawing.Size(75, 30);
            this.BrowseImageButton.TabIndex = 1;
            this.BrowseImageButton.Text = "Обзор...";
            this.BrowseImageButton.UseVisualStyleBackColor = true;
            this.BrowseImageButton.Click += new System.EventHandler(this.BrowseImageButton_Click);
            // 
            // ImageNameLabel
            // 
            this.ImageNameLabel.AutoSize = true;
            this.ImageNameLabel.Location = new System.Drawing.Point(9, 368);
            this.ImageNameLabel.Name = "ImageNameLabel";
            this.ImageNameLabel.Size = new System.Drawing.Size(321, 17);
            this.ImageNameLabel.TabIndex = 2;
            this.ImageNameLabel.Text = "Выберите или перетащите .png или .jpeg файл";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "Выберите файл";
            this.OpenFileDialog.Filter = "Image Files (JPEG,JPG,PNG)|*.JPG;*.JPEG;*.PNG";
            // 
            // BarChartBuilderForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 393);
            this.Controls.Add(this.ImageNameLabel);
            this.Controls.Add(this.BrowseImageButton);
            this.Controls.Add(this.BarChartPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BarChartBuilderForm";
            this.Text = "BarChartBuilder";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.BarChartBuilderForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.BarChartBuilderForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.BarChartPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BarChartPictureBox;
        private System.Windows.Forms.Button BrowseImageButton;
        private System.Windows.Forms.Label ImageNameLabel;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}

