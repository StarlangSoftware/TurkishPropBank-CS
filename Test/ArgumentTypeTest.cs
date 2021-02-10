using NUnit.Framework;
using PropBank;

namespace Test
{
    public class ArgumentTypeTest
    {
        
        [Test]
        public void TestArgumentType()
        {
            Assert.AreEqual(ArgumentTypeStatic.GetArguments("arg0"), ArgumentType.ARG0);
            Assert.AreEqual(ArgumentTypeStatic.GetArguments("argmdis"), ArgumentType.ARGMDIS);
            Assert.AreEqual(ArgumentTypeStatic.GetArguments("Arg1"), ArgumentType.ARG1);
            Assert.AreEqual(ArgumentTypeStatic.GetArguments("Argmdir"), ArgumentType.ARGMDIR);
        }
        
    }
}