﻿namespace SmamForms
{
    partial class ArticleForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticleForm));
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelTitelArticle = new System.Windows.Forms.Label();
            this.txtArticleText = new System.Windows.Forms.TextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Transparent;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(37, 37);
            this.buttonBack.TabIndex = 0;
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelTitelArticle
            // 
            this.labelTitelArticle.AutoSize = true;
            this.labelTitelArticle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitelArticle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelTitelArticle.ForeColor = System.Drawing.Color.White;
            this.labelTitelArticle.Location = new System.Drawing.Point(55, 18);
            this.labelTitelArticle.Name = "labelTitelArticle";
            this.labelTitelArticle.Size = new System.Drawing.Size(159, 25);
            this.labelTitelArticle.TabIndex = 1;
            this.labelTitelArticle.Text = "Titel van artikel";
            // 
            // txtArticleText
            // 
            this.txtArticleText.BackColor = System.Drawing.Color.White;
            this.txtArticleText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtArticleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtArticleText.Location = new System.Drawing.Point(12, 52);
            this.txtArticleText.Multiline = true;
            this.txtArticleText.Name = "txtArticleText";
            this.txtArticleText.ReadOnly = true;
            this.txtArticleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArticleText.Size = new System.Drawing.Size(234, 547);
            this.txtArticleText.TabIndex = 9;
            this.txtArticleText.TabStop = false;
            this.txtArticleText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtArticleText_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(75, 75);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 50);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // ArticleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(339, 611);
            this.Controls.Add(this.txtArticleText);
            this.Controls.Add(this.labelTitelArticle);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(355, 650);
            this.MinimumSize = new System.Drawing.Size(355, 650);
            this.Name = "ArticleForm";
            this.Text = "SMAM";
            this.Load += new System.EventHandler(this.ArticleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelTitelArticle;
        private System.Windows.Forms.TextBox txtArticleText;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}