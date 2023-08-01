using System.Collections.Generic;
using NUnit.Framework;
using SingASong.main;

namespace SingASong
{
    public class SongGeneratorShould
    {
        private Queue<AnimalSong> _animalList;

        [SetUp]
        public void Setup()
        {
            _animalList = new Queue<AnimalSong>();

            _animalList.Enqueue(new AnimalSong("fly", "I don't know why she swallowed a fly - perhaps she'll die!"));
            _animalList.Enqueue(new AnimalSong("spider", "That wriggled and wiggled and tickled inside her."));
            _animalList.Enqueue(new AnimalSong("bird", "How absurd to swallow a bird."));
            _animalList.Enqueue(new AnimalSong("cat", "Fancy that to swallow a cat!"));
            _animalList.Enqueue(new AnimalSong("dog", "What a hog, to swallow a dog!"));
            _animalList.Enqueue(new AnimalSong("cow", "I don't know how she swallowed a cow!"));
            _animalList.Enqueue(new AnimalSong("horse", "She's dead, of course!"));
        }

        [Test]
        public void GenerateAnimalSongWhenOnlyOneExist()
        {
            GivenAnAnimalListWith(new AnimalSong("fly", "I don't know why she swallowed a fly - perhaps she'll die!"));
            
            var song = WhenGenerateSong();
            
            var expectedSong =
                "There was an old lady who swallowed a fly\nI don't know why she swallowed a fly - perhaps she'll die!";
            ThenGeneratedSongShouldBe(song, expectedSong);
        }

        [Test]
        public void GenerateAnimalSongWhenTwoExist()
        {
            GivenAnAnimalListWith(new AnimalSong("fly", "I don't know why she swallowed a fly - perhaps she'll die!"),
                new AnimalSong("spider", "That wriggled and wiggled and tickled inside her."));

            var song = WhenGenerateSong();

            var expectedSong = @"There was an old lady who swallowed a fly
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a spider...
...That wriggled and wiggled and tickled inside her.";
            ThenGeneratedSongShouldBe(song, expectedSong);
        }

        [Test]
        public void GenerateTheWholeSong()
        {
            var song = WhenGenerateSong();
            var expectedSong = @"There was an old lady who swallowed a fly
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a spider
That wriggled and wiggled and tickled inside her.
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a bird
How absurd to swallow a bird.
She swallowed the bird to catch the spider;
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a cat
Fancy that to swallow a cat!
She swallowed the cat to catch the bird;
She swallowed the bird to catch the spider;
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a dog
What a hog, to swallow a dog!
She swallowed the dog to catch the cat;
She swallowed the cat to catch the bird;
She swallowed the bird to catch the spider;
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a cow
I don't know how she swallowed a cow!
She swallowed the cow to catch the dog;
She swallowed the dog to catch the cat;
She swallowed the cat to catch the bird;
She swallowed the bird to catch the spider;
She swallowed the spider to catch the fly;
I don't know why she swallowed a fly - perhaps she'll die!

There was an old lady who swallowed a horse...
...She's dead, of course!";
            ThenGeneratedSongShouldBe(song, expectedSong);
        }

        private void GivenAnAnimalListWith(params AnimalSong[] songList)
        {
            _animalList = new Queue<AnimalSong>();
            foreach (var song in songList)
                _animalList.Enqueue(song);
        }

        private string WhenGenerateSong() => SongGenerator.Generate(_animalList, new Queue<AnimalSong>());

        private void ThenGeneratedSongShouldBe(string song, string expectedSong)
        {
            Assert.AreEqual(expectedSong, song);
        }
    }
}