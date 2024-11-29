using System.Windows.Forms;

namespace MinimapOverlay
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox coordinatesTextBox;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.LinkLabel label1;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.TrackBar transparencyTrackBar;
        private System.Windows.Forms.Label transparencyLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.coordinatesTextBox = new System.Windows.Forms.RichTextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.calculateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.LinkLabel();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.transparencyTrackBar = new System.Windows.Forms.TrackBar();
            this.transparencyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyTrackBar)).BeginInit();
            this.SuspendLayout();

            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 39);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 800);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;

            this.coordinatesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coordinatesTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.coordinatesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coordinatesTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.coordinatesTextBox.ForeColor = System.Drawing.Color.White;
            this.coordinatesTextBox.Location = new System.Drawing.Point(840, 68);
            this.coordinatesTextBox.Name = "coordinatesTextBox";
            this.coordinatesTextBox.Size = new System.Drawing.Size(300, 350);
            this.coordinatesTextBox.TabIndex = 1;
            this.coordinatesTextBox.Text = "";
            this.coordinatesTextBox.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.coordinatesTextBox.WordWrap = false;
            this.coordinatesTextBox.TextChanged += new System.EventHandler(this.CoordinatesTextBox_TextChanged);

            this.instructionsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.instructionsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.instructionsLabel.Location = new System.Drawing.Point(840, 39);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(300, 25);
            this.instructionsLabel.TabIndex = 2;
            this.instructionsLabel.Text = "Coordenadas: ";

            this.colorPickerButton.Anchor = AnchorStyles.Right;
            this.colorPickerButton.BackColor = System.Drawing.Color.Red;
            this.colorPickerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorPickerButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.colorPickerButton.ForeColor = System.Drawing.Color.White;
            this.colorPickerButton.Location = new System.Drawing.Point(840, 430);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(140, 30);
            this.colorPickerButton.TabIndex = 6;
            this.colorPickerButton.Text = "Escolher Cor";
            this.colorPickerButton.UseVisualStyleBackColor = false;
            this.colorPickerButton.Click += new System.EventHandler(this.ColorPickerButton_Click);

            this.transparencyTrackBar.Anchor = AnchorStyles.Right;
            this.transparencyTrackBar.Location = new System.Drawing.Point(840, 470); 
            this.transparencyTrackBar.Maximum = 255;
            this.transparencyTrackBar.Minimum = 0;
            this.transparencyTrackBar.Value = 180;
            this.transparencyTrackBar.TickFrequency = 25;
            this.transparencyTrackBar.Name = "transparencyTrackBar";
            this.transparencyTrackBar.Size = new System.Drawing.Size(300, 45);
            this.transparencyTrackBar.TabIndex = 7;
            this.transparencyTrackBar.Scroll += new System.EventHandler(this.TransparencyTrackBar_Scroll);

            this.transparencyLabel.Anchor = AnchorStyles.Right;
            this.transparencyLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.transparencyLabel.ForeColor = System.Drawing.Color.White;
            this.transparencyLabel.Location = new System.Drawing.Point(840, 520); 
            this.transparencyLabel.Name = "transparencyLabel";
            this.transparencyLabel.Size = new System.Drawing.Size(300, 20);
            this.transparencyLabel.TabIndex = 8;
            this.transparencyLabel.Text = "Transparência: 180";

            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.exportButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.exportButton.ForeColor = System.Drawing.Color.White;
            this.exportButton.Location = new System.Drawing.Point(840, 560); 
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(300, 45);
            this.exportButton.TabIndex = 3;
            this.exportButton.Text = "Exportar Imagem";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);

            this.calculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.calculateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.calculateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.calculateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.calculateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculateButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.calculateButton.ForeColor = System.Drawing.Color.White;
            this.calculateButton.Location = new System.Drawing.Point(840, 620); 
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(300, 45);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Calcular Zona Central e Escala";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Created by: arron_0n";
            this.label1.LinkColor = System.Drawing.Color.FromArgb(23, 162, 184);
            this.label1.ActiveLinkColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.label1.VisitedLinkColor = System.Drawing.Color.Gray;
            this.label1.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.label1.Links.Add(12, 8, "https://github.com/tarcisiogustavo");
            this.label1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Label1_LinkClicked);

            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1170, 880);
            this.Controls.Add(this.transparencyLabel);
            this.Controls.Add(this.transparencyTrackBar);
            this.Controls.Add(this.colorPickerButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.coordinatesTextBox);
            this.Controls.Add(this.pictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "MinimapOverlay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
