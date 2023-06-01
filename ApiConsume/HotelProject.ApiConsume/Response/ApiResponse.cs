namespace HotelProject.WebApi.Response
{
    public class ApiResponse
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }
        public object Set { get; set; }
    }
}
