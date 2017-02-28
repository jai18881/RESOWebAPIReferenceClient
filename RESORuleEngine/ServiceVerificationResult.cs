using System.Net;
namespace RESORuleEngine
{
    public class ServiceVerificationResult
    {
        public bool? Passed = null;
        public ExtensionRuleViolationInfo ViolationInfo = null;
        public HttpStatusCode? ResponseStatusCode = null;

        public ServiceVerificationResult(bool? passed, ExtensionRuleViolationInfo violationInfo, HttpStatusCode? responseStatusCode = null)
        {
            Passed = passed;
            ViolationInfo = violationInfo;
            ResponseStatusCode = responseStatusCode;
        }
    }
}