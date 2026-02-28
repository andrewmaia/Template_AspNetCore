namespace ExportTemplate
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            button1 = new Button();
            txtNomeProjeto = new TextBox();
            txtPasta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnGerar = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(409, 60);
            button1.Name = "button1";
            button1.Size = new Size(33, 23);
            button1.TabIndex = 0;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtNomeProjeto
            // 
            txtNomeProjeto.Location = new Point(216, 27);
            txtNomeProjeto.Name = "txtNomeProjeto";
            txtNomeProjeto.Size = new Size(226, 23);
            txtNomeProjeto.TabIndex = 1;
            // 
            // txtPasta
            // 
            txtPasta.Location = new Point(216, 60);
            txtPasta.Name = "txtPasta";
            txtPasta.ReadOnly = true;
            txtPasta.Size = new Size(187, 23);
            txtPasta.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 35);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome do projeto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 68);
            label2.Name = "label2";
            label2.Size = new Size(168, 15);
            label2.TabIndex = 4;
            label2.Text = "Selecione onde gerar o projeto";
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(197, 112);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(75, 23);
            btnGerar.TabIndex = 5;
            btnGerar.Text = "Gerar";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 149);
            Controls.Add(btnGerar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPasta);
            Controls.Add(txtNomeProjeto);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FolderBrowserDialog folderBrowserDialog1;
        private Button button1;
        private TextBox txtNomeProjeto;
        private TextBox txtPasta;
        private Label label1;
        private Label label2;
        private Button btnGerar;
    }
}
