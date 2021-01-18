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
    public class MathDecimalExpression : BaseMathExpression<decimal>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<decimal> Add(object left, object right)
        {
            BinaryMathExpression<decimal> bi = new BinaryMathExpression<decimal>(MathNodeType.Add, (x, y) => x + y, null);
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
        public static BinaryMathExpression<decimal> Sub(object left, object right)
        {
            BinaryMathExpression<decimal> bi = new BinaryMathExpression<decimal>(MathNodeType.Sub, (x, y) => x - y, null);
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
        public static BinaryMathExpression<decimal> Mul(object left, object right)
        {
            BinaryMathExpression<decimal> bi = new BinaryMathExpression<decimal>(MathNodeType.Mul, (x, y) => x * y, null);
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
        public static BinaryMathExpression<decimal> Div(object left, object right)
        {
            BinaryMathExpression<decimal> bi = new BinaryMathExpression<decimal>(MathNodeType.Div, (x, y) => x / y, null);
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
        public static BinaryMathExpression<decimal> Mod(object left, object right)
        {
            BinaryMathExpression<decimal> bi = new BinaryMathExpression<decimal>(MathNodeType.Mod, (x, y) => x % y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<decimal> Neg(object value)
        {
            UnaryMathExpression<decimal> exp = new UnaryMathExpression<decimal>(MathNodeType.Neg, (x) => -x, null);
            exp.Expression = Get(value);
            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<decimal> Sqrt(object value)
        {
            UnaryMathExpression<decimal> exp = new UnaryMathExpression<decimal>(MathNodeType.Sqrt, (x) => (decimal)Math.Sqrt((double)x), null);
            exp.Expression = Get(value);
            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<decimal> Reciproc(object value)
        {
            UnaryMathExpression<decimal> exp = new UnaryMathExpression<decimal>(MathNodeType.Reciproc, (x) => 1 / x, null);
            exp.Expression = Get(value);
            return exp;
        }




    }
}
