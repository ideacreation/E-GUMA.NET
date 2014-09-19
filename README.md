E-GUMA.NET
=========
E-GUMA.NET is a wrapper for the E-GUMA REST API.

Example
=======

Balance
-------
    var apiKey = "510e32c594d84816a4af9df0";
    var voucherCode = "JWCP-P7QV-25S4";
    var result = new Eguma(apiKey).GetBalance(voucherCode);
 

Redeem
-------
    var apiKey = "510e32c594d84816a4af9df0";
    var voucherCode = "JWCP-P7QV-25S4";
    var result = new Eguma(apiKey).Redeem(voucherCode, 2000); // the amount is in cents!

 
Cancel Redemption
-----------------
    var apiKey = "510e32c594d84816a4af9df0";
    var voucherCode = "JWCP-P7QV-25S4";
    var result = new Eguma(apiKey).CancelRedemption(voucherCode, 2000); // the amount is in cents!
 
 
Activate a Depot Voucher
------------------------
    var apiKey = "510e32c594d84816a4af9df0";
    var voucherCode = "JWCP-P7QV-25S4";
    var result = new Eguma(apiKey).GetDepotVoucherActivateStatus(voucherCode);
    if (result.CanBeActivated)
    {
      // add the voucher as order line
    }
    else
    {
      // show result.Message
    }
 
    .....
    
    // when completing the order
    foreach (orderLine in orderLines)
    {
        if (orderLine.IsVoucher)
            new Eguma(apiKey).ActivateDepotVoucher(orderLine.VoucherCode);
    }
    
More info in our [Integration Guide](http://www.e-guma.ch/developers/integration-guide/#depot)
    
 
Documentation
=============
[Official documentation](http://www.e-guma.ch/developers)
