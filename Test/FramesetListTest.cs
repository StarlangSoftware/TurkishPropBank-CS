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
            Assert.AreEqual(17692, framesetList.Size());
        }

        [Test]
        public void TestArgSize()
        {
            var count = 0;
            for (var i = 0; i < framesetList.Size(); i++)
            {
                count += framesetList.GetFrameSet(i).GetFramesetArguments().Count;
            }

            Assert.AreEqual(29761, count);
        }

        private void UpdateHashMap(Dictionary<string, int> map, string value){
            if (map.ContainsKey(value)){
                map[value] = map[value] + 1;
            } else {
                map[value] = 1;
            }
        }

        [Test]
        public void TestCase()
        {
            var caseList = new Dictionary<string, int>();
            for (var i = 0; i < framesetList.Size(); i++)
            {
                foreach (var argument in framesetList.GetFrameSet(i).GetFramesetArguments())
                {
                    if (argument.GetGrammaticalCase().Length != 0)
                    {
                        if (argument.GetGrammaticalCase().Contains("abl"))
                        {
                            UpdateHashMap(caseList, "abl");
                        }
                        if (argument.GetGrammaticalCase().Contains("acc"))
                        {
                            UpdateHashMap(caseList, "acc");
                        }
                        if (argument.GetGrammaticalCase().Contains("dat"))
                        {
                            UpdateHashMap(caseList, "dat");
                        }
                        if (argument.GetGrammaticalCase().Contains("gen"))
                        {
                            UpdateHashMap(caseList, "gen");
                        }
                        if (argument.GetGrammaticalCase().Contains("ins"))
                        {
                            UpdateHashMap(caseList, "ins");
                        }
                        if (argument.GetGrammaticalCase().Contains("loc"))
                        {
                            UpdateHashMap(caseList, "loc");
                        }
                        if (argument.GetGrammaticalCase().Contains("nom"))
                        {
                            UpdateHashMap(caseList, "nom");
                        }
                    }
                }
            }

            Assert.AreEqual(422, caseList["abl"]);
            Assert.AreEqual(4690, caseList["acc"]);
            Assert.AreEqual(2423, caseList["dat"]);
            Assert.AreEqual(880, caseList["gen"]);
            Assert.AreEqual(459, caseList["ins"]);
            Assert.AreEqual(673, caseList["loc"]);
            Assert.AreEqual(2069, caseList["nom"]);
        }
        
        [Test]
        public void TestArgName()
        {
            var nameList = new Dictionary<string, int>();
            for (var i = 0; i < framesetList.Size(); i++)
            {
                foreach (var argument in framesetList.GetFrameSet(i).GetFramesetArguments())
                {
                    UpdateHashMap(nameList, argument.GetArgumentType());
                }
            }

            Assert.AreEqual(14669, nameList["ARG0"]);
            Assert.AreEqual(13127, nameList["ARG1"]);
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
                    UpdateHashMap(functionList, argument.GetFunction());
                }
            }

            Assert.AreEqual(481, functionList["com"]);
            Assert.AreEqual(14, functionList["ext"]);
            Assert.AreEqual(814, functionList["loc"]);
            Assert.AreEqual(198, functionList["rec"]);
            Assert.AreEqual(14, functionList["pat"]);
            Assert.AreEqual(10688, functionList["ppt"]);
            Assert.AreEqual(605, functionList["src"]);
            Assert.AreEqual(801, functionList["gol"]);
            Assert.AreEqual(156, functionList["tmp"]);
            Assert.AreEqual(14558, functionList["pag"]);
            Assert.AreEqual(1432, functionList["dir"]);
        }
    }
}