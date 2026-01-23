using Newtonsoft.Json;

public class ResultSpecialOfferDto
{
    [JsonProperty("specialOfferId")]
    public string SpecialOfferId { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("subtitle")]
    public string Subtitle { get; set; }

    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; }
}
