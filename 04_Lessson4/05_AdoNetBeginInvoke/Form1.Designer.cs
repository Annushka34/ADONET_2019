namespace _05_AdoNetBeginInvoke
{
    partial class Form1
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
            this.dgvSynchron = new System.Windows.Forms.DataGridView();
            this.dgvAsynchron = new System.Windows.Forms.DataGridView();
            this.pbSynchron = new System.Windows.Forms.ProgressBar();
            this.pbAsynchrn = new System.Windows.Forms.ProgressBar();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLoadAsync = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOpenForm2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynchron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsynchron)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSynchron
            // 
            this.dgvSynchron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSynchron.Location = new System.Drawing.Point(13, 13);
            this.dgvSynchron.Name = "dgvSynchron";
            this.dgvSynchron.Size = new System.Drawing.Size(675, 150);
            this.dgvSynchron.TabIndex = 0;
            // 
            // dgvAsynchron
            // 
            this.dgvAsynchron.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsynchron.Location = new System.Drawing.Point(13, 238);
            this.dgvAsynchron.Name = "dgvAsynchron";
            this.dgvAsynchron.Size = new System.Drawing.Size(675, 150);
            this.dgvAsynchron.TabIndex = 1;
            // 
            // pbSynchron
            // 
            this.pbSynchron.Location = new System.Drawing.Point(13, 183);
            this.pbSynchron.Maximum = 200;
            this.pbSynchron.Name = "pbSynchron";
            this.pbSynchron.Size = new System.Drawing.Size(675, 23);
            this.pbSynchron.TabIndex = 2;
            // 
            // pbAsynchrn
            // 
            this.pbAsynchrn.Location = new System.Drawing.Point(13, 419);
            this.pbAsynchrn.Maximum = 670;
            this.pbAsynchrn.Name = "pbAsynchrn";
            this.pbAsynchrn.Size = new System.Drawing.Size(675, 23);
            this.pbAsynchrn.TabIndex = 3;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(13, 470);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(127, 43);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "LOAD SYNCHRON";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLoadAsync
            // 
            this.btnLoadAsync.Location = new System.Drawing.Point(146, 470);
            this.btnLoadAsync.Name = "btnLoadAsync";
            this.btnLoadAsync.Size = new System.Drawing.Size(133, 43);
            this.btnLoadAsync.TabIndex = 5;
            this.btnLoadAsync.Text = "LOAD ASYNCHRON";
            this.btnLoadAsync.UseVisualStyleBackColor = true;
            this.btnLoadAsync.Click += new System.EventHandler(this.btnLoadAsync_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(285, 472);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 41);
            this.textBox1.TabIndex = 6;
            // 
            // btnOpenForm2
            // 
            this.btnOpenForm2.Location = new System.Drawing.Point(425, 470);
            this.btnOpenForm2.Name = "btnOpenForm2";
            this.btnOpenForm2.Size = new System.Drawing.Size(263, 43);
            this.btnOpenForm2.TabIndex = 7;
            this.btnOpenForm2.Text = "OPEN FORM 2";
            this.btnOpenForm2.UseVisualStyleBackColor = true;
            this.btnOpenForm2.Click += new System.EventHandler(this.btnOpenForm2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 525);
            this.Controls.Add(this.btnOpenForm2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLoadAsync);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.pbAsynchrn);
            this.Controls.Add(this.pbSynchron);
            this.Controls.Add(this.dgvAsynchron);
            this.Controls.Add(this.dgvSynchron);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynchron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsynchron)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSynchron;
        private System.Windows.Forms.DataGridView dgvAsynchron;
        private System.Windows.Forms.ProgressBar pbSynchron;
        private System.Windows.Forms.ProgressBar pbAsynchrn;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLoadAsync;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnOpenForm2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

