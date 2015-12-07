using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventDay7CS
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var lines = File.ReadLines("input.txt");

            List<Node> collection = GetNodeCollection(lines);

            // now traverse and link nodes
            var rootNode = GetNode("a", collection);

            int initialAOutput = rootNode.CalculateOutput();

            // Reset B wire statically for part2
            var bNode = GetNode("b", collection);            
            bNode.Operation = Operation.STATIC;
            bNode.LinkA = null;
            bNode.LinkB = null;
            bNode.StaticInputA = true;
            bNode.IntInputA = 16076;
            bNode.StaticInputB = false;
            bNode.IntInputB = null;

            collection.ForEach((e)=>e.ResetOutput());
                        
            int modifiedAOutput = rootNode.CalculateOutput();

            Console.WriteLine($"Bobby's A Value (V1): {initialAOutput}");
            Console.WriteLine($"Bobby's Modified A Value (V2): {modifiedAOutput}");
            Console.Write("Press any key to continue..");
            Console.ReadLine();

        }

        private static List<Node> GetNodeCollection(IEnumerable<string> lines)
        {
            List<Node> collection = new List<Node>();
            foreach (string line in lines)
            {
                var andOrMatch = Regex.Match(line, @"^(?<in1>[a-z0-9]{1,6})\s(?<op>OR|AND)\s(?<in2>[a-z0-9]{1,6})\s->\s(?<dest>[a-z]{1,6})$");
                var shiftMatch = Regex.Match(line, @"^(?<in1>[a-z0-9]{1,6})\s(?<op>RSHIFT|LSHIFT)\s(?<amt>[0-9]{1,6})\s->\s(?<dest>[a-z]{1,6})$$");
                var notMatch = Regex.Match(line, @"^(?<op>NOT)\s(?<in1>[a-z]{1,6})\s->\s(?<dest>[a-z]{1,6})$$");
                var staticMatch = Regex.Match(line, @"^(?<in1>[a-z0-9]{1,6})\s->\s(?<dest>[a-z]{1,6})$$");

                if (andOrMatch.Success)
                {
                    int val1 = 0;
                    int val2 = 0;

                    var val1Parsed = int.TryParse(andOrMatch.Groups["in1"].Value, out val1);
                    var val2Parsed = int.TryParse(andOrMatch.Groups["in2"].Value, out val2);
                    collection.Add(new Node()
                    {
                        NodeName = andOrMatch.Groups["dest"].Value,
                        InputA = !val1Parsed ? andOrMatch.Groups["in1"].Value : null,
                        InputB = !val2Parsed ? andOrMatch.Groups["in2"].Value : null,
                        StaticInputA = val1Parsed,
                        StaticInputB = val2Parsed,
                        IntInputA = val1Parsed ? val1 : (int?)null,
                        IntInputB = val2Parsed ? val2 : (int?)null,
                        Operation = andOrMatch.Groups["op"].Value == "AND" ? Operation.AND : Operation.OR
                    });
                }

                if (shiftMatch.Success)
                {
                    collection.Add(new Node()
                    {
                        NodeName = shiftMatch.Groups["dest"].Value,
                        InputA = shiftMatch.Groups["in1"].Value,
                        Operation = shiftMatch.Groups["op"].Value == "RSHIFT" ? Operation.RSHIFT : Operation.LSHIFT,
                        StaticInputB = true,
                        IntInputB = int.Parse(shiftMatch.Groups["amt"].Value)
                    });
                }

                if (notMatch.Success)
                {
                    collection.Add(new Node()
                    {
                        NodeName = notMatch.Groups["dest"].Value,
                        InputB = notMatch.Groups["in1"].Value,
                        Operation = Operation.NOT
                    });
                }

                if (staticMatch.Success)
                {
                    int parseResult = 0;
                    if (int.TryParse(staticMatch.Groups["in1"].Value, out parseResult))
                    {
                        collection.Add(new Node()
                        {
                            NodeName = staticMatch.Groups["dest"].Value,
                            StaticInputA = true,
                            IntInputA = parseResult,
                            Operation = Operation.STATIC
                        });
                    }
                    else
                    {
                        collection.Add(new Node()
                        {
                            NodeName = staticMatch.Groups["dest"].Value,
                            InputA = staticMatch.Groups["in1"].Value,
                            Operation = Operation.STATIC
                        });
                    }
                }
            }

            return collection;
        }

        public static Node GetNode(string nodeName, List<Node> collection)
        {
            var node = collection.Single(n => n.NodeName == nodeName);
            
            if (!(node.InputA == null && node.StaticInputA == false) && node.LinkA == null)
            {
                // input A search req'd
                if (!node.StaticInputA)
                {
                    node.LinkA = GetNode(node.InputA, collection);
                }
            }

            if (!(node.InputB == null && node.StaticInputB == false) && node.LinkB == null)
            {
            //    // input B search req'd
                if (!node.StaticInputB)
                {
                        node.LinkB = GetNode(node.InputB, collection);
                }
            }

            return node;
        }
    }


    

    public enum Operation
    {
        AND,
        OR,
        NOT,
        LSHIFT,
        RSHIFT,
        STATIC
    }

    public class Node
    {

        public string NodeName { get; set; }
        public string InputA { get; set; }
        public string InputB { get; set; }

        public Node LinkA { get; set; }
        public Node LinkB { get; set; }

        public int? MyValue { get; set; }
        public int? ValA { get; set; }
        public int? ValB { get; set; }

        public bool StaticInputA { get; set; }
        public bool StaticInputB { get; set; }

        public int? IntInputA { get; set; }
        public int? IntInputB { get; set; }

        public Operation Operation { get; set; }

        public void ResetOutput()
        {
            this.MyValue = null;
            this.ValA = null;
            this.ValB = null;
        }

        public int CalculateOutput()
        {
            int returnVal = 0;
            if (this.MyValue.HasValue)
            {
                return this.MyValue.Value;
            }

            this.ValA = StaticInputA ? IntInputA : LinkA?.CalculateOutput();
            this.ValB = StaticInputB ? IntInputB : LinkB?.CalculateOutput();

            switch (this.Operation)
            {
                case Operation.AND:
                    returnVal = ValA.Value & ValB.Value;
                    break;

                case Operation.OR:
                    returnVal = ValA.Value | ValB.Value;
                    break;
                case Operation.LSHIFT:
                    returnVal = ValA.Value << ValB.Value;
                    break;

                case Operation.RSHIFT:
                    returnVal = ValA.Value >> ValB.Value;
                    break;
                case Operation.NOT:
                    returnVal = ~ValB.Value;
                    break;
                case Operation.STATIC:
                    returnVal = ValA.Value;
                    break;
            }

            this.MyValue = returnVal;

            return returnVal;
        }
    }    
}
