using SportyApi.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportyApi.Services
{
    public interface IAwsLexHeadersGeneratorService
    {
        /// <summary>
        /// Method to generate the required headers for Amazon lex "RecognizeUtterance" post request.
        /// </summary>
        /// <param name="AccessKey">Acess Key of The Amazon User</param>
        /// <param name="SecretKey">Secret Key of The Amazon User </param>
        /// <param name="Host">Domain Host of The Amazon Lex Runtime Service</param>
        /// <param name="CanonicalURI">The URI Part from Domain to Query Strings</param>
        /// <param name="Method">Request Method</param>
        /// <param name="Region">Region of the Amazon Lex Service</param>
        /// <param name="RequestBody">The InputText body as a message</param>
        /// <param name="AmzDate">Hardcoded ISO-8601 Formatted Date for the Request</param>
        /// <param name="DateStamp">Hardcoded Stamp in "YYYYMMDD" Formated Date</param>
        /// <returns></returns>
        AwsLexHeaders GetAwsLexHeaders(string AccessKey,
                                       string SecretKey,
                                       string Host,
                                       string CanonicalURI,
                                       string Method,
                                       string Region,
                                       string RequestBody,
                                       string AmzDate, 
                                       string DateStamp);
    }
}
