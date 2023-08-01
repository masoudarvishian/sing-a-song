using System;
using System.Collections.Generic;
using System.Linq;

namespace SingASong.main
{
    // Pure functions
    // Recursion
    // Referential transparency
    // Functions are First-Class and can be Higher-Order
    // Variables are Immutable

    public readonly struct _AnimalSong
    {
        public readonly string AnimalName;
        public readonly string SongLine;

        public AnimalSong(string animalName, string songLine)
        {
            AnimalName = animalName;
            SongLine = songLine;
        }
    }

    public class _Program
    {
        private static void GenerateSong(Queue<AnimalSong> queue, Queue<AnimalSong> prevAnimalQueue = null)
        {
            if (queue.Count == 0)
                return;

            var animal = queue.Dequeue();

            if (prevAnimalQueue == null)
                prevAnimalQueue = new Queue<AnimalSong>();

            string song;

            if (prevAnimalQueue.Count == 0)
            {
                song = $"There was an old lady who swallowed a {animal.AnimalName}\n{animal.SongLine}";
            }
            else if (prevAnimalQueue.Count > 0 && queue.Count == 0)
            {
                song = $"There was an old lady who swallowed a {animal.AnimalName}...\n...{animal.SongLine}";
            }
            else
            {
                song = $"There was an old lady who swallowed a {animal.AnimalName}\n{animal.SongLine}\n";
                song = GenerateSubSong(new Queue<AnimalSong>(prevAnimalQueue.Reverse()), song, animal.AnimalName);
                song += $"{prevAnimalQueue.First().SongLine}";
            }

            Console.WriteLine(song + "\n");
            
            prevAnimalQueue.Enqueue(animal);
            
            GenerateSong(queue, prevAnimalQueue);
        }

        private static string GenerateSubSong(Queue<AnimalSong> prevAnimalQueue, string song, string eaterName)
        {
            if (prevAnimalQueue.Count > 0)
            {
                var prevAnimal = prevAnimalQueue.Dequeue();
                song += $"She swallowed the {eaterName} to catch the {prevAnimal.AnimalName};\n";
                eaterName = prevAnimal.AnimalName;
                song = GenerateSubSong(prevAnimalQueue, song, eaterName);
            }

            return song;
        }
        
        static void _Main(string[] args)
        {
            var animalList = new Queue<AnimalSong>();

            animalList.Enqueue(new AnimalSong("fly", "I don't know why she swallowed a fly - perhaps she'll die!"));
            animalList.Enqueue(new AnimalSong("spider", "That wriggled and wiggled and tickled inside her."));
            animalList.Enqueue(new AnimalSong("bird", "How absurd to swallow a bird."));
            animalList.Enqueue(new AnimalSong("cat", "Fancy that to swallow a cat!"));
            animalList.Enqueue(new AnimalSong("dog", "What a hog, to swallow a dog!"));
            animalList.Enqueue(new AnimalSong("cow", "I don't know how she swallowed a cow!"));
            animalList.Enqueue(new AnimalSong("horse", "She's dead, of course!"));

            GenerateSong(new Queue<AnimalSong>(animalList));

            var song = @"There was an old lady who swallowed a fly.
            I don't know why she swallowed a fly - perhaps she'll die!

            There was an old lady who swallowed a spider;
            That wriggled and wiggled and tickled inside her.
            She swallowed the spider to catch the fly;
            I don't know why she swallowed a fly - perhaps she'll die!

            There was an old lady who swallowed a bird;
            How absurd to swallow a bird.
            She swallowed the bird to catch the spider,
            She swallowed the spider to catch the fly;
            I don't know why she swallowed a fly - perhaps she'll die!

            There was an old lady who swallowed a cat;
            Fancy that to swallow a cat!
            She swallowed the cat to catch the bird,
            She swallowed the bird to catch the spider,
            She swallowed the spider to catch the fly;
            I don't know why she swallowed a fly - perhaps she'll die!

            There was an old lady who swallowed a dog;
            What a hog, to swallow a dog!
            She swallowed the dog to catch the cat,
            She swallowed the cat to catch the bird,
            She swallowed the bird to catch the spider,
            She swallowed the spider to catch the fly;
            I don't know why she swallowed a fly - perhaps she'll die!

            There was an old lady who swallowed a cow;
            I don't know how she swallowed a cow!
            She swallowed the cow to catch the dog,
            She swallowed the dog to catch the cat,
            She swallowed the cat to catch the bird,
            She swallowed the bird to catch the spider,
            She swallowed the spider to catch the fly;
            I don't know why she swallowed a fly - perhaps she'll die!

            There was an old lady who swallowed a horse...
            ...She's dead, of course!";

            //Console.WriteLine(theSong);
        }
    }
}