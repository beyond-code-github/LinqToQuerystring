(function($) {

    var fieldsHtml;

    var fieldTemplateEngine = new ko.nativeTemplateEngine();
    fieldTemplateEngine.makeTemplateSource = function (template) {
        return { text: function() { return fieldsHtml; } }
    };

    ko.bindingHandlers["fieldTemplate"] = {
        update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            var options = ko.utils.unwrapObservable(valueAccessor());

            options.templateEngine = fieldTemplateEngine;
            ko.renderTemplate(null, bindingContext.createChildContext(options.data), options, element, "replaceNode");
        }
    }

    $.fn.oDataFilterUI = function (options)
    {
        // Construct settings from defaults
        var settings = $.extend({
            Fields: [],
            CustomTypes: [],
            fieldNameModifier: function (fieldname) { 
                return fieldname; 
            }
        }, options );

        // Convert input to hidden
        this.attr("type", "hidden");

        // Append container
        var container = this.wrap($('<div>')).parent();
        
        var noFilterMessage = $("<span>").html("There are currently no filters applied").prependTo(container);
        noFilterMessage.before("<!-- ko if: !FilterRows() || FilterRows().length == 0 -->")
        noFilterMessage.after("<!-- /ko -->")
     
        var rowContainer = $('<div>', { "data-bind": "fieldTemplate: { data: $root }" }).insertAfter(this);
                
        var repeater = $('<div>', { "data-bind" : "foreach: FilterRows" });
        var row = $('<ol>').appendTo(repeater);

        //Append input elements
        var filterFieldLi = $('<select>', { class: "filterField", "data-bind": "value: Field, options: $parent.Fields, optionsText: 'text'" })
            .appendTo(row).wrap($("<li>")).parent();
        filterFieldLi.before("<!-- ko if: $parent.Fields -->")
        filterFieldLi.after("<!-- /ko -->")

        var operatorField = $('<select>', { class: "filterOperator", "data-bind": "value: Operator, options: OperatorsList, optionsText: 'text', optionsValue: 'value'" })
            .appendTo(row).wrap($("<li>"));
        
        var filterValueLi = $('<input>', { class: "filterValue", type: "text", "data-bind": "value: Value" })
            .appendTo(row).wrap($("<li>")).parent();
        filterValueLi.before("<!-- ko if: (Field() && Field().type == 'string') -->")
        filterValueLi.after("<!-- /ko -->")

        var filterFieldNumberLi = $('<input>', { class: "filterValue", type: "number", "data-bind": "value: Value" })
            .appendTo(row).wrap($("<li>")).parent();
        filterFieldNumberLi.before("<!-- ko if: Field() && FieldIsNumeric() -->")
        filterFieldNumberLi.after("<!-- /ko -->")

        var filterFieldDateLi = $('<input>', { class: "filterValue", type: "datetime-local", "data-bind": "value: Value" })
            .appendTo(row).wrap($("<li>")).parent();
        filterFieldDateLi.before("<!-- ko if: Field() && Field().type == 'datetime' -->")
        filterFieldDateLi.after("<!-- /ko -->")

        var filterFieldBoolLi = $('<input>', { class: "filterValue", type: "checkbox", "data-bind": "checked: Value" })
            .appendTo(row).wrap($("<li>")).parent();
        filterFieldBoolLi.before("<!-- ko if: Field() && Field().type == 'bool' -->")
        filterFieldBoolLi.after("<!-- /ko -->")

        var filterComplexLi = $('<div>', { "data-bind": "fieldTemplate: { data: $data }" })
            .appendTo(row).wrap($("<li>")).parent();
        filterComplexLi.before("<!-- ko if: FieldIsArrayType() -->")
        filterComplexLi.after("<!-- /ko -->")

        var removeButtonLi = $('<a>', { class: "filterRemove", href: "#", "data-bind": "click: $parent.removeFilter" })
            .html("remove")
            .appendTo(row).wrap($("<li>")).parent();
        removeButtonLi.before("<!-- ko if: $parent.Fields -->")
        removeButtonLi.after("<!-- /ko -->")

        var addAnother = $('<a>', { class: "addAnother", href: "#", "data-bind": "click: addAnother"  }).html("add").appendTo(container);

        //add fields template last
        fieldsHtml = repeater.wrap($("<div>")).parent().html();

        // Row model constructor
        var createRow = function () {
            var field = ko.observable();
            var operator = ko.observable();
            var value = ko.observable();

            var fieldName = ko.computed(function () {
                return field().value;
            }, null, { deferEvaluation: true});

            var fieldIsArrayType = ko.computed(function () {
                return field().type.indexOf("array[") >= 0;
            }, null, { deferEvaluation: true});

            var fieldIsNumeric = ko.computed(function () {
                return field().type == 'int' || field().type == 'long' || field().type == 'double' || field().type == 'single';
            }, null, { deferEvaluation: true});

            var operatorsList = ko.computed(function() {
                var result = [
                    { text: "Equals", value: "eq" },
                    { text: "Not equals", value: "ne" }
                ];

                var fieldType = field() ? field().type : "string";
                switch (fieldType) {
                    case "int":
                    case "long":
                    case "datetime":
                    case "double":
                    case "single":
                        result.push({ text: "Greater than", value: "gt" });
                        result.push({ text: "Greater than or equals", value: "ge" });
                        result.push({ text: "Less than", value: "lt" });
                        result.push({ text: "Less than or equals", value: "le" });
                        break;
                    case "string":
                        result.push({ text: "Starts With", value: "startswith" });
                        result.push({ text: "Ends With", value: "endswith" });
                        result.push({ text: "Contains", value: "contains" });
                        break;
                    default:
                        if (fieldType.indexOf("array[") >= 0)
                        {
                            var arrayType = fieldType.replace("array[", "").replace("]", "");
                            var customType = ko.utils.arrayFirst(settings.CustomTypes, function (item) {
                                return item.name == arrayType;
                            }); 

                            result = [];
                            result.push({ text: "Any", value: "any" });
                            result.push({ text: "All", value: "all" });
                            result.push({ text: "Count", value: "count" });                            

                            switch (arrayType) {
                                case "int":
                                case "long":
                                case "double":
                                case "single":
                                    result.push({ text: "Sum", value: "sum" });
                                    result.push({ text: "Average", value: "average" });
                                case "string":
                                    result.push({ text: "Min", value: "min" });
                                    result.push({ text: "Max", value: "max" });
                                    break;
                            }
                        }

                        break;
                }                
                
                return result;

            }, null, { deferEvaluation: true });

            var subRows = ko.computed(function () {

                var result = [];
                var fieldType = field() ? field().type : "string";

                operator(null);

                if (field().type.indexOf("array[") >= 0)
                {
                    var arrayType = field().type.replace("array[", "").replace("]", "");
                    var customType = ko.utils.arrayFirst(settings.CustomTypes, function (item) {
                        return item.name == arrayType;
                    });                   

                    var row = createRow();
                    var operatorValue = operator() ? operator() : "any";

                    var underlyingType = arrayType;
                    if (customType)
                    {
                        if (customType.fields && customType.fields.length == 1)
                        {
                            var subfield = customType.fields[0];
                            switch (operatorValue)
                            {
                                case "count":
                                    row.Field({ text: operatorValue, path: field().value, value: operatorValue + "()", type: "int" });
                                    break;
                                case "average":
                                case "sum":                                    
                                case "min":
                                case "max":
                                    row.Field({ text: operatorValue, path: field().value, value: operatorValue + "()", type: subfield.type });
                                    break;
                                case "any":                    
                                case "all":
                                    row.Field({ text: "value", path: "value", value: subfield.value, type: subfield.type });
                            }

                            result.push(row);
                            return result;
                        }
                    }

                    switch (operatorValue)
                    {
                        case "count":
                            row.Field({ text: operatorValue, path: field().value, value: operatorValue + "()", type: "int" });
                            break;
                        case "min":
                        case "max":
                        case "average":
                        case "sum":
                            row.Field({ text: operatorValue, path: field().value, value: operatorValue + "()", type: underlyingType });
                            break;
                        case "any":                    
                        case "all":
                            row.Field({ text: "value", value: "value", type: underlyingType });
                    }

                    result.push(row);
                }

                return result;

            }, null, { deferEvaluation: true});

            var row = {};
            row.Field = field;
            row.FieldName = fieldName;
            row.FieldIsArrayType = fieldIsArrayType;
            row.FieldIsNumeric = fieldIsNumeric;
            row.Operator = operator;
            row.Value = value;
            row.OperatorsList = operatorsList;
            row.FilterRows = subRows;

            return row;
        };

        // Model constructor
        var filterRows = ko.observableArray([]);
        var fields = ko.observableArray(settings.Fields);

        var removeFilter = function (filter) {
            if (filterRows().length > 0)
            {
                filterRows.remove(filter);
            }
        };

        var addAnother = function () {
            filterRows.push(createRow());
        };

        var buildFilterStringForRow = function (row, modifyFieldName)
        {
            modifyFieldName = typeof modifyFieldName !== 'undefined' ? modifyFieldName : true;

            var fieldName = modifyFieldName ? settings.fieldNameModifier(row.FieldName()) : row.FieldName();
            if (row.Field().path)
            {
                fieldName = row.Field().path + "/" + fieldName;
            }

            var part = fieldName + " " + row.Operator() + " ";
            if (row.Field().value.indexOf("()") >= 0)
            {
                part = row.Field().path + "/" + row.Field().value + " " + row.Operator() + " ";
            }

            switch(row.Field().type)
            {
                case "string":
                    var stringValue = "'" + (row.Value() ? row.Value() : "") + "'";
                    switch (row.Operator())
                    {
                        case "startswith":
                            part = "startswith(" + fieldName + "," + stringValue + ")";
                            break;
                        case "endswith":
                            part = "endswith(" + fieldName + "," + stringValue + ")";
                            break;
                        case "contains":
                            part = "substringof(" + stringValue + "," + fieldName + ")";
                            break;
                        default:
                            part = part + "'" + (row.Value() ? row.Value() : "") + "'";
                    }
                    return part;
                case "int":
                case "long":
                case "double":
                case "single":
                    part = part + (row.Value() ? row.Value() : 0);
                    return part;
                case "datetime":
                    part = part + "datetime'" + (row.Value() ? row.Value() : "1753-01-01T00:00") + "'";
                    return part;
                case "bool":
                    part = part + (row.Value() ? row.Value() : false);
                    return part;
                default:

                    if (row.Field().type.indexOf("array[") >= 0)
                    {
                        var arrayType = row.Field().type.replace("array[", "").replace("]", "");
                    
                        switch (row.Operator())
                        {
                            case "any":
                            case "all":
                                var filter = fieldName + "/" + row.Operator() + "(value: ";
                                var subfilters = [];

                                for (var index in row.FilterRows())
                                {
                                    var subRow = row.FilterRows()[index];
                                    var part = buildFilterStringForRow(subRow, false);
                                    subfilters.push(part);
                                }

                                if (subfilters.length > 0)
                                {
                                    filter = filter + subfilters.join(" and ");    
                                }

                                filter = filter + ")";
                                return filter;
                            case "count":
                            case "min":
                            case "max":
                            case "average":
                            case "sum":
                                var filter;
                                var subfilters = [];

                                for (var index in row.FilterRows())
                                {
                                    var subRow = row.FilterRows()[index];
                                    var part = buildFilterStringForRow(subRow);
                                    subfilters.push(part);
                                }

                                if (subfilters.length > 0)
                                {
                                    filter = subfilters.join(" and ");    
                                }

                                return filter;
                        }         
                    }              
                    break;
            }
        }

        var getODataFilter = ko.computed(function() {
            var filters = [];
            for (var index in filterRows())
            {
                var row = filterRows()[index];
                var part = buildFilterStringForRow(row);
                filters.push(part);
            }

            if (filters.length > 0)
            {
                return "$filter=" + filters.join(" and ");    
            }

            return "";
            
        }, null, { deferEvaluation : true });

        if (settings.Model)
        {
            this.Model = settings.Model;
        }
        else
        {
            this.Model = {};
            this.Model.FilterRows = filterRows;
            this.Model.Fields = fields;
            this.Model.removeFilter = removeFilter;
            this.Model.addAnother = addAnother;
            this.Model.getODataFilter = getODataFilter;
        }

        ko.applyBindings(this.Model, container.get(0));

        return this;
    }

}(jQuery));