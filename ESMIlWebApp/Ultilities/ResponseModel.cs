namespace ESMIlWebApp.Ultilities
{
    public class ResponseModel
    {
        public string? message { get; set; }
        public bool hasError { get; set; }
        public int statusaCode { get; set; }
        public object? data { get; set; }
    }
}
