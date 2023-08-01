using System;
using System.Collections.Generic;

namespace SingASong.main
{
    public static class Program
    {
        private static void Main()
        {
            var animalList = new Queue<AnimalSong>();

            animalList.Enqueue(new AnimalSong("fly", "I don't know why she swallowed a fly - perhaps she'll die!")); 
            animalList.Enqueue(new AnimalSong("spider", "That wriggled and wiggled and tickled inside her."));
            animalList.Enqueue(new AnimalSong("bird", "How absurd to swallow a bird."));
            animalList.Enqueue(new AnimalSong("cat", "Fancy that to swallow a cat!"));
            animalList.Enqueue(new AnimalSong("dog", "What a hog, to swallow a dog!"));
            animalList.Enqueue(new AnimalSong("cow", "I don't know how she swallowed a cow!"));
            animalList.Enqueue(new AnimalSong("horse", "She's dead, of course!"));

            Console.WriteLine(SongGenerator.Generate(new Queue<AnimalSong>(animalList), new Queue<AnimalSong>()));
        }
    }
}