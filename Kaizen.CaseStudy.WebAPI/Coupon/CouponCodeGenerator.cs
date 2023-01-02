using System.Text.RegularExpressions;

namespace Kaizen.CaseStudy.WebAPI.Coupon;

public class CouponCodeGenerator
{
    private static readonly Random _random = new();
    private static readonly char[] _chars = "ACDEFGHKLMNPRTXYZ234579".ToCharArray();
    private static readonly HashSet<string> _codes = new();
    private const string COUPON_CODE_PATTERN = "^[ACDEFGHKLMNPRTXYZ234579]{8}$";

    private static string GenerateCode()
    {
        var code = new char[8];
        for (int i = 0; i < 8; i++)
        {
            code[i] = _chars[_random.Next(_chars.Length)];
        }
        return new string(code);
    }

    public static string GenerateCouponCode()
    {
        while (true)
        {
            string code = GenerateCode();
            if (_codes.Add(code))
            {
                return code;
            }
        }
    }

    public static bool IsValidCouponCode(string couponCode) 
    {
        return _codes.Contains(couponCode);
    }

    public static bool IsFormatValidCouponCode(string couponCode) 
    {
        return Regex.IsMatch(couponCode, COUPON_CODE_PATTERN);
    }
}
