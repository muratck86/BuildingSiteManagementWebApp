using System;
using System.Linq;
using System.Net.Mail;

namespace BuildingSiteManagementWebApp.Common.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string input)
        {
            try
            {
                MailAddress email = new MailAddress(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsValidNationalId(string input)
        {
            return
                input is not null &&
                input.Length == 11 &&
                input.All(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(input) &&
                input.Substring(0, 1) != "0" &&
                sumCheck();

            bool sumCheck()
            {
                var arr = new int[11];
                for (int i = 0; i < 11; i++)
                {
                    arr[i] = (int)input[i] - '0';
                }

                int sum1 = 0;
                int sum2 = 0;
                int sum3 = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum1 += arr[i];
                    if (i == 8)
                    {
                        if ((sum1 + arr[9]) % 10 != arr[10])
                            return false;
                    }
                    if (i % 2 == 0)
                        sum2 += arr[i];
                    else
                        sum3 += arr[i];
                }
                return (sum2 * 7 - sum3) % 10 == arr[9];
            }
        }
    }
}
