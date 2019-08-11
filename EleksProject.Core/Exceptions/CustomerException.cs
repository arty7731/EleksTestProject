using EleksProject.Core.Enums;
using System;
using System.Collections.Generic;

namespace EleksProject.Core.Exceptions
{
    public class CustomerException : Exception
    {
        private static Dictionary<CustomerErrorCode, string> errorCodeToMessage = new Dictionary<CustomerErrorCode, string>
        {
            { CustomerErrorCode.InvalidCustomerId, "Invalid Customer ID." },
            { CustomerErrorCode.InvalidEmail, "Invalid Email." },
            { CustomerErrorCode.NoInquiryCriteria, "No inquiry criteria." },
        };

        public CustomerException(CustomerErrorCode errorCode)
            : base(GetErrorMessage(errorCode, null))
        {
            this.ErrorCode = errorCode;
        }

        public CustomerException(CustomerErrorCode errorCode, string extraErrorMessage)
            : base(GetErrorMessage(errorCode, extraErrorMessage))
        {
            this.ErrorCode = errorCode;
        }

        public CustomerErrorCode ErrorCode { get; private set; }

        private static string GetErrorMessage(CustomerErrorCode errorCode, string extraErrorMessage)
        {
            string message = errorCodeToMessage.ContainsKey(errorCode)
                ? CustomerException.errorCodeToMessage[errorCode]
                : "Unexpected error.";

            return string.IsNullOrWhiteSpace(extraErrorMessage)
                ? message
                : string.Concat(message.TrimEnd('.'), " ", extraErrorMessage, ".");
        }
    }
}
