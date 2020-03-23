namespace PropBank
{
    public class Role
    {
        private readonly string _description;
        private readonly string _f;
        private readonly string _n;

        /**
         * <summary>A constructor of {@link Role} class which takes description, f, and n as inputs and initializes corresponding with these inputs.</summary>
         *
         * <param name="description"> Description of the role</param>
         * <param name="f"> Argument Type of the role</param>
         * <param name="n"> Number of the role</param>
         */
        public Role(string description, string f, string n){
            this._description = description;
            this._f = f;
            this._n = n;
        }
        
        /**
         * <summary>Accessor for description.</summary>
         *
         * <returns>description.</returns>
         */
        public string GetDescription(){
            return _description;
        }
 
        /**
         * <summary>Accessor for f.</summary>
         *
         * <returns>f.</returns>
         */
        public string GetF(){
            return _f;
        }
  
        /**
         * <summary>Accessor for n.</summary>
         *
         * <returns>n.</returns>
         */
        public string GetN(){
            return _n;
        }
        
        /**
         * <summary>Constructs and returns the argument type for this role.</summary>
         *
         * <returns>Argument type for this role.</returns>
         */
        public ArgumentType GetArgumentType(){
            return ArgumentTypeStatic.GetArguments("ARG" + _f.ToUpper());
        }
        
    }
}