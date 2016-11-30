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
}