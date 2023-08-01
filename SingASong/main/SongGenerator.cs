using System.Collections.Generic;
using System.Linq;

namespace SingASong.main
{
    public static class SongGenerator
    {
        public static string Generate(Queue<AnimalSong> queue, Queue<AnimalSong> prevAnimalQueue, string song = "")
        {
            return QueueIsEmpty(queue) 
                ? song.Trim() 
                : Generate(
                new Queue<AnimalSong>(queue.Skip(1)), 
                Enqueue(new Queue<AnimalSong>(prevAnimalQueue), queue.Peek()), 
                song + GenerateCurrentSong(new Queue<AnimalSong>(queue.Skip(1)),
                    new Queue<AnimalSong>(prevAnimalQueue), queue.Peek()));
        }
        
        private static string GenerateCurrentSong(Queue<AnimalSong> queue, Queue<AnimalSong> prevAnimalQueue, AnimalSong animal) =>
            (QueueIsEmpty(prevAnimalQueue) ? GetSongHeader(animal)
                : QueueIsNotEmpty(prevAnimalQueue) && QueueIsEmpty(queue) ? GetSongFooter(animal)
                : GetSongBody(new Queue<AnimalSong>(prevAnimalQueue), animal)) + "\n\n";

        private static string GetSongBody(Queue<AnimalSong> prevAnimalQueue, AnimalSong animal) =>
            GenerateSubSong(new Queue<AnimalSong>(prevAnimalQueue.Reverse()),
                $"{GetSongHeader(animal)}\n", animal.AnimalName) + $"{prevAnimalQueue.First().SongLine}";

        private static string GetSongFooter(AnimalSong animal) => $"There was an old lady who swallowed a {animal.AnimalName}...\n...{animal.SongLine}";

        private static string GetSongHeader(AnimalSong animal) => $"There was an old lady who swallowed a {animal.AnimalName}\n{animal.SongLine}";
        
        private static string GenerateSubSong(Queue<AnimalSong> prevAnimalQueue, string song, string eaterName)
        {
            return QueueIsEmpty(prevAnimalQueue) ? song 
                : GenerateSubSong(new Queue<AnimalSong>(prevAnimalQueue.Skip(1)),
                song + GetSongBodyMidLines(eaterName, prevAnimalQueue.Peek().AnimalName),
                prevAnimalQueue.Peek().AnimalName);
        }

        private static string GetSongBodyMidLines(string eaterName, string animalName) => $"She swallowed the {eaterName} to catch the {animalName};\n";

        private static bool QueueIsEmpty(Queue<AnimalSong> queue) => queue.Count == 0;

        private static bool QueueIsNotEmpty(Queue<AnimalSong> queue) => queue.Count > 0;
        
        private static Queue<AnimalSong> Enqueue(Queue<AnimalSong> queue, AnimalSong animal)
        {
            queue.Enqueue(animal);
            return queue;
        }
    }
}