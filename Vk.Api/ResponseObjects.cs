using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vk.Api
{
	public class Response<T>
	{
		public int Count { get; set; }
		public T[] Items { get; set; }
	}

	public class Audio
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public string Artist { get; set; }
		public string Title { get; set; }
		public int Duration { get; set; }
		public string Url { get; set; }
		public int LyricsId { get; set; }
		public int GenreId { get; set; }
		public bool IsHq { get; set; }	// non-documented
	}

	public struct Group
	{
		public int Id { get; set; }
		public string Name { get; set; }
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
	
	public class Sizes
	{
		public string Src { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public string Type { get; set; }
	}

	public class Photo
	{
		public int Id { get; set; }
		public int AlbumId { get; set; }
		public int OwnerId { get; set; }
		public int UserId { get; set; }
		public string Text { get; set; }
		public int Date { get; set; }
		public Sizes[] Sizes { get; set; }
		[JsonProperty("photo_75")]
		public string Photo75 { get; set; }
		[JsonProperty("photo_130")]
		public string Photo130 { get; set; }
		[JsonProperty("photo_604")]
		public string Photo604 { get; set; }
		[JsonProperty("photo_807")]
		public string Photo807 { get; set; }
		[JsonProperty("photo_1280")]
		public string Photo1280 { get; set; }
		[JsonProperty("photo_2560")]
		public string Photo2560 { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}

	public class Video
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Duration { get; set; }
		[JsonProperty("photo_130")]
		public string Photo130 { get; set; }
		[JsonProperty("photo_320")]
		public string Photo320 { get; set; }
		[JsonProperty("photo_640")]
		public string Photo640 { get; set; }
		[JsonProperty("photo_800")]
		public string Photo800 { get; set; }
		public int Date { get; set; }
		public int AddingDate { get; set; }
		public int Views { get; set; }
		public int Comments { get; set; }
		public string Player { get; set; }
		public string AccessKey { get; set; }
		public int Processing { get; set; }
		public int Live { get; set; }
		public string Platform { get; set; }	// non-documented
		public int CanAdd { get; set; }			// non-documented
		public int CanEdit { get; set; }		// non-documented
	}
	
	public class Page
	{
		public int Id { get; set; }
		public int GroupId { get; set; }
		public int CreatorId { get; set; }
		public string Title { get; set; }
		public int CurrenUserCanEdit { get; set; }
		public int CurrenUserCanEditAccess { get; set; }
		public int WhoCanView { get; set; }
		public int WhoCanEdit { get; set; }
		public int Edited { get; set; }
		public int Created { get; set; }
		public int EditorId { get; set; }
		public int Views { get; set; }
		public string Parent { get; set; }
		public string Parent2 { get; set; }
		public string Source { get; set; }
		public string Html { get; set; }
		public string ViewUrl { get; set; }
	}

	public class Gift
	{
		public int Id { get; set; }
		[JsonProperty("thumb_256")]
		public string Thumb256 { get; set; }
		[JsonProperty("thumb_96")]
		public string Thumb96 { get; set; }
		[JsonProperty("thumb_48")]
		public string Thumb48 { get; set; }
	}

	public interface IWallAttachment
	{
	}

	public interface IMessageAttachment
	{
	}
	
	// https://vk.com/dev/attachments_w
	public class PhotoWallAttachment : Photo, IWallAttachment
	{
		public int PostId { get; set; }
		public string AccessKey { get; set; }
	}
	
	public class VideoWallAttachment : Video, IWallAttachment
	{
	}
	
	public class AudioWallAttachment : Audio, IWallAttachment
	{
		public string AccessKey { get; set; }
	}
	
	public class DocWallAttachment : Document, IWallAttachment
	{
		public string AccessKey { get; set; }
	}
	
	public class PageWallAttachment : Page, IWallAttachment
	{
		public string AccessKey { get; set; }
	}
	
	public class PollWallAttachment : IWallAttachment
	{
		public string AccessKey { get; set; }
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public int Created { get; set; }
		public string Question { get; set; }
		public int Votest { get; set; }
		public int AnswerId { get; set; }
		public PollAnswer[] Answers { get; set; }
	}

	public class PollAnswer
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int Votes { get; set; }
		public double Rate { get; set; }
	}

	public class LinkWallAttachment : IWallAttachment
	{
		public string Url { get; set; }
		public string Title { get; set; }
		public string Caption { get; set; }
		public string Description { get; set; }
		public Photo Photo { get; set; }
		public bool IsExternal { get; set; }
	}
	
	// https://vk.com/dev/attachments_m
	public class WallMessageAttachment : IMessageAttachment
	{
		public int Id { get; set; }
		public int ToId { get; set; }
		public int FromId { get; set; }
		public int Date { get; set; }
		public string Text { get; set; }
		public string PostType { get; set; }	// non-documented
		public int MarkedAsAds { get; set; }	// non-documented
		[JsonConverter(typeof(WallAttachmentConverter))]
		public IWallAttachment[] Attachments { get; set; }
		public PostSource PostSource { get; set; }
		public Comments Comments { get; set; }
		public Likes Likes { get; set; }
		public Reposts Reposts { get; set; }
		public Views Views { get; set; }
		// geo
		// signer_id
		// copy_owner_id
		// copy_post_id
		// copy_text
	}

	public class StickerMessageAttachment : IMessageAttachment
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		[JsonProperty("photo_64")]
		public string Photo64 { get; set; }
		[JsonProperty("photo_128")]
		public string Photo128 { get; set; }
		[JsonProperty("photo_256")]
		public string Photo256 { get; set; }
		[JsonProperty("photo_352")]
		public string Photo352 { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}

	public class AudioMessageAttachment : Audio, IMessageAttachment
	{
	}

	public class PhotoMessageAttachment : Photo, IMessageAttachment
	{
        public string AccessKey { get; set; }
    }

	public class DocumentMessageAttachment : Document, IMessageAttachment
	{
		public string AccessKey { get; set; }
	}

	public class LinkMessageAttachment : IMessageAttachment
	{
		public string Url { get; set; }
		public string Title { get; set; }
		public string Caption { get; set; }
		public string Description { get; set; }
		public Photo Photo { get; set; }
		public bool IsExternal { get; set; }
	}

	public class VideoMessageAttachment : Video, IMessageAttachment
	{
	}
	
	public class GiftMessageAttachment : Gift, IMessageAttachment
	{
	}

	public class PostSource
	{
		public string Type { get; set; }
	}

	public class Comments
	{
		public int Count { get; set; }
		public int CanPost { get; set; }
	}

	public class Likes
	{
		public int Count { get; set; }
		public int UserLikes { get; set; }
		public int CanLike { get; set; }
		public int CanPublish { get; set; }
	}

	public class Reposts
	{
		public int Count { get; set; }
		public int UserReposted { get; set; }
	}

	public class Views
	{
		public int Count { get; set; }
	}
	
	public class Message
	{
		public int Id { get; set; }
		public string Body { get; set; }
		public int UserId { get; set; }
		public int FromId { get; set; }
		public int Date { get; set; }
		public int ReadState { get; set; }
		public int Out { get; set; }
		[JsonConverter(typeof(MessageAttachmentConverter))]
		public IMessageAttachment[] Attachments { get; set; }
	}

	public class Document
	{
		public int Id { get; set; }
		public int OwnerId { get; set; }
		public string Title { get; set; }
		public int Size { get; set; }
		public string Ext { get; set; }
		public string Url { get; set; }
		public int Date { get; set; }
		public int Type { get; set; }
        // preview
	}
}