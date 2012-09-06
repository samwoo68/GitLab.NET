
namespace GitLab.NET
{
    /// <summary>
    /// Represents a security token, used to authenticate by several web apis
    /// </summary>
    public class Token
    {
        private readonly string _token;

        public Token(string token)
        {
            this._token = token;
        }

        public override string ToString()
        {
            return _token;
        }
    }
}
