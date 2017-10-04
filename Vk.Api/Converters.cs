using System;
using System.Collections.Generic;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vk.Api
{
    public class MessageAttachmentConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(IMessageAttachment));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jsonSerializer = new JsonSerializer { ContractResolver = new ContractResolver() };
			
			var token = JToken.Load(reader);
			if (token.Type == JTokenType.Array)
			{
				var result = new List<IMessageAttachment>();
				
				foreach (var item in token)
				{
					var type = item["type"].Value<string>();
					if (type == "wall")
					{
						var wall = item["wall"].ToObject<WallMessageAttachment>(jsonSerializer);
						result.Add(wall);
					}
					else if (type == "sticker")
					{
						var sticker = item["sticker"].ToObject<StickerMessageAttachment>(jsonSerializer);
						result.Add(sticker);
					}
					else if (type == "audio")
					{
						var audio = item["audio"].ToObject<AudioMessageAttachment>(jsonSerializer);
						result.Add(audio);
					}
					else if (type == "photo")
					{
						var photo = item["photo"].ToObject<PhotoMessageAttachment>(jsonSerializer);
						result.Add(photo);
					}
					else if (type == "doc")
					{
						var doc = item["doc"].ToObject<DocumentMessageAttachment>(jsonSerializer);
						result.Add(doc);
					}
					else if (type == "link")
					{
						var link = item["link"].ToObject<LinkMessageAttachment>(jsonSerializer);
						result.Add(link);
					}
					else if (type == "video")
					{
						var video = item["video"].ToObject<VideoMessageAttachment>(jsonSerializer);
						result.Add(video);
					}
					else if (type == "gift")
					{
						var gift = item["gift"].ToObject<GiftMessageAttachment>(jsonSerializer);
						result.Add(gift);
					}
					else
						throw new NotSupportedException($"Type {type} is not supported.");
				}

				return result.ToArray();
			}
			
			return new NotSupportedException($"Not supported token type.");
		}

		public override bool CanWrite => false;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	
	public class WallAttachmentConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(IWallAttachment));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jsonSerializer = new JsonSerializer { ContractResolver = new ContractResolver() };
			
			var token = JToken.Load(reader);
			if (token.Type == JTokenType.Array)
			{
				var result = new List<IWallAttachment>();

				foreach (var item in token)
				{
					var type = item["type"].Value<string>();
					if (type == "photo")
					{
						var photo = item["photo"].ToObject<PhotoWallAttachment>(jsonSerializer);
						result.Add(photo);
					}
					else if (type == "link")
					{
						var link = item["link"].ToObject<LinkWallAttachment>(jsonSerializer);
						result.Add(link);
					}
					else if (type == "video")
					{
						var video = item["video"].ToObject<VideoWallAttachment>(jsonSerializer);
						result.Add(video);
					}
					else if (type == "audio")
					{
						var audio = item["audio"].ToObject<AudioWallAttachment>(jsonSerializer);
						result.Add(audio);
					}
					else if (type == "poll")
					{
						var poll = item["poll"].ToObject<PollWallAttachment>(jsonSerializer);
						result.Add(poll);
					}
					else if (type == "doc")
					{
						var doc = item["doc"].ToObject<DocWallAttachment>(jsonSerializer);
						result.Add(doc);
					}
					else if (type == "page")
					{
						var page = item["page"].ToObject<PageWallAttachment>(jsonSerializer);
						result.Add(page);
					}
					else
						throw new NotSupportedException($"Type {type} is not supported.");
				}

				return result.ToArray();
			}
			
			return new NotSupportedException("Not supported token type.");
		}

		public override bool CanWrite => false;

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}