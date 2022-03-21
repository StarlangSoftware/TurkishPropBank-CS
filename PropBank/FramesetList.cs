using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PropBank
{
    public class FramesetList
    {
        private readonly List<Frameset> _frames;

        /**
         * <summary>A constructor of {@link FramesetList} class which reads all frameset files inside the files.txt file. For each
         * filename inside that file, the constructor creates a Frameset and puts in inside the frames {@link ArrayList}.</summary>
         */
        public FramesetList()
        {
            _frames = new List<Frameset>();
            var assembly = typeof(FramesetList).Assembly;
            var fileListStream = assembly.GetManifestResourceStream("PropBank.turkish-propbank.xml");
            var doc = new XmlDocument();
            doc.Load(fileListStream);
            foreach (XmlNode frameSetNode in doc.DocumentElement.ChildNodes)
            {
                _frames.Add(new Frameset(frameSetNode));
            }
        }

        /**
         * <summary>frameExists method checks if there is a {@link Frameset} with the given synSet id.</summary>
         *
         * <param name="synSetId"> Id of the searched {@link Frameset}</param>
         * <returns>true if the {@link Frameset} with the given id exists, false otherwise.</returns>
         */
        public bool FrameExists(string synSetId)
        {
            foreach (var f in _frames)
            {
                if (f.GetId() == synSetId)
                {
                    return true;
                }
            }

            return false;
        }

        /**
         * <summary>getFrameSet method returns the {@link Frameset} with the given synSet id.</summary>
         *
         * <param name="synSetId"> Id of the searched {@link Frameset}</param>
         * <returns>{@link Frameset} which has the given id.</returns>
         */
        public Frameset GetFrameSet(string synSetId)
        {
            foreach (var f in _frames)
            {
                if (f.GetId() == synSetId)
                {
                    return f;
                }
            }

            return null;
        }

        /**
         * <summary>The addFrameset method takes a {@link Frameset} as input and adds it to the frames {@link ArrayList}.</summary>
         *
         * <param name="frameset"> Frameset to be added</param>
         */
        public void AddFrameset(Frameset frameset)
        {
            _frames.Add(frameset);
        }

        /**
         * <summary>The getFrameSet method returns the frameset at the given index.</summary>
         *
         * <param name="index"> Index of the frameset</param>
         * <returns>{@link Frameset} at the given index.</returns>
         */
        public Frameset GetFrameSet(int index)
        {
            return _frames[index];
        }

        /**
         * <summary>The size method returns the size of the frames {@link ArrayList}.</summary>
         *
         * <returns>the size of the frames {@link ArrayList}.</returns>
         */
        public int Size()
        {
            return _frames.Count;
        }
    }
}