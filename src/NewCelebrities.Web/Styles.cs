namespace NewCelebrities.Web
{
    public class Styles
    {
        public static string Button = $"text-{Colors.Background} bg-{Colors.Primary} hover:bg-{Colors.PrimaryLighter} border-{Colors.Primary} hover:border-{Colors.PrimaryLighter}";
        public static string ButtonOutlined = $"text-{Colors.Primary} hover:bg-{Colors.Primary} border-{Colors.Primary}";
        public static string DefaultLink = $"cursor-pointer text-sm text-{Colors.Primary600} hover:underline hover:text-{Colors.Primary}";
        public static string InverseLink = $"cursor-pointer underline hover:text-{Colors.Primary200}";

        public static string LabelStyle => $"text-sm font-semibold text-{Colors.TextSemiMuted}";
        public static string InputStyle => $"px-4 py-2 transition duration-300 border border-{Colors.TextLight} rounded focus:border-transparent focus:outline-none focus:ring-4 focus:ring-{Colors.Primary300}";
        public static string ValidationMessageStyle => $"text-sm text-{Colors.Error} tracking-wide";
        public static string Icon => $"w-6 h-6";
        public static string SmallHeader => $"text-xl py-1 font-semibold text-{Colors.Primary} border-b-4 border-dashed border-{Colors.Primary500}";
        public static string Paragraph => $"text-md leading-relaxed";
    }
}
