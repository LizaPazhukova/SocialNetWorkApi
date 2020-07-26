using System;

namespace SocialNetwork.Logic.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message)
            : base(message)
        {

        }
    }
}
