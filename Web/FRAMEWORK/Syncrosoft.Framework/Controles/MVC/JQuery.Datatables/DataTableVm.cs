using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Syncrosoft.Framework.Controles.Mvc.JQuery.Datatables
{
    public class DataTableVm
    {
        static DataTableVm()
        {
            DefaultTableClass = "table table-bordered table-striped";
        }

        public static string DefaultTableClass { get; set; }
        public string TableClass { get; set; }
        public ColumnCommand[] operators;
        public bool OpcionesEnGrilla { get; set; }
        public bool OpcionesConextuales { get; set; }
        public string fnDrawCallBack { get; set; }
        public Dictionary<int, string> OrdenarPor { get; set; }
        public int CantidadRegistrosDefault { get; set; }

        public DataTableVm(string id, string ajaxUrl, IEnumerable<Tuple<string, Type>> columns)
        {
            AjaxUrl = ajaxUrl;
            this.Id = id;
            this.Columns = columns;
            FilterTypeRules = new FilterRuleList();
            FilterTypeRules.AddRange(StaticFilterTypeRules);
            this.ShowSearch = true;
            this.ShowPageSizes = true;
            this.TableTools = true;
            this.operators = null;
            this.OpcionesEnGrilla = true;
            this.OpcionesConextuales = true;
        }

        public DataTableVm(string id, string ajaxUrl, IEnumerable<Tuple<string, Type>> columns, ColumnCommand[] operators) : this(id, ajaxUrl, columns)
        {
            this.operators = operators;
        }

        public bool ShowSearch { get; set; }

        public string Id { get; private set; }

        public string AjaxUrl { get; private set; }

        public IEnumerable<Tuple<string, Type>> Columns { get; private set; }

        public bool ColumnFilter { get; set; }

        public bool TableTools { get; set; }

        public bool AutoWidth { get; set; }

        public string ColumnFiltersString
        {
            get { return string.Join(",", Columns.Select(c => GetFilterType(c.Item1, c.Item2))); }
        }

        public string Dom
        {
            get { 
                var sdom = "";
                if (TableTools) sdom += "T<\"clear\">";
                if (ShowPageSizes) sdom += "l";
                if (ShowSearch) sdom += "f";
                sdom += "tipr";
                return sdom;
            }
        }

        public bool ShowPageSizes { get; set; }


        public string GetFilterType(string columnName, Type type)
        {
            foreach (Func<string, Type, string> filterTypeRule in FilterTypeRules)
            {
                var rule = filterTypeRule(columnName, type);
                if (rule != null) return rule;
            }
            return "null";
        }

        public FilterRuleList FilterTypeRules;

        public static FilterRuleList StaticFilterTypeRules = new FilterRuleList()
        {
            (c, t) => (DateTypes.Contains(t)) ? "{type: 'date-range', sSelector: '#renderingEngineFilter_"+c+"'}" : null,
            (c, t) => "{type: 'text', sSelector: '#renderingEngineFilter_"+c+"'}", //by default, text filter on everything
        };

        private static List<Type> DateTypes = new List<Type> { typeof(DateTime), typeof(DateTime?), typeof(DateTimeOffset), typeof(DateTimeOffset?) };

        public class _FilterOn<TTarget>
        {
            private readonly TTarget _target;
            private readonly FilterRuleList _list;
            private readonly Func<string, Type, bool> _predicate;

            public _FilterOn(TTarget target, FilterRuleList list, Func<string, Type, bool> predicate)
            {
                _target = target;
                _list = list;
                _predicate = predicate;
            }

            public TTarget Select(params string[] options)
            {
                AddRule("{type: 'select', values: ['" + string.Join("','", options) + "']}");
                return _target;
            }
            public TTarget NumberRange()
            {
                AddRule("{type: 'number-range'}");
                return _target;
            }

            public TTarget DateRange()
            {
                AddRule("{type: 'date-range'}");
                return _target;
            }

            public TTarget Number()
            {
                AddRule("{type: 'number'}");
                return _target;
            }

            public TTarget None()
            {
                AddRule("null");
                return _target;
            }

            private void AddRule(string result)
            {
                _list.Insert(0, (c, t) => _predicate(c, t) ? result : null);
            }
        }
        public _FilterOn<DataTableVm> FilterOn<T>()
        {
            return new _FilterOn<DataTableVm>(this, this.FilterTypeRules, (c, t) => t == typeof(T));
        }
        public _FilterOn<DataTableVm> FilterOn(string columnName)
        {
            return new _FilterOn<DataTableVm>(this, this.FilterTypeRules, (c, t) => c == columnName);
        }

    }

    public class FilterRuleList : List<Func<string, Type, string>>
    {
       
    }

    public class ColumnCommand
    {

        public string display {set; get;}
        public string function { get; set; }
        public string icon { get; set; }
        public string tooltip { get; set; }
        public string iconclass { get; set; }
        public bool? administrador { get; set; }

    }


}