namespace SmsService.Validation
{
    using System.Text.RegularExpressions;
    public class PhoneNumber
    {
        // Regular expression used to validate a phone number.
        public const string greek = @"^([\+]?30[-]?|[0])?[1-9][0-9]{8}$";
        public const string cypriot = @"^([\+]?3579[-]?|[0])?[1-9][0-9]{8}$";

        public static bool IsGreekPhoneNbr(string number)
        {
            if (number != null)
            {
                return Regex.IsMatch(number, greek);
            }
            else if(number == null)
            {
                return Regex.IsMatch(number, cypriot);
            }
            return false;
        }
    }
}
