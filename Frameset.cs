using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PropBank
{
    public class Frameset
    {
        private readonly List<FramesetArgument> _framesetArguments;
        private string _id;

        /**
         * <summary>A constructor of {@link Frameset} class which takes id as input and initializes corresponding attribute</summary>
         *
         * <param name="id"> Id of the frameset</param>
         */
        public Frameset(string id)
        {
            this._id = id;
            this._framesetArguments = new List<FramesetArgument>();
        }

        /**
         * <summary>Another constructor of {@link Frameset} class which takes inputStream as input and reads the frameset</summary>
         *
         * <param name="stream"> inputStream to read frameset</param>
         */
        public Frameset(Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            _id = doc.DocumentElement.Attributes["id"].Value;
            _framesetArguments = new List<FramesetArgument>();
            foreach (XmlNode argumentNode in doc.DocumentElement.ChildNodes)
            {
                string argumentType = argumentNode.Attributes["name"].Value;
                string function = argumentNode.Attributes["function"].Value;
                string definition = argumentNode.InnerText;
                _framesetArguments.Add(new FramesetArgument(argumentType, definition, function));
            }
        }
        
        /**
         * <summary>containsArgument method which checks if there is an {@link Argument} of the given argumentType.</summary>
         *
         * <param name="argumentType"> ArgumentType of the searched {@link Argument}</param>
         * <returns>true if the {@link Argument} with the given argumentType exists, false otherwise.</returns>
         */
        public bool ContainsArgument(ArgumentType argumentType)
        {
            foreach (var framesetArgument in _framesetArguments)
            {
                if (ArgumentTypeStatic.GetArguments(framesetArgument.GetArgumentType()) == argumentType)
                {
                    return true;
                }
            }

            return false;
        }

        /**
         * <summary>The addArgument method takes a type and a definition of a {@link FramesetArgument} as input, then it creates a new FramesetArgument from these inputs and
         * adds it to the framesetArguments {@link ArrayList}.</summary>
         *
         * <param name="type"> Type of the new {@link FramesetArgument}</param>
         * <param name="definition">Definition of the new {@link FramesetArgument}</param>
         */
        public void AddArgument(string type, string definition, string function)
        {
            bool check = false;
            foreach (var a in _framesetArguments)
            {
                if (a.GetArgumentType() == type)
                {
                    a.SetDefinition(definition);
                    check = true;
                    break;
                }
            }

            if (!check)
            {
                FramesetArgument arg = new FramesetArgument(type, definition, function);
                _framesetArguments.Add(arg);
            }
        }

        /**
         * <summary>The deleteArgument method takes a type and a definition of a {@link FramesetArgument} as input, then it searches for the FramesetArgument with these type and
         * definition, and if it finds removes it from the framesetArguments {@link ArrayList}.</summary>
         *
         * <param name="type"> Type of the to be deleted {@link FramesetArgument}</param>
         * <param name="definition">Definition of the to be deleted {@link FramesetArgument}</param>
         */
        public void DeleteArgument(string type, string definition)
        {
            foreach (var a in _framesetArguments)
            {
                if (a.GetArgumentType() == type && a.GetDefinition() == definition)
                {
                    _framesetArguments.Remove(a);
                    break;
                }
            }
        }

        /**
         * <summary>Accessor for framesetArguments.</summary>
         *
         * <returns>framesetArguments.</returns>
         */
        public List<FramesetArgument> GetFramesetArguments()
        {
            return _framesetArguments;
        }

        /**
         * <summary>Accessor for id.</summary>
         *
         * <returns>id.</returns>
         */
        public string GetId()
        {
            return _id;
        }

        /**
         * <summary>Mutator for id.</summary>
         *
         * <param name="id">to set.</param>
         */
        public void SetId(string id)
        {
            this._id = id;
        }

        /**
         * <summary>Saves the {@link Frameset} in an xml file format.</summary>
         */
        public void SaveAsXml()
        {
            StreamWriter outputFile = new StreamWriter(_id + ".xml");
            outputFile.WriteLine("\t<FRAMESET id=\"" + _id + "\">");
            foreach (var framesetArgument in _framesetArguments)
            {
                outputFile.WriteLine("\t\t<ARG name=\"" + framesetArgument.GetArgumentType() + "\" function=\"" +
                                     framesetArgument.GetFunction() + "\">" + framesetArgument.GetDefinition() +
                                     "</ARG>");
            }

            outputFile.WriteLine("\t</FRAMESET>");
            outputFile.Close();
        }
    }
}