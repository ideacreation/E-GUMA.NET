namespace E_GUMA.Example
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.redeemButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBalanceButton = new System.Windows.Forms.Button();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelBalanceValue = new System.Windows.Forms.Label();
            this.labelIsRedeemable = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMessageValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNewBalance = new System.Windows.Forms.Label();
            this.textBoxAmountToRedeem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNewBalanceAfterCancelRedemption = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCancelRedemption = new System.Windows.Forms.Button();
            this.textBoxCancelRedemptionAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel4.Controls.Add(this.textBoxCode);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(586, 49);
            this.panel4.TabIndex = 26;
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCode.Location = new System.Drawing.Point(84, 11);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(274, 29);
            this.textBoxCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 24);
            this.label1.TabIndex = 21;
            this.label1.Text = "Code:";
            // 
            // redeemButton
            // 
            this.redeemButton.Location = new System.Drawing.Point(13, 99);
            this.redeemButton.Name = "redeemButton";
            this.redeemButton.Size = new System.Drawing.Size(79, 23);
            this.redeemButton.TabIndex = 2;
            this.redeemButton.Text = "OK";
            this.redeemButton.UseVisualStyleBackColor = true;
            this.redeemButton.Click += new System.EventHandler(this.redeemButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 24);
            this.label10.TabIndex = 20;
            this.label10.Text = "Check Balance";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.checkBalanceButton);
            this.panel3.Controls.Add(this.labelBalance);
            this.panel3.Controls.Add(this.labelBalanceValue);
            this.panel3.Controls.Add(this.labelIsRedeemable);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.labelMessageValue);
            this.panel3.Location = new System.Drawing.Point(12, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 224);
            this.panel3.TabIndex = 25;
            // 
            // checkBalanceButton
            // 
            this.checkBalanceButton.Location = new System.Drawing.Point(12, 49);
            this.checkBalanceButton.Name = "checkBalanceButton";
            this.checkBalanceButton.Size = new System.Drawing.Size(79, 23);
            this.checkBalanceButton.TabIndex = 0;
            this.checkBalanceButton.Text = "OK";
            this.checkBalanceButton.UseVisualStyleBackColor = true;
            this.checkBalanceButton.Click += new System.EventHandler(this.checkBalanceButton_Click);
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(12, 93);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(49, 13);
            this.labelBalance.TabIndex = 5;
            this.labelBalance.Text = "Balance:";
            // 
            // labelBalanceValue
            // 
            this.labelBalanceValue.AutoSize = true;
            this.labelBalanceValue.Location = new System.Drawing.Point(91, 94);
            this.labelBalanceValue.Name = "labelBalanceValue";
            this.labelBalanceValue.Size = new System.Drawing.Size(0, 13);
            this.labelBalanceValue.TabIndex = 6;
            // 
            // labelIsRedeemable
            // 
            this.labelIsRedeemable.AutoSize = true;
            this.labelIsRedeemable.Location = new System.Drawing.Point(91, 78);
            this.labelIsRedeemable.Name = "labelIsRedeemable";
            this.labelIsRedeemable.Size = new System.Drawing.Size(0, 13);
            this.labelIsRedeemable.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Message:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Redeemable:";
            // 
            // labelMessageValue
            // 
            this.labelMessageValue.AutoSize = true;
            this.labelMessageValue.Location = new System.Drawing.Point(91, 110);
            this.labelMessageValue.MaximumSize = new System.Drawing.Size(100, 0);
            this.labelMessageValue.Name = "labelMessageValue";
            this.labelMessageValue.Size = new System.Drawing.Size(0, 13);
            this.labelMessageValue.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "Redeem";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.redeemButton);
            this.panel2.Controls.Add(this.labelNewBalance);
            this.panel2.Controls.Add(this.textBoxAmountToRedeem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(206, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 225);
            this.panel2.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Amount (CHF):";
            // 
            // labelNewBalance
            // 
            this.labelNewBalance.AutoSize = true;
            this.labelNewBalance.Location = new System.Drawing.Point(92, 129);
            this.labelNewBalance.Name = "labelNewBalance";
            this.labelNewBalance.Size = new System.Drawing.Size(0, 13);
            this.labelNewBalance.TabIndex = 14;
            // 
            // textBoxAmountToRedeem
            // 
            this.textBoxAmountToRedeem.Location = new System.Drawing.Point(16, 73);
            this.textBoxAmountToRedeem.Name = "textBoxAmountToRedeem";
            this.textBoxAmountToRedeem.Size = new System.Drawing.Size(73, 20);
            this.textBoxAmountToRedeem.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "New Balance:";
            // 
            // labelNewBalanceAfterCancelRedemption
            // 
            this.labelNewBalanceAfterCancelRedemption.AutoSize = true;
            this.labelNewBalanceAfterCancelRedemption.Location = new System.Drawing.Point(88, 128);
            this.labelNewBalanceAfterCancelRedemption.Name = "labelNewBalanceAfterCancelRedemption";
            this.labelNewBalanceAfterCancelRedemption.Size = new System.Drawing.Size(0, 13);
            this.labelNewBalanceAfterCancelRedemption.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "New Balance:";
            // 
            // buttonCancelRedemption
            // 
            this.buttonCancelRedemption.Location = new System.Drawing.Point(12, 96);
            this.buttonCancelRedemption.Name = "buttonCancelRedemption";
            this.buttonCancelRedemption.Size = new System.Drawing.Size(76, 23);
            this.buttonCancelRedemption.TabIndex = 16;
            this.buttonCancelRedemption.Text = "OK";
            this.buttonCancelRedemption.UseVisualStyleBackColor = true;
            this.buttonCancelRedemption.Click += new System.EventHandler(this.buttonCancelRedemption_Click);
            // 
            // textBoxCancelRedemptionAmount
            // 
            this.textBoxCancelRedemptionAmount.Location = new System.Drawing.Point(15, 67);
            this.textBoxCancelRedemptionAmount.Name = "textBoxCancelRedemptionAmount";
            this.textBoxCancelRedemptionAmount.Size = new System.Drawing.Size(73, 20);
            this.textBoxCancelRedemptionAmount.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "Cancel Redemption";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Amount (CHF):";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelNewBalanceAfterCancelRedemption);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.buttonCancelRedemption);
            this.panel1.Controls.Add(this.textBoxCancelRedemptionAmount);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(403, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 225);
            this.panel1.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 309);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "E-GUMA API (v1) Example";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button redeemButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button checkBalanceButton;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label labelBalanceValue;
        private System.Windows.Forms.Label labelIsRedeemable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMessageValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNewBalance;
        private System.Windows.Forms.TextBox textBoxAmountToRedeem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelNewBalanceAfterCancelRedemption;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCancelRedemption;
        private System.Windows.Forms.TextBox textBoxCancelRedemptionAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;

    }
}