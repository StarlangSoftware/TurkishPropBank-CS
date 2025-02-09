using System.Collections.Generic;

namespace PropBank;

public class ArgumentList
{
    private List<Argument> _arguments;

    /**
     * <summary>Constructor of argument list from a string. The arguments for a word is a concatenated list of arguments
     * separated via '#' character.</summary>
     * <param name="argumentList"> string consisting of arguments separated with '#' character.</param>
     */
    public ArgumentList(string argumentList)
    {
        _arguments = new List<Argument>();
        var items = argumentList.Split("#");
        foreach (var item in items)
        {
            _arguments.Add(new Argument(item));
        }
    }

    /**
     * <summary>Overloaded tostring method to convert an argument list to a string. Concatenates the string forms of all
     * arguments with '#' character.</summary>
     * <returns> string form of the argument list.</returns>
     */
    public override string ToString()
    {
        if (_arguments.Count == 0)
        {
            return "NONE";
        }
        else
        {
            var result = _arguments[0].ToString();
            for (var i = 1; i < _arguments.Count; i++)
            {
                result += "#" + _arguments[i];
            }

            return result;
        }
    }

    /**
     * <summary>Replaces id's of predicates, which have previousId as synset id, with currentId.</summary>
     * <param name="previousId"> Previous id of the synset.</param>
     * <param name="currentId"> Replacement id. </param>
     */
    public void UpdateConnectedId(string previousId, string currentId)
    {
        foreach (var argument in _arguments)
        {
            if (argument.GetId().Equals(previousId))
            {
                argument.SetId(currentId);
            }
        }
    }

    /**
     * <summary>Adds a predicate argument to the argument list of this word.</summary>
     * <param name="predicateId"> Synset id of this predicate.</param>
     */
    public void AddPredicate(string predicateId)
    {
        if (_arguments.Count > 0 && _arguments[0].GetArgumentType().Equals("NONE"))
        {
            _arguments.RemoveAt(0);
        }

        _arguments.Add(new Argument("PREDICATE", predicateId));
    }

    /**
     * <summary>Removes the predicate with the given predicate id.</summary>
     */
    public void RemovePredicate()
    {
        foreach (var argument in _arguments)
        {
            if (argument.GetArgumentType().Equals("PREDICATE"))
            {
                _arguments.Remove(argument);
                break;
            }
        }
    }

    /**
     * <summary>Checks if one of the arguments is a predicate.</summary>
     * <returns> True, if one of the arguments is predicate; false otherwise.</returns>
     */
    public bool ContainsPredicate()
    {
        foreach (var argument in _arguments)
        {
            if (argument.GetArgumentType().Equals("PREDICATE"))
            {
                return true;
            }
        }

        return false;
    }

    /**
     * <summary>Checks if one of the arguments is a predicate with the given id.</summary>
     * <param name="predicateId"> Synset id to check.</param>
     * <returns> True, if one of the arguments is predicate; false otherwise.</returns>
     */
    public bool ContainsPredicateWithId(string predicateId)
    {
        foreach (var argument in _arguments)
        {
            if (argument.GetArgumentType().Equals("PREDICATE") && argument.GetId().Equals(predicateId))
            {
                return true;
            }
        }

        return false;
    }

    /**
     * <summary>Returns the arguments as an array list of strings.</summary>
     * <returns> Arguments as an array list of strings.</returns>
     */
    public List<string> GetArguments()
    {
        var result = new List<string>();
        foreach (var argument in _arguments)
        {
            result.Add(argument.ToString());
        }

        return result;
    }

    /**
     * <summary>Checks if the given argument with the given type and id exists or not.</summary>
     * <param name="argumentType"> Type of the argument to search for.</param>
     * <param name="id">Id of the argument to search for.</param>
     * <returns> True if the argument exists, false otherwise.</returns>
     */
    public bool ContainsArgument(string argumentType, string id)
    {
        foreach (var argument in _arguments)
        {
            if (argument.GetArgumentType().Equals(argumentType) && argument.GetId().Equals(id))
            {
                return true;
            }
        }

        return false;
    }
}