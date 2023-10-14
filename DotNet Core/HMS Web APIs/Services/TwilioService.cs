using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace HMS_Web_APIs.Services
{
    public class TwilioService
    {
        private readonly string _accountSid;
        private readonly string _authToken;

        public TwilioService(string accountSid, string authToken)
        {
            _accountSid = accountSid;
            _authToken = authToken;

            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendSms(string toPhoneNumber, string message)
        {
            var to = new PhoneNumber(toPhoneNumber);
            var from = new PhoneNumber("+16562231054");

            MessageResource.Create(
                to: to,
                from: from,
                body: message
            );
        }
    }
}
