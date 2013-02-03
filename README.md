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
 
 
Documentation
=============
[Official documentation](http://www.e-guma.ch/developers)
