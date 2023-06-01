namespace HotelProject.WebUI.Models.Staff
{
    public class ResponseViewModel
    {
        public bool isSuccessful { get; set; }
        public string message { get; set; }
        public StaffViewModel[] set { get; set; }
    }

    public class StaffViewModel
    {
        public int staffID { get; set; }
        public string name { get; set; }
        public string jobTitle { get; set; }
        public string twitterUrl { get; set; }
        public string instagramUrl { get; set; }
    }

}
