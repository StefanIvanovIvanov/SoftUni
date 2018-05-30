using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {   
            Music music=new Music("musicArtist", "musicAlbum", 42, 42);
            File file=new File("fileName", 42, 42);

            StreamProgressInfo musicStreamingInfo=new StreamProgressInfo(music);
            StreamProgressInfo fileStreamingInfo = new StreamProgressInfo(file);
            musicStreamingInfo.CalculateCurrentPercent();
            fileStreamingInfo.CalculateCurrentPercent();
        }
    }
}
