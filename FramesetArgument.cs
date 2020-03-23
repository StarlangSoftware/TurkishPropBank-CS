namespace PropBank
{
    public class FramesetArgument
    {
        private readonly string _argumentType;
        private string _function;
        private string _definition;

        /**
         * <summary>A constructor of {@link FramesetArgument} class which takes argumentType and definition as input and initializes corresponding attributes</summary>
         *
         * <param name="argumentType"> ArgumentType of the frameset argument</param>
         * <param name="definition"> Definition of the frameset argument</param>
         * <param name="function"> Function of the frameset argument</param>
         */
        public FramesetArgument(string argumentType, string definition, string function) {
            this._argumentType = argumentType;
            this._definition = definition;
            this._function = function;
        }

        /**
         * <summary>Accessor for argumentType.</summary>
         *
         * <returns>argumentType.</returns>
         */
        public string GetArgumentType() {
            return _argumentType;
        }

        /**
         * <summary>Accessor for function.</summary>
         *
         * <returns>function.</returns>
         */
        public string GetFunction() {
            return _function;
        }

        /**
         * <summary>Accessor for definition.</summary>
         *
         * <returns>definition.</returns>
         */
        public string GetDefinition() {
            return _definition;
        }

        /**
         * <summary>Mutator for definition.</summary>
         *
         * <param name="definition">to set.</param>
         */
        public void SetDefinition(string definition) {
            this._definition = definition;
        }

        /**
         * <summary>Mutator for function.</summary>
         *
         * <param name="function">to set.</param>
         */
        public void SetFunction(string function) {
            this._function = function;
        }

        /**
         * <summary>toString converts an {@link FramesetArgument} to a string. It returns argument string which is in the form of
         * argumentType:definition</summary>
         *
         * <returns>string form of frameset argument</returns>
         */
        public override string ToString(){
            return _argumentType + ":" + _definition;
        }

    }
}