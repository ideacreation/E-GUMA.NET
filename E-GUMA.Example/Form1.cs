using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGUMA;

namespace E_GUMA.Example
{
    public partial class Form1 : Form
    {
        private readonly Eguma _eguma = new Eguma("510e32c594d84816a4af9df0");

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBalanceButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = _eguma.GetBalance(textBoxCode.Text);

                labelIsRedeemable.Text = result.IsRedeemable ? "Yes" : "No";
                labelBalanceValue.Text = Eguma.ConvertCentsToFrancs(result.BalanceInCents).ToString("F2");
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
    }
}
