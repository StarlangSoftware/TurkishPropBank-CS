using System.Collections.Generic;
using NUnit.Framework;
using PropBank;

namespace Test
{
    public class FramesetListTest
    {
        FramesetList framesetList;

        [SetUp]
        public void Setup()
        {
            framesetList = new FramesetList();
        }

        [Test]
        public void TestFrames()
        {
            Assert.AreEqual(17691, framesetList.Size());
        }

        [Test]
        public void TestArgSize()
        {
            int count = 0;
            for (int i = 0; i < framesetList.Size(); i++)
            {
                count += framesetList.GetFrameSet(i).GetFramesetArguments().Count;
            }

            Assert.AreEqual(29759, count);
        }

        [Test]
        public void TestArgName()
        {
            var nameList = new Dictionary<string, int>();
            for (var i = 0; i < framesetList.Size(); i++)
            {
                foreach (var argument in framesetList.GetFrameSet(i).GetFramesetArguments())
                {
                    if (nameList.ContainsKey(argument.GetArgumentType()))
                    {
                        nameList[argument.GetArgumentType()] = nameList[argument.GetArgumentType()] + 1;
                    }
                    else
                    {
                        nameList.Add(argument.GetArgumentType(), 1);
                    }
                }
            }

            Assert.AreEqual(14668, nameList["ARG0"]);
            Assert.AreEqual(13126, nameList["ARG1"]);
            Assert.AreEqual(1886, nameList["ARG2"]);
            Assert.AreEqual(78, nameList["ARG3"]);
            Assert.AreEqual(1, nameList["ARG4"]);
        }

        [Test]
        public void TestArgFunction()
        {
            var functionList = new Dictionary<string, int>();
            for (var i = 0; i < framesetList.Size(); i++)
            {
                foreach (var argument in framesetList.GetFrameSet(i).GetFramesetArguments())
                {
                    if (functionList.ContainsKey(argument.GetFunction()))
                    {
                        functionList[argument.GetFunction()] = functionList[argument.GetFunction()] + 1;
                    }
                    else
                    {
                        functionList.Add(argument.GetFunction(), 1);
                    }
                }
            }

            Assert.AreEqual(481, functionList["com"]);
            Assert.AreEqual(14, functionList["ext"]);
            Assert.AreEqual(814, functionList["loc"]);
            Assert.AreEqual(198, functionList["rec"]);
            Assert.AreEqual(14, functionList["pat"]);
            Assert.AreEqual(10687, functionList["ppt"]);
            Assert.AreEqual(605, functionList["src"]);
            Assert.AreEqual(801, functionList["gol"]);
            Assert.AreEqual(156, functionList["tmp"]);
            Assert.AreEqual(14557, functionList["pag"]);
            Assert.AreEqual(1432, functionList["dir"]);
        }
    }
}