using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace EGUMA
{
    public class Eguma
    {
        [DataContract]
        public class BalanceResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "balance_in_cents")]
            public int BalanceInCents { get; set; }

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
        }

        [DataContract]
        public class CancelRedemptionResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "balance_in_cents")]
            public int BalanceInCents { get; set; }
        }

        public string BaseUri { get; set; }
        private readonly string _apiKey;

        public Eguma(string apiKey)
        {
            BaseUri = "https://api.e-guma.ch";

            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentException("Please set an API Key.");

            _apiKey = apiKey;
        }

        public static decimal ConvertCentsToFrancs(int cents)
        {
            return cents / 100m;
        }

        public static int ConvertFrancsToCents(decimal francs)
        {
            return (int)(francs * 100);
        }

        public BalanceResult GetBalance(string voucherCode)
        {
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/balance.json?apikey=510e32c594d84816a4af9df0
                var url = string.Format("{0}/v1/vouchers/{1}/balance.json?apikey={2}", BaseUri, voucherCode, _apiKey);

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
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var postData = string.Format("amount_in_cents={0}", amountInCents);

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/redeem.json?apikey=510e32c594d84816a4af9df0
                var url = string.Format("{0}/v1/vouchers/{1}/redeem.json?apikey={2}", BaseUri, voucherCode, _apiKey);

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
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                var postData = string.Format("amount_in_cents={0}", amountInCents);

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/cancel_redemption.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/cancel_redemption.json?apikey={2}", BaseUri, voucherCode, _apiKey);

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

        private static void HandleExceptions(WebException exception)
        {
            var response = exception.Response as HttpWebResponse;
            if (response == null) return;

            var statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.BadRequest ||
                statusCode == HttpStatusCode.InternalServerError)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    throw new ArgumentException(streamReader.ReadToEnd());
                }
            }
        }
    }
}
