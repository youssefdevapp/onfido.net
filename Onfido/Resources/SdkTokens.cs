using Onfido.Entities;
using Onfido.Http;

namespace Onfido.Resources
{
    public class SdkTokens : OnfidoResource
    {
        private IRequestor _requestor;

        public SdkTokens() : this(new Requestor())
        {
        }

        public SdkTokens(IRequestor requestor)
        {
            _requestor = requestor;
        }

        public SdkToken CreateForApplication(string applicantId, string applicationId)
        {
            return Create(applicantId, applicationId, null);
        }

        public SdkToken CreateForWeb(string applicantId, string referrer)
        {
            return Create(applicantId, null, referrer);
        }

        private SdkToken Create(string applicantId, string applicationId, string referrer)
        {
            const string path = "sdk_token";

            var payload = SerializeEntity(new
            {
                applicant_id = applicantId,
                application_id = applicationId,
                referrer
            });

            return _requestor.Post<SdkToken>(path, payload);
        }
    }
}