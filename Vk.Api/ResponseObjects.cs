namespace Vk.Api
{
	public class Response<T>
	{
		public int Count { get; set; }
		public T[] Items { get; set; }
	}

	public struct Track
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public string Artist { get; set; }
		public string Title { get; set; }
		public int Duration { get; set; }
		public string Url { get; set; }
		public int LyricsId { get; set; }
		public int GenreId { get; set; }
	}

	public struct Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	
	public struct Message
	{
		public int Id { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
		public int FromId { get; set; }
		public int Date { get; set; }
		public int ReadState { get; set; }
		public int Out { get; set; }
		public string Attachements { get; set; }
	}

	public struct Dialog
	{
		public Message Message { get; set; }
		public int InRead { get; set; }
		public int OutRead { get; set; }
	}

	public struct Friend
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Deactivated { get; set; }
		public int Hidden { get; set; }
	}
}