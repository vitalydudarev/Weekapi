namespace Instagram.Api
{
	public class Meta
	{
		public int Code { get; set; }
		public string ErrorType { get; set; }
		public string ErrorMessage { get; set; }
	}

	public class Pagination
	{
		public string NextUrl { get; set; }
		public string NextMaxId { get; set; }
	}

	public class ApiResponse<T>
	{
		public Meta Meta { get; set; }
		public Pagination Pagination { get; set; }
		public T Data { get; set; }
	}

	public class User
	{
		public string Username { get; set; }
		public string Id { get; set; }
		public string ProfilePicture { get; set; }
		public string FullName { get; set; }
	}

	public class UserInfo
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string FullName { get; set; }
		public string ProfilePicture { get; set; }
		public string Bio { get; set; }
		public string Website { get; set; }
		public Count Counts { get; set; }
	}

	public class Count
	{
		public int Media { get; set; }
		public int Follows { get; set; }
		public int FollowedBy { get; set; }
	}

	public class Images
	{
		public ImageItem LowResolution { get; set; }
		public ImageItem Thumbnail { get; set; }
		public ImageItem StandardResolution { get; set; }
	}

    public class ImageItem
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Comments
    {
        public int Count { get; set; }
    }

    public class Likes
    {
        public int Count { get; set; }
    }

    public class Caption
    {
        public string Id { get; set; }
        public string CreatedTime { get; set; }
        public string Text { get; set; }
        public User From { get; set; }
    }

    public enum MediaType
    {
        Image,
        Video
    }

	public class Media
	{
		public string Id { get; set; }
        public MediaType Type { get; set; }
        public Location Location { get; set; }
        public Images Images { get; set; }
        public Comments Comments { get; set; }
        public Likes Likes { get; set; }
        public string Filter { get; set; }
        public string Link { get; set; }
        public string CreatedTime { get; set; }
        public User User { get; set; }
        public Caption Caption { get; set; }
        public string[] Tags { get; set; }
        public bool UserHasLiked { get; set; }
	}
}
