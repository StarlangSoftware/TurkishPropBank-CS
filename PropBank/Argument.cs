using System;

namespace PropBank
{
    public class Argument
    {
        private readonly string _argumentType;
        private readonly string _id;

        /**
         * <summary>A constructor of {@link Argument} class which takes argument string which is in the form of argumentType$id
         * and parses this string into argumentType and id. If the argument string does not contain '$' then the
         * constructor return a NONE type argument.</summary>
         *
         * <param name="argument"> Argument string containing the argumentType and id</param>
         */
        public Argument(string argument)
        {
            if (argument.Contains("$"))
            {
                _argumentType = argument.Substring(0, argument.IndexOf("$", StringComparison.Ordinal));
                _id = argument.Substring(argument.IndexOf("$", StringComparison.Ordinal) + 1);
            }
            else
            {
                _argumentType = "NONE";
            }
        }

        /**
         * <summary>Another constructor of {@link Argument} class which takes argumentType and id as inputs and initializes corresponding attributes</summary>
         *
         * <param name="argumentType"> Type of the argument</param>
         * <param name="id"> Id of the argument</param>
         */
        public Argument(string argumentType, string id)
        {
            this._argumentType = argumentType;
            this._id = id;
        }

        /**
         * <summary>Accessor for argumentType.</summary>
         *
         * <returns>argumentType.</returns>
         */
        public string GetArgumentType()
        {
            return _argumentType;
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
         * <summary>toString converts an {@link Argument} to a string. If the argumentType is "NONE" returns only "NONE", otherwise
         * it returns argument string which is in the form of argumentType$id</summary>
         *
         * <returns>string form of argument</returns>
         */
        public override string ToString()
        {
            if (_argumentType == "NONE")
            {
                return _argumentType;
            }

            return _argumentType + "$" + _id;
        }
    }
}