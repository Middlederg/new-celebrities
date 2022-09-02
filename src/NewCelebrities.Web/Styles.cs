namespace NewCelebrities.Web
{
    public class Styles
    {
        public static string Button = $"text-white bg-{Colors.Primary} hover:bg-{Colors.PrimaryLighter} border-{Colors.Primary} hover:border-{Colors.PrimaryLighter}";
        public static string BigButton = $"w-full px-4 py-2 text-lg font-semibold text-white transition-colors duration-300 bg-{Colors.Primary} rounded-md shadow hover:{Colors.PrimaryDarker} focus:outline-none focus:ring-{Colors.Primary300} focus:ring-4";
        public static string ButtonOutlined = $"text-{Colors.Primary} hover:bg-{Colors.Primary} border-{Colors.Primary}";
        public static string DefaultLink = $"cursor-pointer text-sm text-{Colors.Primary600} hover:underline hover:text-{Colors.Primary}";
        public static string InverseLink = $"cursor-pointer underline hover:text-{Colors.Primary200}";

        public static string LabelStyle => $"text-sm font-semibold text-{Colors.TextSemiMuted}";
        public static string InputStyle => $"px-4 py-2 transition duration-300 border border-{Colors.TextLight} rounded focus:border-transparent focus:outline-none focus:ring-4 focus:ring-{Colors.Primary300}";
        public static string ValidationMessageStyle => $"text-sm text-{Colors.Error} tracking-wide";
    }
}
