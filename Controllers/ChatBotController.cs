using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SportyApi.Helpers;
using SportyApi.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SportyApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IAwsLexHeadersGeneratorService _awsLexHeadersGeneratorService;
        private readonly AwsCredentials _awsCredentials;

        public ChatBotController(IAwsLexHeadersGeneratorService awsLexHeadersGeneratorService,
                                IOptions<AwsCredentials> awsCredentialsOptions)
        {
            _awsLexHeadersGeneratorService = awsLexHeadersGeneratorService;
            _awsCredentials = awsCredentialsOptions.Value;
        }

        [HttpPost("chat-bot")]
        public async Task<IActionResult> GetBotReponseAsync([FromQuery] string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("message invalid");
            }

            var host = "runtime-v2-lex.eu-west-1.amazonaws.com";
            var method = "POST";
            var uriCanonical = "/bots/U8HV1XXGOY/botAliases/XQSGQ2PXPB/botLocales/en_US/sessions/123/text";
            var region = "eu-west-1";

            var body = "{\"text\":\"";
            body += $"{message.Trim()}";
            body += "\"}";

            var lexRequestHeaders = _awsLexHeadersGeneratorService.GetAwsLexHeaders(_awsCredentials.AccessKey,
                                                                                    _awsCredentials.SecretKey,
                                                                                    host,
                                                                                    uriCanonical,
                                                                                    method,
                                                                                    region,
                                                                                    body,
                                                                                    null, null);

            try
            {
                var botResponse = await MakeLexRequest("https://"+host+uriCanonical, method, body,
                                                       lexRequestHeaders.XAmzContentSha256,
                                                       lexRequestHeaders.XAmzDate, lexRequestHeaders.AuthorizationHeader);
                return Ok(new { message = botResponse});
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private async Task<string> MakeLexRequest(string url,
                                            string method,
                                            string body, 
                                            string amzContentSha256, string amzDate, string authorizationHeader)
        {
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = method;

            httpRequest.Headers["X-Amz-Content-Sha256"] = amzContentSha256;
            httpRequest.Headers["X-Amz-Date"] = amzDate;
            httpRequest.Headers["Authorization"] = authorizationHeader;
            httpRequest.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(await httpRequest.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(body);
            }

            var httpResponse = (HttpWebResponse)await httpRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                return (string)json.messages[0].content;
            }
        }
    }
}
