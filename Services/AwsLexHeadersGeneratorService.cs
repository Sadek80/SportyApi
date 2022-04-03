using SportyApi.Helpers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SportyApi.Services
{
    public class AwsLexHeadersGeneratorService : IAwsLexHeadersGeneratorService
    {
        public AwsLexHeaders GetAwsLexHeaders(string AccessKey,
                                              string SecretKey,
                                              string Host, string CanonicalURI,
                                              string Method, string Region, string RequestBody, 
                                              string AmzDate, string DateStamp)
        {
            var payloadHash = ToHexString(ComputeSha256Hash(RequestBody));
            var canonicalQuerystring = "";
            var service = "lex";

            var utcNow = DateTime.UtcNow;

            var amzDate = AmzDate ?? utcNow.ToString("yyyyMMddTHHmmssK");
            var dateStamp = DateStamp ?? utcNow.ToString("yyyyMMdd");

            // Fixed Signed Headers For this request
            var signedHeaders = "host;x-amz-content-sha256;x-amz-date";

            // Generate the Canonical Headers
            var canonicalHeaders = "host:" + Host + '\n' + "x-amz-content-sha256:" +
                                   payloadHash + '\n' + "x-amz-date:" + amzDate + '\n';

            // Generate the Canonical Request
            var canonicalRequest = Method + '\n' + CanonicalURI + '\n' + canonicalQuerystring +
                                   '\n' + canonicalHeaders + '\n' + signedHeaders + '\n' + payloadHash;

            var algorithm = "AWS4-HMAC-SHA256";
            var credentialScope = dateStamp + "/" + Region + "/" + service + "/" + "aws4_request";

            // Generate String to Sign
            var stringToSign = algorithm + '\n' + amzDate + '\n' + credentialScope +
              '\n' + ToHexString(ComputeSha256Hash(canonicalRequest));

            // Generate Signature
            var signingKey = getSignatureKey(SecretKey, dateStamp, Region, service);
            var signature = ToHexString(HmacSHA256(stringToSign, signingKey));

            // Final Authorization Header
            var authorizationHeader = algorithm + ' ' + "Credential=" + AccessKey + '/' +
               credentialScope + ", " + "SignedHeaders=" + signedHeaders + ", " + "Signature=" + signature;

            return new AwsLexHeaders
            {
                AuthorizationHeader = authorizationHeader,
                Host = Host,
                XAmzDate = amzDate,
                XAmzContentSha256 = payloadHash
            }; 
        }

        private byte[] ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return bytes;
            }
        }

        private byte[] HmacSHA256(string data, byte[] key)
        {
            String algorithm = "HmacSHA256";
            KeyedHashAlgorithm kha = KeyedHashAlgorithm.Create(algorithm);
            kha.Key = key;

            return kha.ComputeHash(Encoding.UTF8.GetBytes(data));
        }

        /// <summary>
        /// Generate the Signing Key used in signature generation
        /// </summary>
        /// <param name="key">Secret Key of the user</param>
        /// <param name="dateStamp"> Date Stamp in "YYYYMMDD" Formated Date</param>
        /// <param name="regionName">Region of the Amazon Lex Service</param>
        /// <param name="serviceName">Service Name</param>
        /// <returns></returns>
        private byte[] getSignatureKey(String key, String dateStamp, String regionName, String serviceName)
        {
            // make the key based on the secret key
            byte[] kSecret = Encoding.UTF8.GetBytes(("AWS4" + key).ToCharArray());
            // make the chain of hashing to get the signing key
            byte[] kDate = HmacSHA256(dateStamp, kSecret);
            byte[] kRegion = HmacSHA256(regionName, kDate);
            byte[] kService = HmacSHA256(serviceName, kRegion);
            byte[] kSigning = HmacSHA256("aws4_request", kService);

            return kSigning;
        }

        public static string ToHexString(byte[] array)
        {
            StringBuilder hex = new StringBuilder(array.Length * 2);
            foreach (byte b in array)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
