using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

// When you copy this file to your project, ensure that System.Runtime.Serialization is added as reference.

namespace EGUMA
{
    public static class JSONSerializer<TType> where TType : class
    {
        public static string Serialize(TType instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(TType));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        public static TType DeSerialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }
    
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
        public class RedeemRequest
        {
            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }
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

            [DataMember(Name = "redeem_token")]
            public string RedeemToken { get; set; }
        }

        [DataContract]
        public class CancelRedemptionRequest
        {
            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }

            [DataMember(Name = "redeem_token")]
            public int RedeemToken { get; set; }
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
        public class DepotVoucherActivateStatusResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "can_be_activated")]
            public bool CanBeActivated { get; set; }

            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }

            [DataMember(Name = "message")]
            public string Message { get; set; }

            [DataMember(Name = "free_amount")]
            public bool FreeAmount { get; set; }
        }

        [DataContract]
        public class ActivateRequest
        {
            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }
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
        public class DepotVoucherDeactivateStatusResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "can_be_deactivated")]
            public bool CanBeDeactivated { get; set; }

            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }

            [DataMember(Name = "message")]
            public string Message { get; set; }
        }

        [DataContract]
        public class DeactivateResult
        {
            [DataMember(Name = "code")]
            public string Code { get; set; }

            [DataMember(Name = "amount_in_cents")]
            public int AmountInCents { get; set; }
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
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/redeem.json?apikey=510e32c594d84816a4af9df0
                var url = string.Format("{0}/v1/vouchers/{1}/redeem.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url,
                                                                 JSONSerializer<RedeemRequest>.Serialize(
                                                                     new RedeemRequest {AmountInCents = amountInCents}));



                    return JSONSerializer<RedeemResult>.DeSerialize(resultAsJsonString);
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
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                
                // example url: https://api.e-guma.ch/v1/vouchers/KSK3-L8VE-TSR5/cancel_redemption.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/vouchers/{1}/cancel_redemption.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, JSONSerializer<CancelRedemptionRequest>.Serialize(
                                                                     new CancelRedemptionRequest { AmountInCents = amountInCents }));


                    return JSONSerializer<CancelRedemptionResult>.DeSerialize(resultAsJsonString);
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public DepotVoucherActivateStatusResult GetDepotVoucherActivateStatus(string voucherCode)
        {
            using (var client = CreateWebClient())
            {
                // example url: https://api.e-guma.ch/v1/depot_vouchers/KSK3-L8VE-TSR5/activate_status.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/depot_vouchers/{1}/activate_status.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.DownloadString(url);

                    return JSONSerializer<DepotVoucherActivateStatusResult>.DeSerialize(resultAsJsonString);
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
                // example url: https://api.e-guma.ch/v1/depot_vouchers/KSK3-L8VE-TSR5/activate.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/depot_vouchers/{1}/activate.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, string.Empty);

                    return JSONSerializer<ActivateResult>.DeSerialize(resultAsJsonString);
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public ActivateResult ActivateDepotVoucherWithFreeAmount(string voucherCode, int amountInCents)
        {
            using (var client = CreateWebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                // example url: https://api.e-guma.ch/v1/depot_vouchers/KSK3-L8VE-TSR5/activate.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/depot_vouchers/{1}/activate.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url,
                                             JSONSerializer<ActivateRequest>.Serialize(
                                                 new ActivateRequest { AmountInCents = amountInCents }));

                    return JSONSerializer<ActivateResult>.DeSerialize(resultAsJsonString);
                }
                catch (WebException exception)
                {
                    HandleExceptions(exception);
                    throw;
                }
            }
        }

        public DepotVoucherDeactivateStatusResult GetDepotVoucherDeactivateStatus(string voucherCode)
        {
            using (var client = CreateWebClient())
            {
                // example url: https://api.e-guma.ch/v1/depot_vouchers/KSK3-L8VE-TSR5/deactivate_status.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/depot_vouchers/{1}/deactivate_status.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.DownloadString(url);

                    return JSONSerializer<DepotVoucherDeactivateStatusResult>.DeSerialize(resultAsJsonString);
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
                // example url: https://api.e-guma.ch/v1/depot_vouchers/KSK3-L8VE-TSR5/deactivate.json?apikey=510e32c594d84816a4af9df0"
                var url = string.Format("{0}/v1/depot_vouchers/{1}/deactivate.json?apikey={2}", BaseUrl, voucherCode, ApiKey);

                try
                {
                    var resultAsJsonString = client.UploadString(url, string.Empty);

                    return JSONSerializer<DeactivateResult>.DeSerialize(resultAsJsonString);
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
