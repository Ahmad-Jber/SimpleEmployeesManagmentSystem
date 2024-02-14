namespace EntityFrameworkTutorial.Helpers
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double ExpireMinutes { get; set; }
        public double ExpireSeconds { get; set; }
        public double ExpireHours { get; set; }
        public double ExpireDays { get; set; }
        public double ExpireMonths { get; set; }
        public double ExpireYears { get; set; }
    }
}