#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Controls;
#endif
using System;
using NeuroSpeech.UIAtoms.Core;


namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// AtomUniformGrid is a layout control that assists in the display and layout of several data items.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomUniformGrid
    /// </listheader>
    /// 		<item>
    /// This control displays a grid of data, either text, images or other imbedded controls, in a grid. The layout of the grid can be customized by setting the vertical and horizontal gaps between the rows and columns. This will automatically align all the data to be displayed based on the gaps specified.
    /// </item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomUniformGrid : Panel
    {
        /// <summary>   
        /// Gets or sets the computed row value.   
        /// </summary>   
        private int ComputedRows { get; set; }

        /// <summary>   
        /// Gets or sets the computed column value.   
        /// </summary>   
        private int ComputedColumns { get; set; }

        /// <summary>   
        /// Initializes a new instance of UniformGrid.   
        /// </summary>   
        public AtomUniformGrid()
        {
        }

        /// <summary>   
        /// Gets or sets the number of first columns to leave blank.   
        /// </summary>   
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Never
            )]
        public int FirstColumn
        {
            get { return (int)GetValue(FirstColumnProperty); }
            set { SetValue(FirstColumnProperty, value); }
        }

        /// <summary>   
        /// The FirstColumnProperty dependency property.   
        /// </summary>   
        public static readonly DependencyProperty FirstColumnProperty =
                DependencyProperty.Register(
                        "FirstColumn",
                        typeof(int),
                        typeof(AtomUniformGrid),
                        new PropertyMetadata(0, OnIntegerDependencyPropertyChanged));

        /// <summary>
        /// Gets or sets the number of columns in the grid. A value of zero indicates that the count should be dynamically computed based on the number of rows and the number of non-collapsed children in the grid.
        /// </summary>
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public int Columns
        {
            get { return (int)GetValue(ColumnsProperty); }
            set { SetValue(ColumnsProperty, value); }
        }

        /// <summary>   
        /// DependencyProperty for the Columns property.   
        /// </summary>   
        public static readonly DependencyProperty ColumnsProperty =
                DependencyProperty.Register(
                        "Columns",
                        typeof(int),
                        typeof(AtomUniformGrid),
                        new PropertyMetadata(0, OnIntegerDependencyPropertyChanged));

        /// <summary>   
        /// Validate the new property value and silently revert if the new value   
        /// is not appropriate. Used in place of WPF value coercian by the   
        /// dependency properties in UniformGrid.   
        /// </summary>   
        /// <param name="o">The dependency object.</param>   
        /// <param name="e">The dependency property.</param>   
        private static void OnIntegerDependencyPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            // Silently coerce the value back to >= 0 if negative.   
            if (!(e.NewValue is int) || (int)e.NewValue < 0)
            {
                o.SetValue(e.Property, e.OldValue);
            }
        }

        /// <summary>   
        /// Gets or sets the number of rows in the grid. A value of zero   
        /// indicates that the row count should be dynamically computed based on   
        /// the number of columns and the number of non-collapsed children in   
        /// the grid.   
        /// </summary>   
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public int Rows
        {
            get { return (int)GetValue(RowsProperty); }
            set { SetValue(RowsProperty, value); }
        }

        /// <summary>   
        /// The Rows DependencyProperty.   
        /// </summary>   
        public static readonly DependencyProperty RowsProperty =
                DependencyProperty.Register(
                        "Rows",
                        typeof(int),
                        typeof(AtomUniformGrid),
                        new PropertyMetadata(0, OnIntegerDependencyPropertyChanged));



        #region Dependency Property HorizontalGap
        ///<summary>
        ///
        ///</summary>
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public int HorizontalGap
        {
            get { return (int)GetValue(HorizontalGapProperty); }
            set { SetValue(HorizontalGapProperty, value); }
        }

        ///<summary>
        ///
        ///</summary>
#if SILVERLIGHT        
        public static readonly DependencyProperty HorizontalGapProperty =
            DependencyProperty.Register("HorizontalGap", typeof(int), typeof(AtomUniformGrid), new PropertyMetadata(4, new PropertyChangedCallback(HorizontalGapChangedCallback)));

        public event DependencyPropertyChangedEventHandler HorizontalGapChanged;

        protected void OnHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
        {
            AtomUtils.Invalidate(this);
            if (this.HorizontalGapChanged != null)
            {
                this.HorizontalGapChanged(this, e);
            }
        }

        private static void HorizontalGapChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AtomUniformGrid obj = sender as AtomUniformGrid;
            obj.OnHorizontalGapChanged(e);
        }
#else
        public static readonly DependencyProperty HorizontalGapProperty =
            DependencyProperty.Register("HorizontalGap", typeof(int), typeof(AtomUniformGrid), new FrameworkPropertyMetadata(4, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsMeasure));
#endif

        #endregion


        #region Dependency Property VerticalGap
        ///<summary>
        ///
        ///</summary>
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public int VerticalGap
        {
            get { return (int)GetValue(VerticalGapProperty); }
            set { SetValue(VerticalGapProperty, value); }
        }

        ///<summary>
        ///
        ///</summary>
