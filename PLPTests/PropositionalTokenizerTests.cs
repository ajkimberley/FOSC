using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLP.Tests
{
    [TestClass()]
    public class PropositionalTokenizerTests
    {
        [TestMethod()]
        public void ScanNothingTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan("");

            Assert.AreEqual(0, tokens.Count()); 
        }

        [TestMethod()]
        public void ScanWhiteSpaceTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();
            
            List<string> whiteSpaceChars = new List<string> { " ", "\t", "\r", "\n" };

            foreach (string c in whiteSpaceChars)
            {
                var tokens = tokenizer.Scan(c);

                Assert.AreEqual(0, tokens.Count());
            }
        }

        [TestMethod()]
        public void ScanSinglePropositionTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan("P");

            Assert.AreEqual(1, tokens.Count());

            Assert.IsInstanceOfType(tokens.ElementAt(0), typeof(PropVarsToken));
        }

        [TestMethod()]
        public void ScanConjunctionTokenTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan("&");

            Assert.AreEqual(1, tokens.Count());

            Assert.IsInstanceOfType(tokens.ElementAt(0), typeof(ConjunctionToken));
        }

        [TestMethod()]
        public void ScanDisjunctionTokenTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan("V");

            Assert.AreEqual(1, tokens.Count());

            Assert.IsInstanceOfType(tokens.ElementAt(0), typeof(DisjunctionToken));
        }

        [TestMethod()]
        public void ScanConditionalTokenTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan(">");

            Assert.AreEqual(1, tokens.Count());

            Assert.IsInstanceOfType(tokens.ElementAt(0), typeof(ConditionalToken));
        }

        [TestMethod()]
        public void ScanLeftBracketTokenTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan("(");

            Assert.AreEqual(1, tokens.Count());

            Assert.IsInstanceOfType(tokens.ElementAt(0), typeof(LeftBracketToken));
        }

        [TestMethod()]
        public void ScanRightBracketTokenTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan(")");

            Assert.AreEqual(1, tokens.Count());

            Assert.IsInstanceOfType(tokens.ElementAt(0), typeof(RightBracketToken));
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void ScanInvalidTokenTest()
        {
            PropositionalTokenizer tokenizer = new PropositionalTokenizer();

            var tokens = tokenizer.Scan("%");
        }
    }
}