using System.Collections.Generic;
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
            var fileListStream = assembly.GetManifestResourceStream("PropBank.english-propbank.xml");
            var doc = new XmlDocument();
            doc.Load(fileListStream);
            foreach (XmlNode frameSetNode in doc.DocumentElement.ChildNodes)
            {
                foreach (XmlNode predicateNode in frameSetNode.ChildNodes)
                {
                    var lemma = predicateNode.Attributes["lemma"].Value;
                    var newPredicate = new Predicate(lemma);
                    foreach (XmlNode roleSetNode in predicateNode.ChildNodes)
                    {
                        var id = roleSetNode.Attributes["id"].Value;
                        var name = roleSetNode.Attributes["name"].Value;
                        var newRoleSet = new RoleSet(id, name);
                        foreach (XmlNode rolesNode in roleSetNode.ChildNodes)
                        {
                            foreach (XmlNode roleNode in rolesNode.ChildNodes)
                            {
                                var description = roleNode.Attributes["descr"].Value;
                                var f = roleNode.Attributes["f"].Value;
                                var n = roleNode.Attributes["n"].Value;
                                var newRole = new Role(description, f, n);
                                newRoleSet.AddRole(newRole);
                            }
                        }
                        newPredicate.AddRoleSet(newRoleSet);
                    }
                    _list.Add(newPredicate.GetLemma(), newPredicate);
                }
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