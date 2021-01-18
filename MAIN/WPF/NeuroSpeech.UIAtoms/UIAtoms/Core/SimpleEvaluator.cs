#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Reflection;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class SimpleEvaluator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public static double Evaluate(string expression, double baseObject)
        {
            DynamicMethod method = GetAssembly(expression);
            Func<double, double> eval = (Func<double, double>)method.CreateDelegate(typeof(Func<double, double>));
            return eval(baseObject);
        }

        private static Dictionary<string, DynamicMethod> Methods = new Dictionary<string, DynamicMethod>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static DynamicMethod GetAssembly(string exp)
        {
            lock (Methods)
            {
                DynamicMethod method;
                if (Methods.TryGetValue(exp, out method))
                {
                    return method;
                }
                method = new DynamicMethod("Eval" + Methods.Count, typeof(double), new Type[] { typeof(double) });
                CreateMethod(method, exp);
                Methods[exp] = method;
                return method;
            }
        }

        private static void CreateMethod(DynamicMethod method, string exp)
        {
            ILGenerator gen = method.GetILGenerator();

            Regex reg = new Regex("([0-9\\.]+)|(\\W{1})");
            Stack<string> stack = new Stack<string>();

            Stack<Stack<string>> scopes = new Stack<Stack<string>>();

            

            foreach (string e in reg.Split(exp))
            {

                if (e.Length == 0)
                    continue;

                Console.WriteLine(e);
                switch (e)
                {


                    case "(":
                        scopes.Push(stack);
                        stack = new Stack<string>();
                        break;


                    case ")":
                        PopExecute(gen, stack);
                        stack = scopes.Pop();
                        break;


                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "^":

                        if (stack.Count > 0)
                        {
                            if (Prcedes(stack.Peek(), e))
                            {
                                PopExecute(gen, stack);
                            }
                        }
                        stack.Push(e);
                        break;


                    default:
                        if (e == "input")
                        {
                            gen.Emit(OpCodes.Ldarg_0);
                        }
                        else
                        {
                            gen.Emit(OpCodes.Ldc_R8, double.Parse(e));
                        }
                        break;
                }

            }

            PopExecute(gen, stack);

            gen.Emit(OpCodes.Ret);
        }

        private static void PopExecute(ILGenerator gen, Stack<string> stack)
        {
            while (stack.Count > 0)
            {
                EmitOp(gen, stack.Pop());
            }

        }

        private static void EmitOp(ILGenerator gen, string op)
        {
            switch (op)
            {
                case "+":
                    gen.Emit(OpCodes.Add);
                    break;
                case "-":
                    gen.Emit(OpCodes.Sub);
                    break;
                case "*":
                    gen.Emit(OpCodes.Mul);
                    break;
                case "/":
                    gen.Emit(OpCodes.Div);
                    break;
                case "^":
                    gen.EmitCall(OpCodes.Call, GetPowerMethod(), null);

                    break;
                default:
                    break;
            }
        }

        private static MethodInfo GetPowerMethod()
        {
            Type type = typeof(Math);
            return type.GetMethod("Pow");
        }

        private static bool Prcedes(string peek, string op)
        {
            if (peek == op)
                return true;
            if (peek == "^")
                return true;
            if (peek == "*" && op != "^")
                return true;
            if (peek == "/" && op != "*")
                return true;
            return false;
        }

    }

}
