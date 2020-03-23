using System.Collections.Generic;

namespace PropBank
{
    public class RoleSet
    {
        private readonly string _id;
        private readonly string _name;
        private readonly List<Role> _roles;

        /**
         * <summary>A constructor of {@link RoleSet} class which takes id and name as inputs and initializes corresponding attributes
         * with these inputs.</summary>
         *
         * <param name="id"> Id of the roleSet</param>
         * <param name="name">Name of the roleSet</param>
         */
        public RoleSet(string id, string name){
            this._id = id;
            this._name = name;
            _roles = new List<Role>();
        }
        
        /**
         * <summary>Accessor for id.</summary>
         *
         * <returns>id.</returns>
         */
        public string GetId(){
            return _id;
        }

        /**
         * <summary>Accessor for name.</summary>
         *
         * <returns>name.</returns>
         */
        public string GetName(){
            return _name;
        }

        /**
         * <summary>The addRole method takes a {@link Role} as input and adds it to the roles {@link ArrayList}.</summary>
         *
         * <param name="role"> Role to be added</param>
         */
        public void AddRole(Role role){
            _roles.Add(role);
        }

        /**
         * <summary>The getRole method returns the role at the given index.</summary>
         *
         * <param name="index"> Index of the role</param>
         * <returns>{@link Role} at the given index.</returns>
         */
        public Role GetRole(int index){
            return _roles[index];
        }

        /**
         * <summary>Finds and returns the role with the given argument number n. For example, if n == 0, the method returns
         * the argument ARG0.</summary>
         * <param name="n">Argument number</param>
         * <returns>The role with the given argument number n.</returns>
         */
        public Role GetRoleWithArgument(string n){
            foreach (var role in _roles)
            {
                if (role.GetN() == n){
                    return role;
                }
            }
            return null;
        }

        /**
         * <summary>The size method returns the size of the roles {@link ArrayList}.</summary>
         *
         * <returns>the size of the roles {@link ArrayList}.</returns>
         */
        public int Size(){
            return _roles.Count;
        }

    }
}