using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EGUMA
{
    // When you copy this file to your project, ensure that System.Runtime.Serialization is added as reference.
    public class Eguma
    {
        [DataContract]
        public class BalanceResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "balance_in_cents")]
            public int BalanceInCents { get; set; }

            [DataMember(Name = "total_amount_in_cents")]
            public int TotalAmountInCents { get; set; }

            [DataMember(Name = "message")]
            public string Message { get; set; }

            [DataMember(Name = "is_redeemable")]
            public bool IsRedeemable { get; set; }
        }

        [DataContract]
        public class RedeemResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "balance_in_cents")]
            public int BalanceInCents { get; set; }

            [DataMember(Name = "voucher_document_url")]
            public string VoucherDocumentUrl { get; set; }
        }

        [DataContract]
        public class CancelRedemptionResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "balance_in_cents")]
            public int BalanceInCents { get; set; }
        }

        [DataContract]
        public class ActivateResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }
        }

        [DataContract]
        public class DeactivateResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }
        }

        [DataContract]
        public class DepotVoucherStatusResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }

            [DataMember(Name = "is_in_depot")]
            public bool IsInDepot { get; set; }
        }


        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }

        public Eguma(string apiKey)
        {
            BaseUrl = "https://api.e-guma.ch";

            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Please set an API Key.");

            ApiKey = apiKey;
        }

        public static decimal ConvertCentsToFrancs(int cents)
        {
            return cents / 100m;
        }

        public static int ConvertFrancsToCents(decimal francs)
        {
            return (int)(francs * 100);
        }

        private WebClient CreateWebClient()
        {
            // is required when the client is behind a proxy with authentication
            var proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            return new WebClient
                {
                    Proxy = proxy
                };
        }

        public BalanceResult GetBalance(string voucherCode)
        {
            using (var client = CreateWebClient())
            {
                client.Encoding = Encoding.UTF8;

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/balance.json?apikey=510e32c594d84816a4af9df0
                var url = string.Format("{0}/v1/vouchers/{1}/balance.json?apikey={2}", BaseUrl, voucherCode, ApiKey);


                try
                {
                    var resultAsJsonString = client.DownloadString(url);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return (BalanceResult)new DataContractJsonSerializer(typeof(BalanceResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public RedeemResult Redeem(string voucherCode, int amountInCents)
        {
            using (var client = CreateWebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var postData = string.Format("amount_in_cents={0}", amountInCents);

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/redeem.json?apikey=510e32c594d84816a4af9df0
                var url = string.Format("{0}/v1/vouchers/{1}/redeem.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, postData);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return (RedeemResult)new DataContractJsonSerializer(typeof(RedeemResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public CancelRedemptionResult CancelRedemption(string voucherCode, int amountInCents)
        {
            using (var client = CreateWebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var postData = string.Format("amount_in_cents={0}", amountInCents);

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/cancel_redemption.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/cancel_redemption.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, postData);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return (CancelRedemptionResult)new DataContractJsonSerializer(typeof(CancelRedemptionResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public ActivateResult ActivateDepotVoucher(string voucherCode)
        {
            using (var client = CreateWebClient())
            {
                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/activate.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/activate.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, string.Empty);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return (ActivateResult)new DataContractJsonSerializer(typeof(ActivateResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        // Only used for special implementations. Normally you should use 'ActivateDepotVoucher'
        public ActivateResult ActivateDepotVoucherWithCustomAmount(string voucherCode, int amountInCents)
        {
            using (var client = CreateWebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var postData = string.Format("amount_in_cents={0}", amountInCents);

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/activate.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/activate.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, postData);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return (ActivateResult)new DataContractJsonSerializer(typeof(ActivateResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public DeactivateResult DeactivateDepotVoucher(string voucherCode)
        {
            using (var client = CreateWebClient())
            {
                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/deactivate.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/deactivate.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, string.Empty);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return (DeactivateResult)new DataContractJsonSerializer(typeof(DeactivateResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public DepotVoucherStatusResult GetDepotVoucherStatus(string voucherCode)
        {
            using (var client = CreateWebClient())
            {
                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/depot_status.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/depot_status.json?apikey={2}", BaseUrl, voucherCode, ApiKey);
                
                try
                {
                    var resultAsJsonString = client.DownloadString(url);

                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(resultAsJsonString)))
                    {
                        return
                            (DepotVoucherStatusResult)
                            new DataContractJsonSerializer(typeof (DepotVoucherStatusResult)).ReadObject(stream);
                    }
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        private static void HandleExceptions(WebException exception)
        {
            var response = exception.Response as HttpWebResponse;
            if (response == null) return;

            var statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.BadRequest ||
                statusCode == HttpStatusCode.InternalServerError ||
                statusCode == HttpStatusCode.Unauthorized)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    throw new ArgumentException(streamReader.ReadToEnd());
                }
            }
        }
    }
}
