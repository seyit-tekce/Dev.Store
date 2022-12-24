using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;


namespace Kendo.Mvc.UI.Fluent
{
    public abstract class GridToolBarCommandBuilderBase<TCommand, TBuilder> : IHideObjectMembers where TCommand : GridActionCommandBase where TBuilder : GridToolBarCommandBuilderBase<TCommand, TBuilder>
    {
        protected TCommand Command { get; private set; }

        protected GridToolBarCommandBuilderBase(TCommand command)
        {
            Command = command;
        }

        public TBuilder Text(string text)
        {
            Command.Text = text;
            return this as TBuilder;
        }

        public TBuilder IconClass(string iconClass)
        {
            Command.IconClass = iconClass;
            return this as TBuilder;
        }

       

        public TBuilder HtmlAttributes(IDictionary<string, object> attributes)
        {
            Command.HtmlAttributes.Merge(attributes);
            return this as TBuilder;
        }
        
        
        Type IHideObjectMembers.GetType()
        {
            return GetType();
        }
    }
}

