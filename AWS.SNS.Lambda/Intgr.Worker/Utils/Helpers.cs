using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Intgr.Worker.Utils
{
    public static class Helpers
    {
        const string phonePattern = @"((?:\(?[2-9](?(?=1)1[02-9]|(?(?=0)0[1-9]|\d{2}))\)?\D{0,3})(?:\(?[2-9](?(?=1)1[02-9]|\d{2})\)?\D{0,3})\d{4})";
        public static bool IsPhoneNumberValid(string phoneNumber) {

            if (string.IsNullOrEmpty(phoneNumber)) {
                return false;
            }

            Regex regex = new Regex(phonePattern);
            return regex.IsMatch(phoneNumber);

        }

        public static string GetPhoneDigits(string phoneNumber) {
            return new String(phoneNumber.Where(Char.IsDigit).ToArray());
        }
    }
}
