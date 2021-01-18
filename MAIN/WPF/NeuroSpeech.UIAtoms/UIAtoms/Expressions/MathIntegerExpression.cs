#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Expressions
{
    /// <summary>
    /// 
    /// </summary>
    public class MathIntegerExpression : BaseMathExpression<int>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<int> Add(object left, object right)
        {
            BinaryMathExpression<int> bi = new BinaryMathExpression<int>(MathNodeType.Add, (x, y) => x + y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<int> Sub(object left, object right)
        {
            BinaryMathExpression<int> bi = new BinaryMathExpression<int>(MathNodeType.Sub, (x, y) => x - y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<int> Mul(object left, object right)
        {
            BinaryMathExpression<int> bi = new BinaryMathExpression<int>(MathNodeType.Mul, (x, y) => x * y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<int> Div(object left, object right)
        {
            BinaryMathExpression<int> bi = new BinaryMathExpression<int>(MathNodeType.Div, (x, y) => x / y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<int> Mod(object left, object right)
        {
            BinaryMathExpression<int> bi = new BinaryMathExpression<int>(MathNodeType.Mod, (x, y) => x % y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<int> Neg(object value)
        {
            UnaryMathExpression<int> exp = new UnaryMathExpression<int>(MathNodeType.Neg, (x) => -x, null);
            exp.Expression = Get(value);
            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<int> Sqrt(object value)
        {
            UnaryMathExpression<int> exp = new UnaryMathExpression<int>(MathNodeType.Sqrt, (x) => (int)Math.Sqrt((double)x), null);
            exp.Expression = Get(value);
            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<int> Reciproc(object value)
        {
            UnaryMathExpression<int> exp = new UnaryMathExpression<int>(MathNodeType.Reciproc, (x) => 1 / x, null);
            exp.Expression = Get(value);
            return exp;
        }


    }
}
