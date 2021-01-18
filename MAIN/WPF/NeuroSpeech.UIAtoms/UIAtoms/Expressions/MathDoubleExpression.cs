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
    public class MathDoubleExpression : BaseMathExpression<double>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static BinaryMathExpression<double> Add(object left, object right)
        {
            BinaryMathExpression<double> bi = new BinaryMathExpression<double>(MathNodeType.Add, (x, y) => x + y, null);
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
        public static BinaryMathExpression<double> Sub(object left, object right)
        {
            BinaryMathExpression<double> bi = new BinaryMathExpression<double>(MathNodeType.Sub, (x, y) => x - y, null);
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
        public static BinaryMathExpression<double> Mul(object left, object right)
        {
            BinaryMathExpression<double> bi = new BinaryMathExpression<double>(MathNodeType.Mul, (x, y) => x * y, null);
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
        public static BinaryMathExpression<double> Div(object left, object right)
        {
            BinaryMathExpression<double> bi = new BinaryMathExpression<double>(MathNodeType.Div, (x, y) => x / y, null);
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
        public static BinaryMathExpression<double> Mod(object left, object right)
        {
            BinaryMathExpression<double> bi = new BinaryMathExpression<double>(MathNodeType.Mod, (x, y) => x % y, null);
            bi.Left = Get(left);
            bi.Right = Get(right);
            return bi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<double> Neg(object value)
        {
            UnaryMathExpression<double> exp = new UnaryMathExpression<double>(MathNodeType.Neg, (x) => -x, null);
            exp.Expression = Get(value);
            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<double> Sqrt(object value)
        {
            UnaryMathExpression<double> exp = new UnaryMathExpression<double>(MathNodeType.Sqrt, (x) => (double)Math.Sqrt((double)x), null);
            exp.Expression = Get(value);
            return exp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static UnaryMathExpression<double> Reciproc(object value)
        {
            UnaryMathExpression<double> exp = new UnaryMathExpression<double>(MathNodeType.Reciproc, (x) => 1 / x, null);
            exp.Expression = Get(value);
            return exp;
        }


    }
}
