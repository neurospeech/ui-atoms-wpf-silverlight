#if NETFX_CORE
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
    /// <typeparam name="T"></typeparam>
    public abstract class BaseMathExpression<T>
    {
        /// <summary>
        /// 
        /// </summary>
        protected BaseMathExpression()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeType"></param>
        protected BaseMathExpression(MathNodeType nodeType)
        {
            this.NodeType = nodeType;
        }

        /// <summary>
        /// 
        /// </summary>
        public MathNodeType NodeType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual T Invoke() {
            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ConstantMathExpression<T> ValueExpression {
            get {
                return new ConstantMathExpression<T>(this.Invoke());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static BaseMathExpression<T> Get(object value) {
            if (value == null)
                return null;
            BaseMathExpression<T> be = value as BaseMathExpression<T>;
            if (be != null)
                return be;
            return new ConstantMathExpression<T>((T)value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static BaseMathExpression<T> SubExp()
        {
            BaseMathExpression<T> pexp = new UnaryMathExpression<T>(MathNodeType.SubExpression, null, null);
            return pexp;
        }


    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public delegate T BinaryMathInvoke<T>(T left, T right);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="be"></param>
    /// <returns></returns>
    public delegate T UnaryMathInvoke<T>(T be);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public delegate string BinaryMathPrintInvoke(string left, string right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="be"></param>
    /// <returns></returns>
    public delegate string UnaryMathPrintInvoke(string be);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ConstantMathExpression<T> : BaseMathExpression<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public ConstantMathExpression(T value): base(MathNodeType.Constant)
        {
            Value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override T Invoke()
        {
            return Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnaryMathExpression<T> : BaseMathExpression<T> 
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="del"></param>
        /// <param name="pdel"></param>
        public UnaryMathExpression(MathNodeType type, UnaryMathInvoke<T> del, UnaryMathPrintInvoke pdel)
            : base(type)
        {
            InvokeDelegate = del;
            PrintDelegate = pdel;
        }

        /// <summary>
        /// 
        /// </summary>
        public UnaryMathInvoke<T> InvokeDelegate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UnaryMathPrintInvoke PrintDelegate { get; set; }

        ///<summary>
        /// Property Expression
        ///</summary>
        public BaseMathExpression<T> Expression { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override T Invoke()
        {
            if (InvokeDelegate != null)
                return InvokeDelegate(Expression.Invoke());
            if (Expression != null)
                return Expression.Invoke();
            return base.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            if (PrintDelegate != null) {
                return PrintDelegate(Expression.ToString());
            }

            switch (NodeType)
            {
                case MathNodeType.SubExpression:
                    if (Expression == null)
                        return "(";
                    return "(" + Expression.ToString() + ")";

                case MathNodeType.Neg:
                    if (Expression == null)
                        return "";
                    return "negate(" + Expression.ToString() + ")";

                case MathNodeType.Reciproc:
                    if (Expression == null)
                        return "";
                    return "Reciproc(" + Expression.ToString() + ")";

                case MathNodeType.Sqrt:
                    if (Expression == null)
                        return "";
                    return "Sqrt(" + Expression.ToString() + ")";

                default:
                    break;
            }
            return base.ToString();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryMathExpression<T> : BaseMathExpression<T> {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="del"></param>
        /// <param name="pdel"></param>
        public BinaryMathExpression(MathNodeType type, BinaryMathInvoke<T> del, BinaryMathPrintInvoke pdel) : base(type)
        {
            InvokeDelegate = del;
            PrintDelegate = pdel;
        }

        /// <summary>
        /// 
        /// </summary>
        public BinaryMathInvoke<T> InvokeDelegate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BinaryMathPrintInvoke PrintDelegate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseMathExpression<T> Left { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseMathExpression<T> Right { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override T Invoke()
        {
            if (Left != null && Right != null)
            {
                return InvokeDelegate(Left.Invoke(), Right.Invoke());
            }
            /*if (Left == null)
                return Right.Invoke();
            if (Right == null)
                return Left.Invoke();*/
            return base.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            string left = Left == null ? "" : Left.ToString();
            string right = Right == null ? "" : Right.ToString();

            if (PrintDelegate != null) {
                return PrintDelegate(left, right);
            }

            switch (NodeType)
            {
                case MathNodeType.Add:
                    return left + " + " + right;
                case MathNodeType.Sub:
                    return left + " - " + right;
                case MathNodeType.Mul:
                    return left + " * " + right;
                case MathNodeType.Div:
                    return left + " / " + right;
                case MathNodeType.Mod:
                    return left + " % " + right;
                default:
                    break;
            }

            return base.ToString();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public enum MathNodeType{

        /// <summary>
        /// 
        /// </summary>
        Constant,

        /// <summary>
        /// 
        /// </summary>
        SubExpression,

        /// <summary>
        /// 
        /// </summary>
        Add,

        /// <summary>
        /// 
        /// </summary>
        Sub,

        /// <summary>
        /// 
        /// </summary>
        Mul,

        /// <summary>
        /// 
        /// </summary>
        Div,

        /// <summary>
        /// 
        /// </summary>
        Neg,

        /// <summary>
        /// 
        /// </summary>
        Mod,

        /// <summary>
        /// 
        /// </summary>
        Reciproc,

        /// <summary>
        /// 
        /// </summary>
        Sqrt,

        /// <summary>
        /// 
        /// </summary>
        Perc
    }
}
