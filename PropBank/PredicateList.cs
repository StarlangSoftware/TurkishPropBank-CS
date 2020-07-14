using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PropBank
{
    public class PredicateList
    {
        private Dictionary<string, Predicate> _list;

        /**
         * <summary>The size method returns the number of predicates inside the list.</summary>
         *
         * <returns>the size of the list {@link HashMap}.</returns>
         */
        public int Size()
        {
            return _list.Count;
        }

        /**
         * <summary>A constructor of {@link PredicateList} class which reads all predicate files inside the 'Frames' folder. For each
         * file inside that folder, the constructor creates a Predicate and puts in inside the list {@link HashMap}.</summary>
         */
        public PredicateList()
        {
            _list = new Dictionary<string, Predicate>();
            var assembly = typeof(PredicateList).Assembly;
            var fileListStream = assembly.GetManifestResourceStream("PropBank.files-english.txt");
            var streamReader = new StreamReader(fileListStream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                var stream = assembly.GetManifestResourceStream("PropBank.Frames_English." + line);
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);
                foreach (XmlNode predicateNode in doc.DocumentElement.ChildNodes)
                {
                    string lemma = predicateNode.Attributes["lemma"].Value;
                    Predicate newPredicate = new Predicate(lemma);
                    foreach (XmlNode roleSetNode in predicateNode.ChildNodes)
                    {
                        string id = roleSetNode.Attributes["id"].Value;
                        string name = roleSetNode.Attributes["name"].Value;
                        RoleSet newRoleSet = new RoleSet(id, name);
                        foreach (XmlNode rolesNode in roleSetNode.ChildNodes)
                        {
                            foreach (XmlNode roleNode in rolesNode.ChildNodes)
                            {
                                string description = roleNode.Attributes["descr"].Value;
                                string f = roleNode.Attributes["f"].Value;
                                string n = roleNode.Attributes["n"].Value;
                                Role newRole = new Role(description, f, n);
                                newRoleSet.AddRole(newRole);
                            }
                        }

                        newPredicate.AddRoleSet(newRoleSet);
                    }

                    _list.Add(newPredicate.GetLemma(), newPredicate);
                }

                line = streamReader.ReadLine();
            }
        }

        /**
         * <summary>getPredicate method returns the {@link Predicate} with the given lemma.</summary>
         *
         * <param name="lemma"> Lemma of the searched predicate</param>
         * <returns>{@link Predicate} which has the given lemma.</returns>
         */
        public Predicate GetPredicate(string lemma)
        {
            return _list[lemma];
        }

        /**
         * <summary>The method returns all lemma in the predicate list.</summary>
         * <returns>All lemma in the predicate list.</returns>
         */
        public Dictionary<string, Predicate>.KeyCollection GetLemmaList()
        {
            return _list.Keys;
        }
    }
}