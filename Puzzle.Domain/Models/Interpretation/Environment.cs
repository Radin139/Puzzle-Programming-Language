using Puzzle.Domain.Interfaces;
using Puzzle.Domain.Models.Compiler;
using Puzzle.Domain.Models.Compiler.CompilerErrors;

namespace Puzzle.Domain.Models.Interpretation;

public class Environment(ICompilerHandler handler, Environment? parent = null)
{
    private Dictionary<string, Container> variables = new Dictionary<string, Container>();

    #region DataTypeValidation

    private bool isDataTypeValid(ValueType baseType, ValueType valueType)
    {
        if (baseType == valueType)
        {
            return true;
        }
        if (valueType == ValueType.Empty)
        {
            return true;
        }
        
        return false;
    }

    #endregion
    
    #region Declare

    public RuntimeValue Declare(string varname, ValueType datatype, RuntimeValue value, bool isConstant,
        Location identifierLocation)
    {
        if (Contains(varname, true))
        {
            handler.Error(new DataExistsCompilerError(varname, identifierLocation));
        }

        if (!isDataTypeValid(datatype, value.Type))
        {
            handler.Error(new CastingCompilerError(datatype, value.Type, value.Start));
        }
        
        variables.Add(varname, new Container(datatype, value, isConstant));
        
        return value;
    }

    #endregion

    #region Resolve

    public Environment Resolve(string varname, Location identifierLocation)
    {
        if (variables.ContainsKey(varname))
        {
            return this;
        }

        if (parent == null)
        {
            handler.Error(new ResolveCompilerError(varname, identifierLocation));
        }
        
        return parent.Resolve(varname, identifierLocation);
    }

    #endregion

    #region Contains

    public bool Contains(string varname, bool includeParents)
    {
        if (variables.ContainsKey(varname))
        {
            return true;
        }

        if (parent == null || !includeParents)
        {
            return false;
        }
        
        return parent.Contains(varname, true);
    }

    #endregion

    #region Lookup

    public Container Lookup(string varname, Location identifierLocation)
    {
        Environment env = Resolve(varname, identifierLocation);
        return env.variables[varname];
    }

    #endregion

    #region Assign

    public RuntimeValue Assign(string varname, RuntimeValue value, Location identifierLocation, Location equalsLocation)
    {
        Container container = Lookup(varname, identifierLocation);

        if (container.IsConstant)
        {
            handler.Error(new AssignmentToConstantCompilerError(varname, equalsLocation));
        }
        
        if (!isDataTypeValid(container.DataType, value.Type))
        {
            handler.Error(new CastingCompilerError(container.DataType, value.Type, value.Start));
        }
        
        variables[varname].Value = value;
        
        return value;
    }

    #endregion
}