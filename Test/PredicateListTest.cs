using System.Collections.Generic;
using NUnit.Framework;
using PropBank;

namespace Test
{
    public class PredicateListTest
    {
        private PredicateList predicateList;

        [SetUp]
        public void Setup()
        {
            predicateList = new PredicateList();
        }

        [Test]
        public void TestPredicateSize()
        {
            Assert.AreEqual(8656, predicateList.Size());
        }

        [Test]
        public void TestRoleSetSize()
        {
            var count = 0;
            foreach (var lemma in predicateList.GetLemmaList()){
                count += predicateList.GetPredicate(lemma).Size();
            }
            Assert.AreEqual(10685, count);
        }

        [Test]
        public void TestRoleSize()
        {
            var count = 0;
            foreach (var lemma in predicateList.GetLemmaList()){
                for (int i = 0; i < predicateList.GetPredicate(lemma).Size(); i++)
                {
                    count += predicateList.GetPredicate(lemma).GetRoleSet(i).Size();
                }
            }
            Assert.AreEqual(27080, count);
        }

        [Test]
        public void TestFunction()
        {
            var functionList = new Dictionary<string, int>();
            foreach (var lemma in predicateList.GetLemmaList()){
                for (var i = 0; i < predicateList.GetPredicate(lemma).Size(); i++)
                {
                    for (var j = 0; j < predicateList.GetPredicate(lemma).GetRoleSet(i).Size(); j++)
                    {
                        var function = predicateList.GetPredicate(lemma).GetRoleSet(i).GetRole(j).GetF();
                        if (functionList.ContainsKey(function))
                        {
                            functionList[function] = functionList[function] + 1;
                        }
                        else
                        {
                            functionList.Add(function, 1);
                        }
                    }
                }
            }
            Assert.AreEqual(197, functionList["com"]);
            Assert.AreEqual(292, functionList["ext"]);
            Assert.AreEqual(580, functionList["loc"]);
            Assert.AreEqual(1104, functionList["prd"]);
            Assert.AreEqual(2395, functionList["gol"]);
            Assert.AreEqual(19, functionList["adj"]);
            Assert.AreEqual(980, functionList["dir"]);
            Assert.AreEqual(118, functionList["prp"]);
            Assert.AreEqual(1007, functionList["mnr"]);
            Assert.AreEqual(4, functionList["rec"]);
            Assert.AreEqual(679, functionList["vsp"]);
            Assert.AreEqual(14, functionList["adv"]);
            Assert.AreEqual(10282, functionList["ppt"]);
            Assert.AreEqual(267, functionList["cau"]);
            Assert.AreEqual(37, functionList["tmp"]);
            Assert.AreEqual(9105, functionList["pag"]);
        }

        [Test]
        public void TestN()
        {
            var nList = new Dictionary<string, int>();
            foreach (var lemma in predicateList.GetLemmaList()){
                for (var i = 0; i < predicateList.GetPredicate(lemma).Size(); i++)
                {
                    for (var j = 0; j < predicateList.GetPredicate(lemma).GetRoleSet(i).Size(); j++)
                    {
                        var n = predicateList.GetPredicate(lemma).GetRoleSet(i).GetRole(j).GetN();
                        if (nList.ContainsKey(n))
                        {
                            nList[n] = nList[n] + 1;
                        }
                        else
                        {
                            nList.Add(n, 1);
                        }
                    }
                }
            }
            Assert.AreEqual(8906, nList["0"]);
            Assert.AreEqual(10375, nList["1"]);
            Assert.AreEqual(5934, nList["2"]);
            Assert.AreEqual(1313, nList["3"]);
            Assert.AreEqual(417, nList["4"]);
            Assert.AreEqual(57, nList["5"]);
            Assert.AreEqual(6, nList["6"]);
            Assert.AreEqual(72, nList["m"]);
        }
    }
}