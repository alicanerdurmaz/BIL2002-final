namespace _2018280067.Forms
{
	partial class AccountForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.TextWelcome = new System.Windows.Forms.Label();
			this.TextIbanTr = new System.Windows.Forms.Label();
			this.TextIbanEuro = new System.Windows.Forms.Label();
			this.TextIbanUsd = new System.Windows.Forms.Label();
			this.ComboBoxPersons = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.ComboBoxIbanUser = new System.Windows.Forms.ComboBox();
			this.ComboBoxIbanOther = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.TextAmountOfMoney = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.TextAmountTr = new System.Windows.Forms.Label();
			this.TextAmountEur = new System.Windows.Forms.Label();
			this.TextAmountUsd = new System.Windows.Forms.Label();
			this.BtnEFT = new System.Windows.Forms.Button();
			this.BtnExit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 79);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(371, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hesabınızdaki güncel para miktarları :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TextWelcome
			// 
			this.TextWelcome.AutoSize = true;
			this.TextWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextWelcome.ForeColor = System.Drawing.SystemColors.Highlight;
			this.TextWelcome.Location = new System.Drawing.Point(83, 20);
			this.TextWelcome.Name = "TextWelcome";
			this.TextWelcome.Size = new System.Drawing.Size(323, 29);
			this.TextWelcome.TabIndex = 1;
			this.TextWelcome.Text = "Hoşgeldiniz, Naz Gül Uçan";
			// 
			// TextIbanTr
			// 
			this.TextIbanTr.AutoSize = true;
			this.TextIbanTr.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextIbanTr.Location = new System.Drawing.Point(12, 130);
			this.TextIbanTr.Name = "TextIbanTr";
			this.TextIbanTr.Size = new System.Drawing.Size(0, 25);
			this.TextIbanTr.TabIndex = 2;
			// 
			// TextIbanEuro
			// 
			this.TextIbanEuro.AutoSize = true;
			this.TextIbanEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextIbanEuro.Location = new System.Drawing.Point(12, 214);
			this.TextIbanEuro.Name = "TextIbanEuro";
			this.TextIbanEuro.Size = new System.Drawing.Size(0, 25);
			this.TextIbanEuro.TabIndex = 3;
			// 
			// TextIbanUsd
			// 
			this.TextIbanUsd.AutoSize = true;
			this.TextIbanUsd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextIbanUsd.Location = new System.Drawing.Point(12, 292);
			this.TextIbanUsd.Name = "TextIbanUsd";
			this.TextIbanUsd.Size = new System.Drawing.Size(0, 25);
			this.TextIbanUsd.TabIndex = 4;
			// 
			// ComboBoxPersons
			// 
			this.ComboBoxPersons.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ComboBoxPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxPersons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxPersons.FormattingEnabled = true;
			this.ComboBoxPersons.Location = new System.Drawing.Point(481, 130);
			this.ComboBoxPersons.Name = "ComboBoxPersons";
			this.ComboBoxPersons.Size = new System.Drawing.Size(373, 28);
			this.ComboBoxPersons.TabIndex = 8;
			this.ComboBoxPersons.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPersons_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(477, 107);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(242, 20);
			this.label5.TabIndex = 9;
			this.label5.Text = "Para göndereceğiniz kişiyi seçiniz";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(475, 267);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(377, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Parayı hangi hesabınızdan göndermek istiyorsunuz ?";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(475, 287);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 20);
			this.label7.TabIndex = 11;
			this.label7.Text = "IBAN Seçiniz";
			// 
			// ComboBoxIbanUser
			// 
			this.ComboBoxIbanUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxIbanUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxIbanUser.FormattingEnabled = true;
			this.ComboBoxIbanUser.Location = new System.Drawing.Point(479, 310);
			this.ComboBoxIbanUser.Name = "ComboBoxIbanUser";
			this.ComboBoxIbanUser.Size = new System.Drawing.Size(373, 28);
			this.ComboBoxIbanUser.TabIndex = 12;
			// 
			// ComboBoxIbanOther
			// 
			this.ComboBoxIbanOther.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ComboBoxIbanOther.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBoxIbanOther.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ComboBoxIbanOther.FormattingEnabled = true;
			this.ComboBoxIbanOther.Location = new System.Drawing.Point(479, 207);
			this.ComboBoxIbanOther.Name = "ComboBoxIbanOther";
			this.ComboBoxIbanOther.Size = new System.Drawing.Size(373, 28);
			this.ComboBoxIbanOther.TabIndex = 13;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(475, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(248, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "Para göndereceğiniz IBAN seçiniz";
			// 
			// TextAmountOfMoney
			// 
			this.TextAmountOfMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextAmountOfMoney.Location = new System.Drawing.Point(479, 388);
			this.TextAmountOfMoney.Name = "TextAmountOfMoney";
			this.TextAmountOfMoney.Size = new System.Drawing.Size(373, 31);
			this.TextAmountOfMoney.TabIndex = 15;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(477, 365);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(308, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "Göndermek istediğiniz para miktarını giriniz";
			// 
			// TextAmountTr
			// 
			this.TextAmountTr.AutoSize = true;
			this.TextAmountTr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextAmountTr.ForeColor = System.Drawing.Color.Maroon;
			this.TextAmountTr.Location = new System.Drawing.Point(13, 155);
			this.TextAmountTr.Name = "TextAmountTr";
			this.TextAmountTr.Size = new System.Drawing.Size(0, 24);
			this.TextAmountTr.TabIndex = 17;
			// 
			// TextAmountEur
			// 
			this.TextAmountEur.AutoSize = true;
			this.TextAmountEur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextAmountEur.ForeColor = System.Drawing.Color.Maroon;
			this.TextAmountEur.Location = new System.Drawing.Point(13, 239);
			this.TextAmountEur.Name = "TextAmountEur";
			this.TextAmountEur.Size = new System.Drawing.Size(0, 24);
			this.TextAmountEur.TabIndex = 18;
			// 
			// TextAmountUsd
			// 
			this.TextAmountUsd.AutoSize = true;
			this.TextAmountUsd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TextAmountUsd.ForeColor = System.Drawing.Color.Maroon;
			this.TextAmountUsd.Location = new System.Drawing.Point(13, 317);
			this.TextAmountUsd.Name = "TextAmountUsd";
			this.TextAmountUsd.Size = new System.Drawing.Size(0, 24);
			this.TextAmountUsd.TabIndex = 19;
			// 
			// BtnEFT
			// 
			this.BtnEFT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnEFT.ForeColor = System.Drawing.Color.Green;
			this.BtnEFT.Location = new System.Drawing.Point(479, 490);
			this.BtnEFT.Name = "BtnEFT";
			this.BtnEFT.Size = new System.Drawing.Size(182, 67);
			this.BtnEFT.TabIndex = 20;
			this.BtnEFT.Text = "EFT YAP";
			this.BtnEFT.UseVisualStyleBackColor = true;
			// 
			// BtnExit
			// 
			this.BtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnExit.ForeColor = System.Drawing.Color.Red;
			this.BtnExit.Location = new System.Drawing.Point(693, 490);
			this.BtnExit.Name = "BtnExit";
			this.BtnExit.Size = new System.Drawing.Size(182, 67);
			this.BtnExit.TabIndex = 21;
			this.BtnExit.Text = "Exit";
			this.BtnExit.UseVisualStyleBackColor = true;
			// 
			// AccountForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(887, 576);
			this.Controls.Add(this.BtnExit);
			this.Controls.Add(this.BtnEFT);
			this.Controls.Add(this.TextAmountUsd);
			this.Controls.Add(this.TextAmountEur);
			this.Controls.Add(this.TextAmountTr);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.TextAmountOfMoney);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.ComboBoxIbanOther);
			this.Controls.Add(this.ComboBoxIbanUser);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ComboBoxPersons);
			this.Controls.Add(this.TextIbanUsd);
			this.Controls.Add(this.TextIbanEuro);
			this.Controls.Add(this.TextIbanTr);
			this.Controls.Add(this.TextWelcome);
			this.Controls.Add(this.label1);
			this.Name = "AccountForm";
			this.Text = "AccountForm";
			this.Load += new System.EventHandler(this.AccountForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label TextWelcome;
		private System.Windows.Forms.Label TextIbanTr;
		private System.Windows.Forms.Label TextIbanEuro;
		private System.Windows.Forms.Label TextIbanUsd;
		private System.Windows.Forms.ComboBox ComboBoxPersons;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox ComboBoxIbanUser;
		private System.Windows.Forms.ComboBox ComboBoxIbanOther;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox TextAmountOfMoney;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label TextAmountTr;
		private System.Windows.Forms.Label TextAmountEur;
		private System.Windows.Forms.Label TextAmountUsd;
		private System.Windows.Forms.Button BtnEFT;
		private System.Windows.Forms.Button BtnExit;
	}
}