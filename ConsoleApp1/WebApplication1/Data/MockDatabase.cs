using WebApplication1.Models.Entities;

namespace WebApplication1.Data
{
    public static class MockDatabase
    {
        public static List<Playlist> Playlists { get; set; } = new List<Playlist>
        {
            new Playlist
            {
                Title = "Chill OPM Acoustic Jam",
                CreatorName = "System",
                Videos = new List<VideoItem>
                {
                    new VideoItem { YouTubeUrl = "https://youtu.be/...", TrackNote = "Classic Eraserheads cover" },
                    new VideoItem { YouTubeUrl = "https://youtu.be/...", TrackNote = "Great vocal harmony" }
                }
            }
        };
    }
}