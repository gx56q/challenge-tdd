using System;
using System.Collections.Generic;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            switch (postfixExpression)
            {
                case "":
                    return  "0";
                case null:
                    throw new FormatException();
            }
            var stack = new Stack<LongComplex>();
            var postfixArray = postfixExpression.Split(' ');
            foreach (var item in postfixArray)
            {
                if (item is not ("+" or "-" or "*" or "/" or "^"))
                {
                    var number = LongComplex.Parse(item);
                    stack.Push(number);
                }
                else
                {
                    if (stack.Count < 2)
                        throw new FormatException();
                    var secondValue = stack.Pop();
                    var firstValue = stack.Pop();
                    switch (item)
                    {
                        case "+":
                            stack.Push(LongComplex.Add(firstValue, secondValue));
                            break;
                        case "-":
                            stack.Push(LongComplex.Subtract(firstValue, secondValue));
                            break;
                        case "*":
                            stack.Push(LongComplex.Multiply(firstValue, secondValue));
                            break;
                        case "/":
                            stack.Push(LongComplex.Parse((firstValue.Real / (int)secondValue.Real).ToString()));
                            break;
                        case "^":
                            stack.Push(LongComplex.Parse(((int)Math.Pow(firstValue.Real, secondValue.Real)).ToString()));
                            break;
                        default:
                            throw new FormatException();
                    }
                }
            }
            if (stack.Count == 2)
                throw new FormatException();
            return stack.Pop().ToString();
        }
    }
}
