namespace NET.Design_Patterns.Parse
{
    /// Summary:
    ///     This interface is used to define the contract of a parser.
    public interface IParser
    {
        /// Summary:
        ///     This method is used to parse content without error handling.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to parse.
        /// 
        /// Returns:
        ///     A parsed object.
        object Parse(object content);

        /// Summary:
        ///     This method is used to parse content with error handling.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to try parse.
        /// 
        ///     value:
        ///         The parsed content value.
        /// 
        /// Returns:
        ///     A boolean result from the parse.
        bool TryParse(object content, out object value);
    }
    
    /// Summary:
    ///     This interface is used to define the contract of a parser.
    /// 
    /// Type parameters:
    ///     T:
    ///         Generic type to define this interface on.
    public interface IParser<T> : IParser
    {   
        /// Summary:
        ///     This method is used to parse content without error handling,
        ///     defined with a body already.
        object IParser.Parse(object content) 
        { 
            return this.Parse(content); 
        }

        /// Summary:
        ///     This method is used to parse content with error handling,
        ///     defined with a body already.
        bool IParser.TryParse(object content, out object value) 
        {   
            return this.TryParse(content, out value);
        }

        /// Summary:
        ///     This method is used to parse content without error handling.
        ///  
        /// Parameters:
        ///     content:
        ///         An object to parse.
        /// 
        /// Returns:
        ///     A parsed generic type of this interface. 
        new T Parse(object content);

        /// Summary:
        ///     This method is used to parse content with error handling.
        /// 
        /// Parameters:
        ///     content:
        ///         An object to try parse.
        ///         
        ///     value:
        ///         A generic type of parsed content value.
        /// 
        /// Returns:
        ///     A boolean result from the parse.
        bool TryParse(object content, out T value);
    }
}