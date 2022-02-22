namespace Common.Domain.Exceptions
{
    public class SlugIsDuplicateException:BaseDomainException
    {
        public SlugIsDuplicateException():base("Slug تکراری است!")
        {

        }
        public SlugIsDuplicateException(string message) : base(message)
        {

        }
    }
}