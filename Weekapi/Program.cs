namespace Weekapi
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var vkApi = new Vk.Api.Api("", "5.60");
		    var tracks = vkApi.Audio.Search("Armin van Buuren");

		    var instagramApi = new Instagram.Api.Api("");
			var selfUser = instagramApi.Users.GetSelfUser();
		}
	}
}
