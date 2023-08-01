namespace SingASong.main
{
    public readonly struct AnimalSong
    {
        public readonly string AnimalName;
        public readonly string SongLine;

        public AnimalSong(string animalName, string songLine)
        {
            AnimalName = animalName;
            SongLine = songLine;
        }
    }
}