#if SILVERLIGHT        
        public static readonly DependencyProperty VerticalGapProperty =
            DependencyProperty.Register("VerticalGap", typeof(int), typeof(AtomUniformGrid), new PropertyMetadata(4, new PropertyChangedCallback(VerticalGapChangedCallback)));

        public event DependencyPropertyChangedEventHandler VerticalGapChanged;

        protected void OnVerticalGapChanged(DependencyPropertyChangedEventArgs e)
        {
            AtomUtils.Invalidate(this);
            if (this.VerticalGapChanged != null)
            {
                this.VerticalGapChanged(this, e);
            }
        }

        private static void VerticalGapChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AtomUniformGrid obj = sender as AtomUniformGrid;
            obj.OnVerticalGapChanged(e);
        }
#else
        public static readonly DependencyProperty VerticalGapProperty =
            DependencyProperty.Register("VerticalGap", typeof(int), typeof(AtomUniformGrid), new FrameworkPropertyMetadata(4, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsMeasure));
#endif
        #endregion



        /// <summary>   
        /// Compute the desired size of the UniformGrid by measuring all of the   
        /// children with a constraint equal to a cell's portion of the given   
        /// constraint. The maximum child width and maximum child height are   
        /// tracked, and then the desired size is computed by multiplying these   
        /// maximums by the row and column count.   
        /// </summary>   
        /// <param name="constraint">The size constraint.</param>   
        /// <returns>Returns the desired size.</returns>   
        protected override Size MeasureOverride(Size constraint)
        {
            UpdateComputedValues();

            Size childConstraint = new Size(constraint.Width / ComputedColumns, constraint.Height / ComputedRows);
            double maxChildDesiredWidth = 0.0;
            double maxChildDesiredHeight = 0.0;

            double hTotalGap = 0;
            double vTotalGap = 0;
            double hGap = HorizontalGap;
            double vGap = VerticalGap;

            //  Measure each child, keeping track of max desired width & height.   
            for (int i = 0, count = Children.Count; i < count; ++i)
            {
                UIElement child = Children[i];
                child.Measure(childConstraint);
                Size childDesiredSize = child.DesiredSize;
                if (maxChildDesiredWidth < childDesiredSize.Width)
                {
                    maxChildDesiredWidth = childDesiredSize.Width;
                }
                if (maxChildDesiredHeight < childDesiredSize.Height)
                {
                    maxChildDesiredHeight = childDesiredSize.Height;
                }
                hTotalGap += hGap;
                vTotalGap += vGap;
            }
            if (hTotalGap > 0)
                hTotalGap -= hGap;
            if (vTotalGap > 0)
                vTotalGap -= vGap;
            return new Size((maxChildDesiredWidth * ComputedColumns) + hTotalGap, (maxChildDesiredHeight * ComputedRows) + vTotalGap);
        }

        /// <summary>   
        /// Arrange the children of the UniformGrid by distributing space evenly   
        /// among the children, making each child the size equal to a cell   
        /// portion of the arrangeSize parameter.   
        /// </summary>   
        /// <param name="arrangeSize">The arrange size.</param>   
        /// <returns>Returns the updated Size.</returns>   
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Rect childBounds = new Rect(0, 0, arrangeSize.Width / ComputedColumns, arrangeSize.Height / ComputedRows);
            double xStep = childBounds.Width;
            double xBound = arrangeSize.Width - 1.0;
            childBounds.X += childBounds.Width * FirstColumn;

            double hGap = HorizontalGap;
            double vGap = VerticalGap;

            // Arrange and Position each child to the same cell size   
            foreach (UIElement child in Children)
            {
                child.Arrange(childBounds);
                if (child.Visibility != Visibility.Collapsed)
                {
                    childBounds.X += xStep + hGap;
                    if (childBounds.X >= xBound)
                    {
                        childBounds.Y += childBounds.Height + vGap;
                        childBounds.X = 0;
                    }
                }
            }

            return arrangeSize;
        }

        /// <summary>   
        /// If the Rows or Columns values are set to 0, dynamically compute the   
        /// values based on the actual number of non-collapsed children.   
        /// </summary>   
        /// <remarks>   
        /// In the case when both Rows and Columns are set to 0, the Rows and   
        /// Columns will be equal, laying out a square grid.   
        /// </remarks>   
        private void UpdateComputedValues()
        {
            ComputedColumns = Columns;
            ComputedRows = Rows;

            // Reset the first column. This is the same logic performed by WPF.   
            if (FirstColumn >= ComputedColumns)
            {
                FirstColumn = 0;
            }

            if ((ComputedRows == 0) || (ComputedColumns == 0))
            {
                int nonCollapsedCount = 0;
                for (int i = 0, count = Children.Count; i < count; ++i)
                {
                    UIElement child = Children[i];
                    if (child.Visibility != Visibility.Collapsed)
                    {
                        nonCollapsedCount++;
                    }
                }
                if (nonCollapsedCount == 0)
                {
                    nonCollapsedCount = 1;
                }
                if (ComputedRows == 0)
                {
                    if (ComputedColumns > 0)
                    {
                        ComputedRows = (nonCollapsedCount + FirstColumn + (ComputedColumns - 1)) / ComputedColumns;
                    }
                    else
                    {
                        ComputedRows = (int)Math.Sqrt(nonCollapsedCount);
                        if ((ComputedRows * ComputedRows) < nonCollapsedCount)
                        {
                            ComputedRows++;
                        }
                        ComputedColumns = ComputedRows;
                    }
                }
                else if (ComputedColumns == 0)
                {
                    ComputedColumns = (nonCollapsedCount + (ComputedRows - 1)) / ComputedRows;
                }
            }
        }
    }
}
