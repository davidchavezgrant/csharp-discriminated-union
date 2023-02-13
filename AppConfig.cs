namespace Hackathon;

internal sealed class AppConfig
{
	public Urls Urls { get; set; } 
}

internal sealed class Urls
{
	public string ApiRelative  { get; set; }
	public string BaseAbsolute { get; set; }
	public string AdminRelative { get; set; }
}