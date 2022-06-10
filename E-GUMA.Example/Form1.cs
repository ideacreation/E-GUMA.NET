using System;
using System.Diagnostics;
using System.Windows.Forms;
using EGUMA;

namespace E_GUMA.Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitUi();
        }

        private void InitUi()
        {
            textBoxCode.Text = System.Configuration.ConfigurationManager.AppSettings["VoucherCode"];
            textBoxCodeDepot.Text = System.Configuration.ConfigurationManager.AppSettings["DepotVoucherCode"];

            Text += " | " + System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
        }

        private Eguma CreateEguma()
        {
            var eguma = new Eguma(System.Configuration.ConfigurationManager.AppSettings["ApiKey"]);

            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"]))
            {
                eguma.BaseUrl = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
            }

            return eguma;
        }

        private void checkBalanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = CreateEguma().GetBalance(textBoxCode.Text);

                labelCode.Text = result.Code;
                labelIsRedeemable.Text = result.IsRedeemable ? "Yes" : "No";
                labelBalanceValue.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");
                labelTotalAmountValue.Text = Eguma.ConvertCentsToFrancs(result.TotalAmountInCents).ToString("F2");
                labelMessageValue.Text = result.Message;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void redeemButton_Click(object sender, EventArgs e)
        {
            try
            {
                var amountInCents = Eguma.ConvertFrancsToCents(decimal.Parse(textBoxAmountToRedeem.Text));

                var result = CreateEguma().Redeem(textBoxCode.Text, amountInCents);
                labelNewBalance.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");
                labelRedeemCodeValue.Text = result.Code;
                labelRedeemToken.Text = result.RedeemToken;
                textBoxCancelRedemptionToken.Text = result.RedeemToken;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonCancelRedemption_Click(object sender, EventArgs e)
        {
            try
            {
                var amountInCents = Eguma.ConvertFrancsToCents(decimal.Parse(textBoxCancelRedemptionAmount.Text));

                var result = CreateEguma().CancelRedemption(textBoxCode.Text, amountInCents, textBoxCancelRedemptionToken.Text);
                labelNewBalanceAfterCancelRedemption.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");
                labelCancelRedemptionCodeValue.Text = result.Code;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonActivate_Click(object sender, EventArgs e)
        {
            try
            {
                Eguma.ActivateResult result;

                if (string.IsNullOrEmpty(textBoxActivateFreeAmount.Text))
                {
                    result = CreateEguma().ActivateDepotVoucher(textBoxCodeDepot.Text);
                }
                else
                {
                    result = CreateEguma().ActivateDepotVoucherWithFreeAmount(textBoxCodeDepot.Text, Eguma.ConvertFrancsToCents(decimal.Parse(textBoxActivateFreeAmount.Text)));
                }
                
                labelDepotActivateAmount.Text = Eguma.ConvertCentsToFrancs(result.AmountInCents).ToString("F2");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonDeactivate_Click(object sender, EventArgs e)
        {
            try
            {
                var result = CreateEguma().DeactivateDepotVoucher(textBoxCodeDepot.Text);
                labelDepotDeactivateAmount.Text = Eguma.ConvertCentsToFrancs(result.AmountInCents).ToString("F2");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonDepotVoucherStatus_Click(object sender, EventArgs e)
        {
            try
            {
                var result = CreateEguma().GetDepotVoucherActivateStatus(textBoxCodeDepot.Text);
                labelDepotVoucherStatusFreeAmount.Text = result.FreeAmount ? "Yes" : "No";
                labelDepotVoucherStatusAmount.Text = Eguma.ConvertCentsToFrancs(result.AmountInCents).ToString("F2");
                labelDepotVoucherStatusCanBeActivated.Text = result.CanBeActivated ? "Yes" : "No";
                labelDepotActivateStatusMessage.Text = result.Message;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonOpenActivateDlg_Click(object sender, EventArgs e)
        {
            new ActivateDepotVoucherForm().Show();
        }

        private void buttonRedeemVoucher_Click(object sender, EventArgs e)
        {
            new RedeemVoucherForm().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.e-guma.ch/developers/voucher2mobile-alias/");
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var result = CreateEguma().GetDepotVoucherDeactivateStatus(textBoxCodeDepot.Text);
                labelDepotVoucherDeactivateStatusAmount.Text = Eguma.ConvertCentsToFrancs(result.AmountInCents).ToString("F2");
                labelDepotVoucherDeactivateStatusCanBeDeactivated.Text = result.CanBeDeactivated ? "Yes" : "No";
                labelDepotVoucherDeactivateStatusMessage.Text = result.Message;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void labelMessageValue_Click(object sender, EventArgs e)
        {
            MessageBox.Show(labelMessageValue.Text);
        }

        private void labelRedeemToken_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelRedeemToken.Text);
        }
    }
}
