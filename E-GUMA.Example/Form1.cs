using System;
using System.Windows.Forms;
using EGUMA;

namespace E_GUMA.Example
{
    public partial class Form1 : Form
    {
        // Uses the api key of the user "demo" from the Beethoven Palace account
        private readonly Eguma _eguma = new Eguma("510e32c594d84816a4af9df0");

        public Form1()
        {
            InitializeComponent();

            OverrideDefaultSettings();
        }

        private void checkBalanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _eguma.GetBalance(textBoxCode.Text);

                labelIsRedeemable.Text = result.IsRedeemable ? "Yes" : "No";
                labelBalanceValue.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");
                labelTotalAmountValue.Text = Eguma.ConvertCentsToFrancs(result.TotalAmountInCents).ToString("F2");
                labelMessageValue.Text = result.Message;
                labelBookAsDiscountValue.Text = result.BookAsDiscount.ToString();
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

                var result = _eguma.Redeem(textBoxCode.Text, amountInCents);
                labelNewBalance.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");

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

                var result = _eguma.CancelRedemption(textBoxCode.Text, amountInCents);
                labelNewBalanceAfterCancelRedemption.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");
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
                var result = _eguma.ActivateDepotVoucher(textBoxCodeDepot.Text);
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
                var result = _eguma.DeactivateDepotVoucher(textBoxCodeDepot.Text);
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
                var result = _eguma.GetDepotVoucherStatus(textBoxCodeDepot.Text);
                labelDepotVoucherStatusAmount.Text = Eguma.ConvertCentsToFrancs(result.AmountInCents).ToString("F2");
                labelDepotVouherStatusInDepot.Text = result.IsInDepot ? "Yes" : "No";
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

        // We only use this method when we want to test the E-GUMA API locally
        private void OverrideDefaultSettings()
        {
            var useLocalApi = System.Configuration.ConfigurationManager.AppSettings["UseLocalApi"];
            if (string.IsNullOrEmpty(useLocalApi) || useLocalApi != "true")
                return;

            Text += " - Connecting to local API";

            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"]))
            {
                _eguma.BaseUrl = System.Configuration.ConfigurationManager.AppSettings["ApiBaseUrl"];
            }

            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ApiKey"]))
            {
                _eguma.ApiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
            }

            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ExampleVoucherCode"]))
            {
                textBoxCode.Text = System.Configuration.ConfigurationManager.AppSettings["ExampleVoucherCode"];
            }

            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["ExampleDepotVoucherCode"]))
            {
                textBoxCodeDepot.Text = System.Configuration.ConfigurationManager.AppSettings["ExampleDepotVoucherCode"];
            }
        }
    }
}
