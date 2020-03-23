using System.Collections.Generic;

namespace PropBank
{
    public class Predicate
    {
        private readonly string _lemma;
        private readonly List<RoleSet> _roleSets;
        
        /**
         * <summary>A constructor of {@link Predicate} class which takes lemma as input and initializes lemma with this input.
         * The constructor also initializes the roleSets array.</summary>
         *
         * <param name="lemma"> Lemma of the predicate</param>
         */
        public Predicate(string lemma){
            this._lemma = lemma;
            _roleSets = new List<RoleSet>();
        }
        
        /**
         * <summary>Accessor for lemma.</summary>
         *
         * <returns>lemma.</returns>
         */
        public string GetLemma(){
            return _lemma;
        }

        /**
         * <summary>The addRoleSet method takes a {@link RoleSet} as input and adds it to the roleSets {@link ArrayList}.</summary>
         *
         * <param name="roleSet"> RoleSet to be added</param>
         */
        public void AddRoleSet(RoleSet roleSet){
            _roleSets.Add(roleSet);
        }

        /**
         * <summary>The size method returns the size of the roleSets {@link ArrayList}.</summary>
         *
         * <returns>the size of the roleSets {@link ArrayList}.</returns>
         */
        public int Size(){
            return _roleSets.Count;
        }

        /**
         * <summary>The getRoleSet method returns the roleSet at the given index.</summary>
         *
         * <param name="index"> Index of the roleSet</param>
         * <returns>{@link RoleSet} at the given index.</returns>
         */
        public RoleSet GetRoleSet(int index){
            return _roleSets[index];
        }

        /**
         * <summary>Another getRoleSet method which returns the roleSet with the given roleSet id.</summary>
         *
         * <param name="roleId"> Id of the searched roleSet</param>
         * <returns>{@link RoleSet} which has the given id.</returns>
         */
        public RoleSet GetRoleSet(string roleId){
            foreach (var roleSet in _roleSets)
            {
                if (roleSet.GetId() == roleId){
                    return roleSet;
                }
            }
            return null;
        }

    }
}